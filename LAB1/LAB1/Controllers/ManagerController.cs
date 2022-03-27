using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.AdminRollBack;
using LAB1.Entities.ManagerRollBack;
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
            .Include(a => a.DeletedInstallmentPlans)!.ThenInclude(c => c.Client)
            .Include(a => a.DeletedInstallmentPlans)!.ThenInclude(c => c.InstallmentPlan)
            .Include(a => a.DeletedInstallmentPlans)!.ThenInclude(c => c.Transfer)
            .Include(a => a.OpennedCredits)!.ThenInclude(c => c.Client)
            .Include(a => a.OpennedCredits)!.ThenInclude(c => c.Credit)
            .Include(a => a.DeletedCredits)!.ThenInclude(c => c.Client)
            .Include(a => a.DeletedCredits)!.ThenInclude(c => c.Credit)
            .Include(a => a.DeletedCredits)!.ThenInclude(c => c.Transfer)
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
    [Authorize]
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
    [Authorize]
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
                    return RedirectToAction("Profile", "Manager");
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
                    return RedirectToAction("Profile", "Manager");
                }
            }

            if (model.IdOfApprovedClientForCredit != null)
            {
                var clientToApproveCredit = GetClient(model.IdOfApprovedClientForCredit);
                var manager = _context.Managers
                    .Include(m => m.WaitingForCreditApprove)
                    .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
                var admin = GetAdministrator(clientToApproveCredit);
                var tmp = new Credit();
                if (clientToApproveCredit != null)
                {
                    foreach (var credit in clientToApproveCredit.CreditsAndApproves!)
                        if (credit.Credit!.BankId == manager.BankId && credit.Approved != true &&
                            credit.Credit.Hidden != true)
                        {
                            tmp = credit.Credit;
                            credit.Approved = true;
                            clientToApproveCredit.BankBalance +=
                                credit.Credit!.AmountOfMoney;
                        }

                    admin.OpennedCredits!.Add(
                        new RollBackOpennedCredit(clientToApproveCredit, tmp));
                    manager.WaitingForCreditApprove!.Remove(clientToApproveCredit);
                    _context.Clients.Update(clientToApproveCredit);
                    _context.Managers.Update(manager);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Profile", "Manager");
                }
            }
        }

        var manager1 = _context.Managers
            .Include(m => m.WaitingForRegistrationApprove)
            .Include(m => m.WaitingForInstallmentPlanApprove)
            .Include(m => m.WaitingForCreditApprove)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
        var clientsToApproveBankRegistration = manager1.WaitingForRegistrationApprove;
        var clientsToApproveInstallmentPlan = manager1.WaitingForInstallmentPlanApprove;
        var clientsToApproveCredit = manager1.WaitingForCreditApprove;


        return View(new ManagerApproveModel
        {
            ClientsToApproveBankRegistration = clientsToApproveBankRegistration,
            ClientsToApproveInstallmentPlan = clientsToApproveInstallmentPlan,
            WaitingForCreditApprove = clientsToApproveCredit
        });
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


    [HttpGet]
    [Authorize]
    public IActionResult RollBackSpecialistSend()
    {
        var manager = _context.Managers
            .Include(m => m.WaitingForRegistrationApprove)
            .Include(m => m.WaitingForInstallmentPlanApprove)
            .Include(m => m.WaitingForCreditApprove)
            .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;

        return View(new ManagerRollBackSpecialistSendModel
        {
            Manager = manager
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackSpecialistSend(ManagerRollBackSpecialistSendModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.IdOfSelectedRequest != null)
            {
                var manager = _context.Managers
                    .Include(m => m.WaitingForRegistrationApprove)
                    .Include(m => m.WaitingForInstallmentPlanApprove)
                    .Include(m => m.WaitingForCreditApprove)
                    .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
                    .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;

                var bankOperator = _context.Operators
                    .Include(o => o.ClientsWaitingForSalaryProject)
                    .FirstAsync(o => o.BankId == manager.BankId && o.RoleId == 7)
                    .Result;

                var tmpBank = _context.Banks.FirstOrDefault(b => b.Id == bankOperator.BankId);

                var specialist = _context.Specialists
                    .Include(s => s.ClientsToPaymentProject)
                    .Include(s => s.Company)
                    .FirstOrDefaultAsync(o => o.Company!.BankIdentificationCode == tmpBank!.BankIdentificationCode).Result;

                var listToRollback = new SpecialistSendClients();

                foreach (var list in manager.SendClientsList!)
                {
                    if (list.Id == model.IdOfSelectedRequest)
                    {
                        listToRollback = list;
                        break;
                    }
                }


                bankOperator.ClientsWaitingForSalaryProject!.Remove(listToRollback.Client);
                specialist!.ClientsToPaymentProject!.Add(listToRollback.Client);

                manager.SendClientsList.Remove(listToRollback);

                _context.Managers.Update(manager);
                _context.Operators.Update(bankOperator);
                _context.Specialists.Update(specialist!);

                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Manager");
            }
        }

        var manager1 = _context.Managers
             .Include(m => m.WaitingForRegistrationApprove)
             .Include(m => m.WaitingForInstallmentPlanApprove)
             .Include(m => m.WaitingForCreditApprove)
             .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
             .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;

        return View(new ManagerRollBackSpecialistSendModel
        {
            Manager = manager1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackSpecialistAddedMoney()
    {
        var manager = _context.Managers
            .Include(m => m.WaitingForRegistrationApprove)
            .Include(m => m.WaitingForInstallmentPlanApprove)
            .Include(m => m.WaitingForCreditApprove)
            .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
            .Include(m => m.SpecialistAddedMonies)!.ThenInclude(c => c.Client)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;

        return View(new ManagerRollBackSpecialistAddedMoneyModel
        {
            Manager = manager
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackSpecialistAddedMoney(ManagerRollBackSpecialistAddedMoneyModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.IdOfClientRequest != 0)
            {
                var manager = _context.Managers
                    .Include(m => m.WaitingForRegistrationApprove)
                    .Include(m => m.WaitingForInstallmentPlanApprove)
                    .Include(m => m.WaitingForCreditApprove)
                    .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
                    .Include(m => m.SpecialistAddedMonies)!.ThenInclude(c => c.Client)
                    .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;


                var listToRollback = new SpecialistAddedMoney();

                foreach (var list in manager.SpecialistAddedMonies!)
                {
                    if (list.Id == model.IdOfClientRequest)
                    {
                        listToRollback = list;
                        break;
                    }
                }

                var client = _context.Clients.FirstOrDefaultAsync(c => c.Id == listToRollback.Client.Id).Result;
                client!.BankBalance -= 10000;
                manager.SpecialistAddedMonies.Remove(listToRollback);
                _context.Managers.Update(manager);
                _context.Clients.Update(client);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Manager");
            }

        }
        var manager1 = _context.Managers
             .Include(m => m.WaitingForRegistrationApprove)
             .Include(m => m.WaitingForInstallmentPlanApprove)
             .Include(m => m.WaitingForCreditApprove)
             .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
             .Include(m => m.SpecialistAddedMonies)!.ThenInclude(c => c.Client)
             .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;

        return View(new ManagerRollBackSpecialistAddedMoneyModel
        {
            Manager = manager1
        });
    }
}