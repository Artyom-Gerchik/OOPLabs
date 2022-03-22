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
            .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;
        return client;
    }

    public Bank GetBank(Client client)
    {
        var bank = _context.Banks
            .Include(b => b.OpennedBankAccounts)
            .Include(b => b.OpennedBankDeposits)
            .Include(b => b.OpennedInstallmentPlans)
            .Include(b=>b.OpennedCredits)
            .FirstAsync(b => b.Id == client.CurrentBankId).Result;
        return bank;
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(ClientAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            var clientRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "client"))!;

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
                BankBalance = 1000.0,
                Banks = new List<Bank>(),
                OpennedBankAccounts = new List<BankAccount>(),
                InstallmentPlansAndApproves = new List<InstallmentPlanApproves>()
            };

            if (client != null)
            {
                _context.Users.Remove(user);
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Client");
            }
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var client = GetClient();
        var banks = _context.Banks.Include(b => b.OpennedBankAccounts).ToList();
        var BanksWhereApproved = new List<Bank>();


        client.Salary = 1000;
        _context.Clients.Update(client);
        _context.SaveChangesAsync();

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
        {
            var client = GetClient();

            if (client != null)
                if (model.SelectedBankId != null)
                {
                    var bank = await _context.Banks.FirstOrDefaultAsync(b =>
                        b.Id.ToString().Equals(model.SelectedBankId));
                    client.BanksAndApproves.Add(new BankApproves(bank!, false));
                    client.CurrentBankId = bank!.Id;
                    client.Banks!.Add(bank);
                    bank.AmountOfClients++;
                    _context.Clients.Update(client);
                    _context.Banks.Update(bank);
                }

            await _context.SaveChangesAsync();


            return RedirectToAction("Profile", "Account");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult RequestApprove()
    {
        var client = GetClient();

        var managers = new List<Manager>();
        foreach (var manager in _context.Managers)
            if (manager.BankId == client.CurrentBankId)
                managers.Add(manager);

        return View(new ClientGetApproveModel
        {
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
                if (model.IdOfSelectedManager != null)
                {
                    var manager = _context.Managers
                        .Include(m => m.WaitingForRegistrationApprove)
                        .FirstAsync(m => m.Id == model.IdOfSelectedManager).Result;
                    if (!manager.WaitingForRegistrationApprove.Contains(client))
                    {
                        manager.WaitingForRegistrationApprove.Add(client);
                        _context.Managers.Update(manager);
                        await _context.SaveChangesAsync();
                    }
                }

            return RedirectToAction("Profile", "Account");
        }

        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult ChangeBankId(ClientProfileModel model)
    {
        var client = GetClient();

        client!.CurrentBankId = model.SelectedBankId;

        _context.Clients.Update(client);
        _context.SaveChanges();

        return RedirectToAction("BankProfileForClient", "Bank");
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
        client.BankBalance += client.Salary;

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
}