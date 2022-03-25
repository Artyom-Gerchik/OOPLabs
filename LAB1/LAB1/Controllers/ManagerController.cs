using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.AdminRollBack;
using LAB1.Entities.UserCategories;
using LAB1.Models.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class ManagerController : Controller
{
    private readonly ApplicationDbContext _context;

    public ManagerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Client GetClient(int? id)
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
            .FirstAsync(u => u.Id == id).Result;
        return client;
    }

    public Administrator GetAdministrator(Client client)
    {
        var administrator = _context.Administrators
            .Include(a => a.OpennedBankAccounts)!.ThenInclude(c => c.Client)
            .Include(a => a.OpennedBankAccounts)!.ThenInclude(c => c.BankAccount)
            .Include(a => a.DeletedBankAccounts)!.ThenInclude(c => c.Client)
            .Include(a => a.DeletedBankAccounts)!.ThenInclude(c => c.BankAccount)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.Transfer)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountWhereWithdrawed)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountToDeposited)
            .Include(a => a.OpennedDepositsToRollBack)!.ThenInclude(c => c.BankDeposit)
            .Include(a => a.OpennedDepositsToRollBack)!.ThenInclude(c => c.Client)
            .Include(a => a.ClosedDepositsToRollBack)!.ThenInclude(c => c.BankDeposit)
            .Include(a => a.ClosedDepositsToRollBack)!.ThenInclude(c => c.Client)
            .Include(a => a.TransfersBetweenBankDeposits)!.ThenInclude(c => c.Transfer)
            .Include(a => a.TransfersBetweenBankDeposits)!.ThenInclude(c => c.BankDepositWhereWithdrawed)
            .Include(a => a.TransfersBetweenBankDeposits)!.ThenInclude(c => c.BankDepositToDeposited)
            .Include(a => a.OpennedInstallmentPlans)!.ThenInclude(c => c.Client)
            .Include(a => a.OpennedInstallmentPlans)!.ThenInclude(c => c.InstallmentPlan)
            .FirstOrDefaultAsync(a => a.BankId == client.CurrentBankId).Result;
        return administrator!;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new ManagerAdditionalInfoModel
        {
            Banks = _context.Banks.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(ManagerAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            var managerRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "manager"))!;

            var manager = new Manager
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Role = managerRole,
                BankId = model.SelectedBankId,
                WaitingForRegistrationApprove = new List<Client>(),
                WaitingForInstallmentPlanApprove = new List<Client>()
            };

            if (model.SelectedBankId != null)
            {
                var bank = await _context.Banks.FirstOrDefaultAsync(b =>
                    b.Id.ToString().Equals(model.SelectedBankId.ToString()));
                bank.AmountOfManagers++;
                _context.Banks.Update(bank);
            }

            if (manager != null)
            {
                _context.Users.Remove(user);
                _context.Managers.Add(manager);

                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Manager");
            }
        }

        return View(model);
    }

    [HttpGet]
    [Authorize(Roles = "manager")]
    public IActionResult Approve()
    {
        var manager = _context.Managers
            .Include(m => m.WaitingForRegistrationApprove)
            .Include(m => m.WaitingForInstallmentPlanApprove)
            .Include(m => m.WaitingForCreditApprove)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
        var clientsToApproveBankRegistration = manager.WaitingForRegistrationApprove;
        var clientsToApproveInstallmentPlan = manager.WaitingForInstallmentPlanApprove;
        var clientsToApproveCredit = manager.WaitingForCreditApprove;


        return View(new ManagerApproveModel
        {
            ClientsToApproveBankRegistration = clientsToApproveBankRegistration,
            ClientsToApproveInstallmentPlan = clientsToApproveInstallmentPlan,
            WaitingForCreditApprove = clientsToApproveCredit
        });
    }

    [HttpPost]
    [Authorize(Roles = "manager")]
    public async Task<IActionResult> Approve(ManagerApproveModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.IdOfApprovedClientForRegistration != null)
            {
                var clientToApproveRegistration = GetClient(model.IdOfApprovedClientForRegistration);
                var manager = _context.Managers
                    .Include(m => m.WaitingForRegistrationApprove)
                    .Include(m => m.WaitingForInstallmentPlanApprove)
                    .Include(m => m.WaitingForCreditApprove)
                    .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
                if (clientToApproveRegistration != null)
                {
                    foreach (var banks in clientToApproveRegistration.BanksAndApproves)
                        if (banks.Bank!.Id == manager.BankId)
                            banks.Approved = true;

                    manager.WaitingForRegistrationApprove.Remove(clientToApproveRegistration);
                    _context.Clients.Update(clientToApproveRegistration);
                    _context.Managers.Update(manager);
                    await _context.SaveChangesAsync();
                }
            }

            if (model.IdOfApprovedClientForInstallmentPlan != null)
            {
                var clientToApproveInstallmentPlan = GetClient(model.IdOfApprovedClientForInstallmentPlan);
                var manager = _context.Managers
                    .Include(m => m.WaitingForInstallmentPlanApprove)
                    .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
                var admin = GetAdministrator(clientToApproveInstallmentPlan);
                var tmp = new InstallmentPlan();
                if (clientToApproveInstallmentPlan != null)
                {
                    foreach (var installmentPlans in clientToApproveInstallmentPlan.InstallmentPlansAndApproves!)
                        if (installmentPlans.InstallmentPlan!.BankId == manager.BankId)
                        {
                            tmp = installmentPlans.InstallmentPlan;
                            installmentPlans.Approved = true;
                            clientToApproveInstallmentPlan.BankBalance +=
                                installmentPlans.InstallmentPlan!.AmountOfMoney;
                        }

                    admin.OpennedInstallmentPlans!.Add(
                        new RollBackOpennedInstallmentPlan(clientToApproveInstallmentPlan, tmp));
                    manager.WaitingForInstallmentPlanApprove!.Remove(clientToApproveInstallmentPlan);
                    _context.Clients.Update(clientToApproveInstallmentPlan);
                    _context.Managers.Update(manager);
                    _context.Administrators.Update(admin);
                    await _context.SaveChangesAsync();
                }
            }

            if (model.IdOfApprovedClientForCredit != null)
            {
                var clientToApproveCredit = GetClient(model.IdOfApprovedClientForCredit);
                var manager = _context.Managers
                    .Include(m => m.WaitingForCreditApprove)
                    .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
                if (clientToApproveCredit != null)
                {
                    foreach (var credit in clientToApproveCredit.CreditsAndApproves!)
                        if (credit.Credit!.BankId == manager.BankId)
                        {
                            credit.Approved = true;
                            clientToApproveCredit.BankBalance +=
                                credit.Credit!.AmountOfMoney;
                        }

                    manager.WaitingForCreditApprove!.Remove(clientToApproveCredit);
                    _context.Clients.Update(clientToApproveCredit);
                    _context.Managers.Update(manager);
                    await _context.SaveChangesAsync();
                }
            }
        }

        return RedirectToAction("Profile", "Manager");
    }


    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var manager = _context.Managers
            .Include(m => m.WaitingForRegistrationApprove)
            .Include(m => m.WaitingForInstallmentPlanApprove)
            .Include(m => m.WaitingForCreditApprove)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;

        return View(new ManagerProfileModel
        {
            Manager = manager
        });
    }
}