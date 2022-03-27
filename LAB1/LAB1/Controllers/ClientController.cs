using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models;
using LAB1.Models.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class ClientController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Client GetClient()
    {
        var client = _context.Clients
            .Include(c => c.Banks)!
            .ThenInclude(c => c.OpennedBankAccounts)
            .Include(c => c.OpennedBankAccounts)
            .Include(c => c.BanksAndApproves)!
            .ThenInclude(c => c.Bank)
            .Include(c => c.OpennedBankDeposits)
            .Include(c => c.InstallmentPlansAndApproves)!
            .ThenInclude(c => c.Bank)
            .Include(c => c.InstallmentPlansAndApproves)!
            .ThenInclude(c => c.InstallmentPlan)
            .Include(c => c.CreditsAndApproves)!
            .ThenInclude(c => c.Credit)
            .Include(c => c.Work)
            .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;
        return client;
    }

    public Bank GetBank(Client client)
    {
        var bank = _context.Banks
            .Include(b => b.OpennedBankAccounts)
            .Include(b => b.OpennedBankDeposits)
            .Include(b => b.OpennedInstallmentPlans)
            .Include(b => b.OpennedCredits)
            .FirstAsync(b => b.Id == client.CurrentBankId).Result;
        return bank;
    }

    public Specialist GetSpecialist(int companyId)
    {
        var specialist = _context.Specialists
            .Include(s => s.Company)
            .Include(s => s.ClientsToPaymentProject)
            .FirstOrDefaultAsync(s => s.CompanyId == companyId).Result;
        return specialist;
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new ClientAdditionalInfoModel
        {
            Companies = _context.Companies.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(ClientAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
            if (model.IdOfSelectedCompany != null)
            {
                var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
                var clientRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "client"))!;
                var selectedCompany = _context.Companies.Include(c => c.Workers)
                    .FirstOrDefaultAsync(c => c.Id == model.IdOfSelectedCompany).Result;

                var client = new Client
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Name = user.Name,
                    Surname = user.Surname,
                    Patronymic = user.Patronymic,
                    PhoneNumber = user.PhoneNumber,
                    RoleId = user.RoleId,
                    Role = clientRole,
                    IdentificationNumber = model.IdentificationNumber,
                    PassportNumberAndSeries = model.PassportNumberAndSeries,
                    CurrentBankId = 0,
                    BanksAndApproves = new List<BankApproves>(),
                    BankBalance = 0,
                    Banks = new List<Bank>(),
                    OpennedBankAccounts = new List<BankAccount>(),
                    InstallmentPlansAndApproves = new List<InstallmentPlanApproves>(),
                    Work = selectedCompany,
                    AtSalaryProject = false,
                    Salary = selectedCompany!.SalaryForWorkers
                };

                selectedCompany.Workers.Add(client);

                if (client != null)
                {
                    _context.Users.Remove(user);
                    _context.Clients.Add(client);
                    _context.Companies.Update(selectedCompany);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Profile", "Client");
                }
            }
        //return RedirectToAction("GetAdditionalInfo", "Client");

        //return RedirectToAction("GetAdditionalInfo", "Client");
        return View(new ClientAdditionalInfoModel
        {
            Companies = _context.Companies.ToList()
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var client = GetClient();
        var banks = _context.Banks.Include(b => b.OpennedBankAccounts).ToList();
        var BanksWhereApproved = new List<Bank>();

        foreach (var bank in client.BanksAndApproves)
            if (bank.Approved!.Value)
                BanksWhereApproved.Add(bank.Bank!);

        return View(new ClientProfileModel
        {
            BanksWhereApproved = BanksWhereApproved,
            Client = client,
            Banks = banks
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult ChooseTheBank()
    {
        var client = GetClient();

        var banks = _context.Banks
            .Include(b => b.OpennedBankAccounts).ToList();

        var banksToPass = new List<Bank>();

        foreach (var bank in banks)
            if (client.BanksAndApproves.Count == banks.Count)
            {
                foreach (var approvedBank in client.BanksAndApproves!)
                    if (!bank.Equals(approvedBank.Bank))
                        banksToPass.Add(bank);
            }
            else
            {
                banksToPass.Add(bank);
            }


        return View(new BanksModel
        {
            Banks = banksToPass
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChooseTheBank(BanksModel model)
    {
        if (ModelState.IsValid)
            if (model.SelectedBankId != null)
            {
                var client = GetClient();

                if (client != null)
                {
                    var bank = await _context.Banks.FirstOrDefaultAsync(b =>
                        b.Id == model.SelectedBankId);
                    client.BanksAndApproves!.Add(new BankApproves(bank!, false));
                    client.Banks!.Add(bank);
                    bank.AmountOfClients++;
                    _context.Clients.Update(client);
                    _context.Banks.Update(bank);
                }


                await _context.SaveChangesAsync();


                return RedirectToAction("Profile", "Account");
            }

        var client1 = GetClient();

        var banks = _context.Banks
            .Include(b => b.OpennedBankAccounts).ToList();

        var banksToPass = new List<Bank>();

        foreach (var bank in banks)
            if (client1.BanksAndApproves.Count == banks.Count)
            {
                foreach (var approvedBank in client1.BanksAndApproves!)
                    if (!bank.Equals(approvedBank.Bank))
                        banksToPass.Add(bank);
            }
            else
            {
                banksToPass.Add(bank);
            }

        return View(new BanksModel
        {
            Banks = banksToPass
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RequestApprove()
    {
        var client = GetClient();

        var banksToPass = new List<Bank>();

        foreach (var bank in client.BanksAndApproves)
            if (bank.Approved == false)
                banksToPass.Add(bank.Bank!);


        var managers = new List<Manager>();
        foreach (var manager in _context.Managers)
            if (manager.BankId == client.CurrentBankId)
                managers.Add(manager);

        return View(new ClientGetApproveModel
        {
            ClientBanks = banksToPass,
            Managers = managers
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RequestApprove(ClientGetApproveModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();


            if (client != null)
                if (model.IdOfSelectedBank != null)
                {
                    var manager = _context.Managers
                        .Include(m => m.WaitingForRegistrationApprove)
                        .FirstAsync(m =>
                            m.BankId == model.IdOfSelectedBank && m.WaitingForRegistrationApprove!.Count == 0).Result;

                    if (!manager.WaitingForRegistrationApprove.Contains(client) &&
                        manager.WaitingForRegistrationApprove.Count == 0)
                    {
                        manager.WaitingForRegistrationApprove.Add(client);
                        _context.Managers.Update(manager);
                        await _context.SaveChangesAsync();
                    }
                }

            return RedirectToAction("Profile", "Account");
        }

        var client1 = GetClient();

        var banksToPass = new List<Bank>();

        foreach (var bank in client1.BanksAndApproves)
            if (bank.Approved == false)
                banksToPass.Add(bank.Bank!);


        var managers = new List<Manager>();
        foreach (var manager in _context.Managers)
            if (manager.BankId == client1.CurrentBankId)
                managers.Add(manager);

        return View(new ClientGetApproveModel
        {
            ClientBanks = banksToPass,
            Managers = managers
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult ChangeBankId(ClientProfileModel model)
    {
        var client = GetClient();
        if (model.SelectedBankId != null)
        {
            client!.CurrentBankId = model.SelectedBankId;

            _context.Clients.Update(client);
            _context.SaveChanges();

            return RedirectToAction("BankProfileForClient", "Bank");
        }

        return RedirectToAction("Profile", "Client");
    }

    [HttpGet]
    [Authorize]
    public IActionResult AddMoneyForClient()
    {
        var client = GetClient();

        client!.BankBalance += 10000;

        _context.Clients.Update(client);
        _context.SaveChangesAsync();

        return RedirectToAction("Profile", "Client");
    }

    [HttpGet]
    [Authorize]
    public IActionResult RemoveAllMoneyFromClient()
    {
        var client = GetClient();

        client!.BankBalance = 0;

        _context.Clients.Update(client);
        _context.SaveChangesAsync();

        return RedirectToAction("Profile", "Client");
    }

    [HttpGet]
    [Authorize]
    public IActionResult PayDay()
    {
        var client = GetClient();
        if (!(bool)client.AtSalaryProject)
            client.BankBalance += client.Salary;
        else
            foreach (var bankAccount in client.OpennedBankAccounts!)
                if ((bool)bankAccount.IsASalaryProjectAccount!)
                    bankAccount.AmountOfMoney += client.Salary;

        _context.Update(client);
        _context.SaveChangesAsync();
        return RedirectToAction("Profile", "Client");
    }

    [HttpGet]
    [Authorize]
    public IActionResult Wipe()
    {
        var client = GetClient();
        var bank = GetBank(client);

        client.CreditsAndApproves = new List<CreditsAndApproves>();
        client.OpennedBankAccounts = new List<BankAccount>();
        client.OpennedBankDeposits = new List<BankDeposit>();
        client.InstallmentPlansAndApproves = new List<InstallmentPlanApproves>();
        client.CreditsAndApproves = new List<CreditsAndApproves>();

        bank.OpennedBankAccounts = new List<BankAccount>();
        bank.OpennedBankDeposits = new List<BankDeposit>();
        bank.OpennedInstallmentPlans = new List<InstallmentPlan>();

        _context.Clients.Update(client);
        _context.Banks.Update(bank);
        _context.SaveChangesAsync();

        return RedirectToAction("Profile", "Client");
    }

    [HttpGet]
    [Authorize]
    public IActionResult UpdateInfo()
    {
        var client = GetClient();
        //var bank = GetBank(client);

        if (client.OpennedBankDeposits != null && client.OpennedBankDeposits!.Count != 0)
            foreach (var deposit in client.OpennedBankDeposits!)
            {
                var dateOfMoneyBack = deposit.DateOfMoneyBack;
                var howMuchDaysLasts = dateOfMoneyBack.Subtract(DateTime.Today).Days;
                deposit.HowMuchLasts = howMuchDaysLasts;
            }

        if (client.InstallmentPlansAndApproves != null && client.InstallmentPlansAndApproves!.Count != 0)
            foreach (var installmentPlan in client.InstallmentPlansAndApproves!)
            {
                var dateToPay = installmentPlan.InstallmentPlan!.DateToPay;
                var howMuchDaysLasts = dateToPay.Subtract(DateTime.Today).Days;
                installmentPlan.InstallmentPlan.HowMuchLasts = howMuchDaysLasts;
            }

        if (client.CreditsAndApproves != null && client.CreditsAndApproves!.Count != 0)
            foreach (var credit in client.CreditsAndApproves!)
            {
                var dateToPay = credit.Credit!.DateToPay;
                var howMuchDaysLasts = dateToPay.Subtract(DateTime.Today).Days;
                credit.Credit.HowMuchLasts = howMuchDaysLasts;
            }

        return RedirectToAction("Profile", "Client");
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetTheSalaryProject()
    {
        var client = GetClient();

        return View(new GetTheSalaryProjectForClientModel
        {
            ClientBankAccounts = client.OpennedBankAccounts
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetTheSalaryProject(GetTheSalaryProjectForClientModel model)
    {
        if (ModelState.IsValid)
            if (model.IdOfSelectedBankAccount != null)
            {
                var client = GetClient();
                var specialist = GetSpecialist((int)client.Work.Id);
                var bankAccount =
                    client.OpennedBankAccounts!.FirstOrDefault(b => b.Id == model.IdOfSelectedBankAccount);
                bankAccount!.IsASalaryProjectAccount = true;

                specialist.ClientsToPaymentProject!.Add(client);
                _context.Clients.Update(client);
                _context.Specialists.Update(specialist);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Client");
            }

        var client1 = GetClient();

        return View(new GetTheSalaryProjectForClientModel
        {
            ClientBankAccounts = client1.OpennedBankAccounts
        });
    }
}