using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.AdminRollBack;
using LAB1.Entities.UserCategories;
using LAB1.Models.Administrator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class AdministratorController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdministratorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Administrator GetAdministrator()
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
            .FirstOrDefaultAsync(a => a.Email.Equals(User.Identity.Name)).Result;
        return administrator!;
    }

    public Client GetClient(int? id)
    {
        var client = _context.Clients
            .Include(c => c.Banks)!.ThenInclude(c => c.OpennedBankAccounts)
            .Include(c => c.OpennedBankAccounts)
            .Include(c => c.BanksAndApproves)!.ThenInclude(c => c.Bank)
            .Include(c => c.OpennedBankDeposits)
            .Include(c => c.InstallmentPlansAndApproves)!.ThenInclude(c => c.Bank)
            .Include(c => c.InstallmentPlansAndApproves)!.ThenInclude(c => c.InstallmentPlan)
            .Include(c => c.CreditsAndApproves)!.ThenInclude(c => c.Credit)
            .FirstAsync(u => u.Id == id).Result;
        return client;
    }

    public Operator GetOperator(Administrator administrator)
    {
        var bankOperator = _context.Operators.Include(o => o.ClientsWaitingForSalaryProject)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.Transfer)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountWhereWithdrawed)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountToDeposited)
            .FirstOrDefaultAsync(a => a.BankId == administrator.BankId && a.RoleId == 7).Result;
        return bankOperator!;
    }


    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var admin = GetAdministrator();

        return View(new AdministratorProfileModel
        {
            Administrator = admin
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new AdministratorGetAdditionalInfoModel
        {
            Banks = _context.Banks.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(AdministratorGetAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            var role = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "administrator"))!;
            var selectedBank = _context.Banks.FirstOrDefaultAsync(b => b.Id == model.SelectedBankId).Result;

            var admin = new Administrator() // need to add all additional lists
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Role = role,
                BankId = selectedBank!.Id,
                OpennedBankAccounts = new List<OpennedBankAccount>(),
                DeletedBankAccounts = new List<DeletedBankAccount>(),
                TransfersBetweenBankAccounts = new List<RollBackTransferBetweenBankAccounts>(),
            };
            if (admin != null)
            {
                selectedBank.AmountOfAdministrators++;
                _context.Users.Remove(user);
                _context.Administrators.Add(admin);
                _context.Banks.Update(selectedBank);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Profile", "Administrator");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackOpenedBankAccount()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackOpenedBankAccountModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackOpenedBankAccount(AdministratorRollBackOpenedBankAccountModel model)
    {
        var admin = GetAdministrator();
        var accountToRemove = new OpennedBankAccount();

        if (ModelState.IsValid)
        {
            if (model.SelectedBankAccountId != null)
            {
                foreach (var bankAccount in admin.OpennedBankAccounts!)
                {
                    if (bankAccount.BankAccount!.Id == model.SelectedBankAccountId)
                    {
                        accountToRemove = bankAccount;
                        break;
                    }
                }

                var client = GetClient(accountToRemove.BankAccount!.ClientId);

                client.OpennedBankAccounts!.Remove(accountToRemove.BankAccount);
                admin.OpennedBankAccounts.Remove(accountToRemove);

                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackOpenedBankAccountModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackDeletedBankAccount()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackDeletedBankAccountModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackDeletedBankAccount(AdministratorRollBackDeletedBankAccountModel model)
    {
        var admin = GetAdministrator();
        var accountToReturnToClient = new BankAccount();
        var accountToRemoveFromAdmin = new DeletedBankAccount();
        if (ModelState.IsValid)
        {
            if (model.SelectedBankAccountId != null)
            {
                foreach (var bankAccount in admin.DeletedBankAccounts!)
                {
                    if (bankAccount.BankAccount!.Id == model.SelectedBankAccountId)
                    {
                        accountToRemoveFromAdmin = bankAccount;
                        accountToReturnToClient = bankAccount.BankAccount;
                        break;
                    }
                }

                var client = GetClient(accountToReturnToClient.ClientId);

                accountToReturnToClient.Hidden = false;

                admin.DeletedBankAccounts!.Remove(accountToRemoveFromAdmin);
                admin.OpennedBankAccounts!.Add(new OpennedBankAccount(client, accountToReturnToClient));

                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackDeletedBankAccountModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackTransferBetweenBankAccounts()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackTransferModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackTransferBetweenBankAccounts(AdministratorRollBackTransferModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedTransferId != null)
            {
                var admin = GetAdministrator();
                var bankOperator = GetOperator(admin);
                var transferToRollBack = new Transfer();
                var rollbackTransfer = new RollBackTransferBetweenBankAccounts();

                foreach (var transfer in admin.TransfersBetweenBankAccounts!)
                {
                    if (transfer.Transfer.Id == model.SelectedTransferId)
                    {
                        transferToRollBack = transfer.Transfer;
                        break;
                    }
                }

                foreach (var transfer in admin.TransfersBetweenBankAccounts!)
                {
                    if (transfer.Transfer.Equals(transferToRollBack))
                    {
                        rollbackTransfer = transfer;
                        break;
                    }
                }

                var accountWereWithdrawed = rollbackTransfer.BankAccountWhereWithdrawed;
                var accountWereDeposited = rollbackTransfer.BankAccountToDeposited;

                accountWereWithdrawed!.AmountOfMoney += rollbackTransfer.Transfer!.AmountOfMoney;
                accountWereDeposited!.AmountOfMoney -= rollbackTransfer.Transfer!.AmountOfMoney;

                foreach (var rollBackTmp in bankOperator.TransfersBetweenBankAccounts!)
                {
                    if (rollBackTmp.BankAccountWhereWithdrawed!.Equals(rollbackTransfer.BankAccountWhereWithdrawed) &&
                        rollBackTmp.Transfer!.Equals(rollbackTransfer.Transfer))
                    {
                        bankOperator.TransfersBetweenBankAccounts!.Remove(rollBackTmp);
                        break;
                    }
                }

                admin.TransfersBetweenBankAccounts.Remove(rollbackTransfer);


                _context.Administrators.Update(admin);
                _context.Operators.Update(bankOperator);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackTransferModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackBankDepositOpening()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackBankDepositOpeningModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackBankDepositOpening(AdministratorRollBackBankDepositOpeningModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedDepositId != null)
            {
                var admin = GetAdministrator();

                var depositToRollBack = new RollBackOpenedDeposit();

                foreach (var bankDeposit in admin.OpennedDepositsToRollBack!)
                {
                    if (bankDeposit.BankDeposit!.Id == model.SelectedDepositId)
                    {
                        depositToRollBack = bankDeposit;
                        break;
                    }
                }

                var client = GetClient(depositToRollBack.Client!.Id);

                client.BankBalance += depositToRollBack.BankDeposit!.AmountOfMoney;
                client.OpennedBankDeposits!.Remove(depositToRollBack.BankDeposit);
                admin.OpennedDepositsToRollBack!.Remove(depositToRollBack);

                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackBankDepositOpeningModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackBankDepositClosing()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackBankDepositClosingModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackBankDepositClosing(AdministratorRollBackBankDepositClosingModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedDepositId != null)
            {
                var admin = GetAdministrator();
                var depositToRollBack = new RollBackClosedDeposit();

                foreach (var bankDeposit in admin.ClosedDepositsToRollBack!)
                {
                    if (bankDeposit.BankDeposit!.Id == model.SelectedDepositId)
                    {
                        depositToRollBack = bankDeposit;
                        break;
                    }
                }

                var client = GetClient(depositToRollBack.Client!.Id);
                client.BankBalance -= depositToRollBack.BankDeposit!.AmountOfMoney +
                                      depositToRollBack.BankDeposit!.AmountOfMoney *
                                      (depositToRollBack.BankDeposit!.Percent / 100);
                depositToRollBack.BankDeposit.Hidden = false;

                admin.ClosedDepositsToRollBack!.Remove(depositToRollBack);
                admin.OpennedDepositsToRollBack!.Add(new RollBackOpenedDeposit(client, depositToRollBack.BankDeposit));

                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackBankDepositClosingModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackTransferBetweenBankDeposits()
    {
        var admin = GetAdministrator();
        return View(new RollBackTransferBetweenBankDepositsModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackTransferBetweenBankDeposits(RollBackTransferBetweenBankDepositsModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedTransferId != null)
            {
                var admin = GetAdministrator();
                var transferToRollBack = new Transfer();
                var rollbackTransfer = new RollBackTransferBetweenBankDeposits();

                foreach (var transfer in admin.TransfersBetweenBankDeposits!)
                {
                    if (transfer.Transfer!.Id == model.SelectedTransferId)
                    {
                        transferToRollBack = transfer.Transfer;
                        break;
                    }
                }

                foreach (var transfer in admin.TransfersBetweenBankDeposits!)
                {
                    if (transfer.Transfer!.Equals(transferToRollBack))
                    {
                        rollbackTransfer = transfer;
                        break;
                    }
                }

                var depositWereWithdrawed = rollbackTransfer.BankDepositWhereWithdrawed;
                var depositWereDeposited = rollbackTransfer.BankDepositToDeposited;

                depositWereWithdrawed!.AmountOfMoney += rollbackTransfer.Transfer!.AmountOfMoney;
                depositWereDeposited!.AmountOfMoney -= rollbackTransfer.Transfer!.AmountOfMoney;
                depositWereWithdrawed.Hidden = false;

                admin.TransfersBetweenBankDeposits.Remove(rollbackTransfer);
                admin.OpennedDepositsToRollBack!.Add(new RollBackOpenedDeposit(
                    _context.Clients.FirstOrDefaultAsync(c => c.Id == depositWereWithdrawed.ClientId).Result!,
                    depositWereWithdrawed));

                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new RollBackTransferBetweenBankDepositsModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackOpenedInstallmentPlan()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackOpenedInstallmentPlanModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackOpenedInstallmentPlan(
        AdministratorRollBackOpenedInstallmentPlanModel model)
    {
        var admin = GetAdministrator();
        var installmentPlanToRollBack = new RollBackOpennedInstallmentPlan();

        if (ModelState.IsValid)
        {
            if (model.SelectedInstallmentPlanId != null)
            {
                foreach (var installmentPlan in admin.OpennedInstallmentPlans!)
                {
                    if (installmentPlan.InstallmentPlan!.Id == model.SelectedInstallmentPlanId)
                    {
                        installmentPlanToRollBack = installmentPlan;
                        break;
                    }
                }


                var client = GetClient(installmentPlanToRollBack.InstallmentPlan!.ClientId);

                foreach (var instalmentPlan in client.InstallmentPlansAndApproves!)
                {
                    if (instalmentPlan.InstallmentPlan!.Equals(installmentPlanToRollBack.InstallmentPlan))
                    {
                        client.InstallmentPlansAndApproves!.Remove(instalmentPlan);
                        break;
                    }
                }

                client.BankBalance -= installmentPlanToRollBack.InstallmentPlan.AmountOfMoney;
                admin.OpennedInstallmentPlans.Remove(installmentPlanToRollBack);
                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackOpenedInstallmentPlanModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackClosedInstallmentPlan()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackClosedInstallmentPlanModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackClosedInstallmentPlan(
        AdministratorRollBackClosedInstallmentPlanModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedInstallmentPlanId != null)
            {
                var admin = GetAdministrator();
                var installmentPlanToRollBack = new InstallmentPlan();
                var rollBackForAdmin = new RollBackDeletedInstallmentPlan();
                foreach (var installmentPlan in admin.DeletedInstallmentPlans!)
                {
                    if (installmentPlan.InstallmentPlan!.Id == model.SelectedInstallmentPlanId)
                    {
                        installmentPlanToRollBack = installmentPlan.InstallmentPlan;
                        break;
                    }
                }

                foreach (var installmentPlan in admin.DeletedInstallmentPlans!)
                {
                    if (installmentPlan.InstallmentPlan!.Equals(installmentPlanToRollBack))
                    {
                        rollBackForAdmin = installmentPlan;
                        break;
                    }
                }

                var client = GetClient(installmentPlanToRollBack.ClientId);
                client.BankBalance += rollBackForAdmin.Transfer!.AmountOfMoney;
                installmentPlanToRollBack.Hidden = false;
                admin.OpennedInstallmentPlans!.Add(new RollBackOpennedInstallmentPlan(client, installmentPlanToRollBack));
                admin.DeletedInstallmentPlans.Remove(rollBackForAdmin);

                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackClosedInstallmentPlanModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackOpenedCredit()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackOpenedCreditModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackOpenedCredit(
        AdministratorRollBackOpenedCreditModel model)
    {
        var admin = GetAdministrator();
        var creditToRollBack = new RollBackOpennedCredit();

        if (ModelState.IsValid)
        {
            if (model.SelectedCreditId != null)
            {
                foreach (var credit in admin.OpennedCredits!)
                {
                    if (credit.Credit!.Id == model.SelectedCreditId)
                    {
                        creditToRollBack = credit;
                        break;
                    }
                }


                var client = GetClient(creditToRollBack.Credit!.ClientId);

                foreach (var credit in client.CreditsAndApproves!)
                {
                    if (credit.Credit!.Equals(creditToRollBack.Credit))
                    {
                        client.CreditsAndApproves!.Remove(credit);
                        break;
                    }
                }

                client.BankBalance -= creditToRollBack.Credit.AmountOfMoney;
                admin.OpennedCredits!.Remove(creditToRollBack);
                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackOpenedCreditModel()
        {
            Administrator = admin1
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackClosedCredit()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackClosedCreditModel()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackClosedCredit(AdministratorRollBackClosedCreditModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedCreditId != null)
            {
                var admin = GetAdministrator();
                var creditToRollBack = new Credit();
                var rollBackForAdmin = new RollBackDeletedCredit();
                foreach (var credit in admin.DeletedCredits!)
                {
                    if (credit.Credit!.Id == model.SelectedCreditId)
                    {
                        creditToRollBack = credit.Credit;
                        break;
                    }
                }

                foreach (var credit in admin.DeletedCredits!)
                {
                    if (credit.Credit!.Equals(creditToRollBack))
                    {
                        rollBackForAdmin = credit;
                        break;
                    }
                }

                var client = GetClient(creditToRollBack.ClientId);
                client.BankBalance += rollBackForAdmin.Transfer!.AmountOfMoney +
                                      rollBackForAdmin.Transfer!.AmountOfMoney * (rollBackForAdmin.Credit!.Percent / 100);
                creditToRollBack.Hidden = false;
                admin.OpennedCredits!.Add(new RollBackOpennedCredit(client, creditToRollBack));
                admin.DeletedCredits.Remove(rollBackForAdmin);

                _context.Clients.Update(client);
                _context.Administrators.Update(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Administrator");
            }
        }

        var admin1 = GetAdministrator();
        return View(new AdministratorRollBackClosedCreditModel()
        {
            Administrator = admin1
        });
    }
}