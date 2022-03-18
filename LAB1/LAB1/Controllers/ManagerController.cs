using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models;
using LAB1.Models.Client;
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
        return View(new ManagerAdditionalInfoModel()
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
            User user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            Role managerRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "manager"))!;

            Manager manager = new Manager
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
                Bank bank = await _context.Banks.FirstOrDefaultAsync(b =>
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
        List<Client> clientsToApprove = manager.WaitingForRegistrationApprove;


        return View(new ManagerApproveModel()
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
            Client client =
                _context.Clients.FirstOrDefault(u => u.Id == model.IdOfApprovedClient)!;
            var manager = _context.Managers.Include(m => m.WaitingForRegistrationApprove)
                .FirstAsync(m => m.Email.Equals(User.Identity.Name)).Result;
            if (client != null)
            {
                foreach (var banks in client.BanksAndApproves)
                {
                    if (banks.Bank!.Id == manager.BankId)
                    {
                        banks.Approved = true;
                    }
                }

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

        return View(new ManagerProfileModel()
        {
            //Manager = _context.Managers.FirstOrDefault(c => c.Id.ToString().Equals(2.ToString()))!,
            Manager = manager.Result,
        });
    }
}