using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models;
using LAB1.Models.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class ClientController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(ClientAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            User user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            Role clientRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "client"))!;

            Client client = new Client
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Role = clientRole,
                IdentificationNumber = model.IdentificationNumber,
                PassportNumberAndSeries = model.PassportNumberAndSeries,
                BankId = 0,
                ApprovedByManager = false
            };

            if (client != null)
            {
                _context.Users.Remove(user);
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Client");
            }
        }

        return View(model);
    }

    [HttpGet]
    [Authorize(Roles = "client")]
    public IActionResult Profile()
    {
        return View(new ClientProfileModel()
        {
            Client = _context.Clients.FirstOrDefault(c => c.Email.Equals(User.Identity.Name)),
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult ChooseTheBank()
    {
        return View(new BanksModel()
        {
            Banks = _context.Banks.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChooseTheBank(BanksModel model)
    {
        if (ModelState.IsValid)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name));

            if (client != null)
            {
                if (model.SelectedBankId != null)
                {
                    Bank bank = await _context.Banks.FirstOrDefaultAsync(b =>
                        b.Id.ToString().Equals(model.SelectedBankId));
                    client.BankId = bank.Id;
                    bank.AmountOfClients++;
                    _context.Users.Update(client);
                    _context.Banks.Update(bank);
                }
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("Profile", "Account");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult RequestApprove()
    {
        return View(new ClientGetApproveModel()
        {
            Managers = _context.Managers.ToList(),
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RequestApprove(ClientGetApproveModel model)
    {
        if (ModelState.IsValid)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name));

            if (client != null)
            {
                if (model.IdOfSelectedManager != null)
                {
                    Manager manager = await _context.Managers.FirstOrDefaultAsync(m =>
                        m.Id.ToString().Equals(model.IdOfSelectedManager.ToString()));
                    if (!manager.WaitingForRegistrationApprove.Contains(client))
                    {
                        manager?.WaitingForRegistrationApprove.Add(client);
                        _context.Managers.Update(manager!);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToAction("Profile", "Account");
        }

        return View();
    }
}