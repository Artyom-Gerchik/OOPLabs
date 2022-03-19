using LAB1.Data;
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
                WaitingForRegistrationApprove = new List<Client>()
            };

            if (model.SelectedBankId != null)
            {
                var bank = await _context.Banks.FirstOrDefaultAsync(b =>
                    b.Id.ToString().Equals(model.SelectedBankId.ToString()));
                bank.AmountOfManagers++;
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
        var manager = _context.Managers.Include(m => m.WaitingForRegistrationApprove)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
        var clientsToApprove = manager.WaitingForRegistrationApprove;


        return View(new ManagerApproveModel
        {
            ClientsToApprove = clientsToApprove
        });
    }

    [HttpPost]
    [Authorize(Roles = "manager")]
    public async Task<IActionResult> Approve(ManagerApproveModel model)
    {
        if (ModelState.IsValid)
        {
            var client =
                _context.Clients.Include(c => c.BanksAndApproves).ThenInclude(c => c.Bank)
                    .FirstOrDefault(u => u.Id == model.IdOfApprovedClient)!;
            var manager = _context.Managers.Include(m => m.WaitingForRegistrationApprove)
                .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
            if (client != null)
            {
                foreach (var banks in client.BanksAndApproves)
                    if (banks.Bank!.Id == manager.BankId)
                        banks.Approved = true;

                manager.WaitingForRegistrationApprove.Remove(client);
                _context.Clients.Update(client);
                _context.Managers.Update(manager);
                await _context.SaveChangesAsync();
            }
        }

        return RedirectToAction("Profile", "Manager");
    }


    [HttpGet]
    [Authorize(Roles = "manager")]
    public IActionResult Profile()
    {
        var manager = _context.Managers.Include(m => m.WaitingForRegistrationApprove)
            .FirstAsync(m => m.Email.Equals(User.Identity.Name));

        return View(new ManagerProfileModel
        {
            Manager = manager.Result
        });
    }
}