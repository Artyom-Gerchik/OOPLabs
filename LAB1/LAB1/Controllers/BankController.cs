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

        var bank = client.Banks![((int)client.CurrentBankId - 1)];


        return View(new BankProfileModel()
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
}