using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.AdminRollBack;
using LAB1.Entities.UserCategories;
using LAB1.Models.Operator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class OperatorController : Controller
{
    private readonly ApplicationDbContext _context;

    public OperatorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Operator GetOperator()
    {
        var bankOperator = _context.Operators
            .Include(o => o.ClientsWaitingForSalaryProject)
            .Include(o => o.TransfersBetweenBankAccounts)!.ThenInclude(c => c.Transfer)
            .Include(o => o.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountWhereWithdrawed)
            .Include(o => o.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountToDeposited)
            .FirstOrDefaultAsync(o => o.Email.Equals(User.Identity.Name)).Result;

        return bankOperator!;
    }

    public Administrator GetAdministrator(Operator bankOperator)
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
            .FirstOrDefaultAsync(a => a.BankId == bankOperator.BankId).Result;
        return administrator!;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var bankOperator = GetOperator();
        return View(new OperatorProfileModel
        {
            Operator = bankOperator
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new OperatorAdditionalInfoModel
        {
            Banks = _context.Banks.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(OperatorAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            var operatorRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "operator"))!;

            var bankOperator = new Operator
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Role = operatorRole,
                BankId = model.SelectedBankId,
                ClientsWaitingForSalaryProject = new List<Client>(),
                TransfersBetweenBankAccounts = new List<RollBackTransferBetweenBankAccounts>()
            };

            if (model.SelectedBankId != null)
            {
                var bank = await _context.Banks.FirstOrDefaultAsync(b =>
                    b.Id.ToString().Equals(model.SelectedBankId.ToString()));
                bank!.AmountOfOperators++;
            }

            if (bankOperator != null)
            {
                _context.Users.Remove(user);
                _context.Operators.Add(bankOperator);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Operator");
            }
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Approve()
    {
        var bankOperator = GetOperator();
        return View(new OperatorApproveModel
        {
            Clients = bankOperator.ClientsWaitingForSalaryProject
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Approve(OperatorApproveModel model)
    {
        if (ModelState.IsValid)
        {
            var bankOperator = GetOperator();
            foreach (var client in bankOperator.ClientsWaitingForSalaryProject!)
            {
                client.AtSalaryProject = true;
                _context.Clients.Update(client);
            }

            bankOperator.ClientsWaitingForSalaryProject.Clear();

            _context.Operators.Update(bankOperator);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Profile", "Operator");
    }

    [HttpGet]
    [Authorize]
    public IActionResult RollBackTransferBetweenBankAccounts()
    {
        var bankOperator = GetOperator();
        return View(new OperatorRollBackTransferModel()
        {
            Operator = bankOperator
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RollBackTransferBetweenBankAccounts(OperatorRollBackTransferModel model)
    {
        if (ModelState.IsValid)
        {
            var bankOperator = GetOperator();
            var admin = GetAdministrator(bankOperator);

            var transferToRollBack = new Transfer();
            var rollbackTransfer = new RollBackTransferBetweenBankAccounts();

            foreach (var transfer in bankOperator.TransfersBetweenBankAccounts!)
            {
                if (transfer.Transfer.Id == model.SelectedTransferId)
                {
                    transferToRollBack = transfer.Transfer;
                    break;
                }
            }

            foreach (var transfer in bankOperator.TransfersBetweenBankAccounts!)
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

            foreach (var rollBackTmp in admin.TransfersBetweenBankAccounts!)
            {
                if (rollBackTmp.BankAccountWhereWithdrawed!.Equals(rollbackTransfer.BankAccountWhereWithdrawed) &&
                    rollBackTmp.Transfer!.Equals(rollbackTransfer.Transfer))
                {
                    admin.TransfersBetweenBankAccounts!.Remove(rollBackTmp);
                    break;
                }
            }


            bankOperator.TransfersBetweenBankAccounts!.Remove(rollbackTransfer);

            _context.Administrators.Update(admin);
            _context.Operators.Update(bankOperator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Operator");
        }

        return View();
    }
}