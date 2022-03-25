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
            .Include(a => a.Transfers)!.ThenInclude(c => c.Transfer)
            .Include(a => a.Transfers)!.ThenInclude(c => c.BankAccountWhereWithdrawed)
            .Include(a => a.Transfers)!.ThenInclude(c => c.BankAccountToDeposited)
            .Include(a => a.OpennedDepositsToRollBack)!.ThenInclude(c => c.BankDeposit)
            .Include(a => a.OpennedDepositsToRollBack)!.ThenInclude(c => c.Client)
            .FirstOrDefaultAsync(a => a.Email.Equals(User.Identity.Name)).Result;
        return administrator!;
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

            var admin = new Administrator()
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
                DeletedBankAccounts = new List<DeletedBankAccount>()
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

        return View(model);
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

        return View(model);
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
            var admin = GetAdministrator();
            var transferToRollBack = new Transfer();
            var rollbackTransfer = new RollBackTransferBetweenBankAccounts();

            foreach (var transfer in admin.Transfers!)
            {
                if (transfer.Transfer.Id == model.SelectedTransferId)
                {
                    transferToRollBack = transfer.Transfer;
                    break;
                }
            }

            foreach (var transfer in admin.Transfers!)
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

            admin.Transfers.Remove(rollbackTransfer);

            _context.Administrators.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Administrator");
        }

        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackBankDepositOpening()
    {
        var admin = GetAdministrator();
        return View(new AdministratorRollBackBankDepositOpening()
        {
            Administrator = admin
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackBankDepositOpening(AdministratorRollBackBankDepositOpening model)
    {
        if (ModelState.IsValid)
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

        return View();
    }
}