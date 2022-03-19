using LAB1.Data;
using LAB1.Entities;
using LAB1.Models.Bank;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class BankController : Controller
{
    private readonly ApplicationDbContext _context;

    public BankController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult BankProfileForClient()
    {
        var client = _context.Clients
            .Include(c => c.Banks)
            .Include(c => c.OpennedBankAccounts)
            .Include(c => c.BanksAndApproves)!
            .ThenInclude(c => c.Bank)
            .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;

        var bank = client.Banks![(int)client.CurrentBankId - 1];


        return View(new BankProfileModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult OpenBankAccountForClient()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> OpenBankAccountForClient(OpenBankAccountForClientModel model)
    {
        if (ModelState.IsValid)
        {
            var client = _context.Clients
                .Include(c => c.Banks)!
                .ThenInclude(c => c.OpennedBankAccounts)
                .Include(c => c.OpennedBankAccounts)
                .Include(c => c.BanksAndApproves)!
                .ThenInclude(c => c.Bank)
                .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;

            var bank = _context.Banks
                .Include(b => b.OpennedBankAccounts)
                .FirstAsync(b => b.Id == client.CurrentBankId).Result;

            var bankAccount = new BankAccount
            {
                ClientId = client.Id,
                BankId = bank.Id,
                AmountOfMoney = model.InitiallAmountOfMoney,
                Name = model.Name
            };

            client.OpennedBankAccounts!.Add(bankAccount);
            bank.OpennedBankAccounts!.Add(bankAccount);

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult CloseBankAccountForClient()
    {
        var client = _context.Clients
            .Include(c => c.Banks)!
            .ThenInclude(c => c.OpennedBankAccounts)
            .Include(c => c.OpennedBankAccounts)
            .Include(c => c.BanksAndApproves)!
            .ThenInclude(c => c.Bank)
            .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;
        var bank = client.Banks![(int)client.CurrentBankId - 1];


        return View(new CloseBankAccountForClientModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CloseBankAccountForClient(CloseBankAccountForClientModel model)
    {
        if (ModelState.IsValid)
        {
            var client = _context.Clients
                .Include(c => c.Banks)!
                .ThenInclude(c => c.OpennedBankAccounts)
                .Include(c => c.OpennedBankAccounts)
                .Include(c => c.BanksAndApproves)!
                .ThenInclude(c => c.Bank)
                .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;

            var bank = _context.Banks
                .Include(b => b.OpennedBankAccounts)
                .FirstAsync(b => b.Id == client.CurrentBankId).Result;

            var bankAccountToRemove = new BankAccount();
            foreach (var bankAccount in client.OpennedBankAccounts)
                if (bankAccount.Id == model.IdOfBankAccountToClose)
                {
                    bankAccountToRemove = bankAccount;
                    break;
                }

            client.OpennedBankAccounts.Remove(bankAccountToRemove);
            bank.OpennedBankAccounts?.Remove(bankAccountToRemove);

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }
}