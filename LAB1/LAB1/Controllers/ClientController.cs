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
                CurrentBankId = 0,
                BanksAndApproves = new List<BankApproves>(),
                BankBalance = 1000.0,
                Banks = new List<Bank>(),
                OpennedBankAccounts = new List<BankAccount>()
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
    [Authorize]
    public IActionResult Profile()
    {
        return View(new ClientProfileModel()
        {
            Banks = _context.Banks.ToList(),
            Client = _context.Clients
                .Include(c => c.Banks).Include(c => c.OpennedBankAccounts).Include(c => c.BanksAndApproves)
                .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result
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
            var client = _context.Clients.Include(c => c.Banks).Include(c => c.OpennedBankAccounts)
                .Include(c => c.BanksAndApproves)
                .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            if (client != null)
            {
                if (model.SelectedBankId != null)
                {
                    Bank bank = await _context.Banks.FirstOrDefaultAsync(b =>
                        b.Id.ToString().Equals(model.SelectedBankId));
                    client.BanksAndApproves.Add(new BankApproves(bank!, false));
                    client.CurrentBankId = bank!.Id;
                    client.Banks!.Add(bank);
                    bank.AmountOfClients++;
                    _context.Clients.Update(client);
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
        var client = _context.Clients.Include(c => c.Banks).Include(c => c.OpennedBankAccounts)
            .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;
        List<Manager> managers = new List<Manager>();
        foreach (var manager in _context.Managers)
        {
            if (manager.BankId == client.CurrentBankId)
            {
                managers.Add(manager);
            }
        }

        return View(new ClientGetApproveModel()
        {
            Managers = managers
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
                    var manager = _context.Managers.Include(m => m.WaitingForRegistrationApprove)
                        .FirstAsync(m => m.Id == model.IdOfSelectedManager).Result;
                    if (!manager.WaitingForRegistrationApprove.Contains(client))
                    {
                        manager.WaitingForRegistrationApprove.Add(client);
                        _context.Managers.Update(manager);
                        await _context.SaveChangesAsync();

                        Manager test = ((await _context.Managers.FirstOrDefaultAsync(m =>
                            m.Id == model.IdOfSelectedManager))!);
                    }
                }
            }

            return RedirectToAction("Profile", "Account");
        }

        return View();
    }
}