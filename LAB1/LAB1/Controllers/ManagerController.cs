using LAB1.Data;
using LAB1.Models;
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

    [HttpGet]
    [Authorize]
    public IActionResult GetBank()
    {
        return View(new ManagerGetBankModel()
        {
            Banks = _context.Banks.ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> GetBank(ManagerGetBankModel model)
    {
        var manager = await _context.Managers.FirstOrDefaultAsync(m => m.Email.Equals(User.Identity.Name));

        if (model.SelectedBankId != null)
        {
            if (manager != null)
            {
                manager.BankId = model.SelectedBankId;
                _context.Managers.Update(manager);
            }

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Profile", "Manager");
    }

    [HttpGet]
    [Authorize(Roles = "manager")]
    public IActionResult Profile()
    {
        return View(new ManagerProfileModel()
        {
            Manager = _context.Managers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name)),
        });
    }
}