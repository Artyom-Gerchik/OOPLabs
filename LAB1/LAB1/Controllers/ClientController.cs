using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models;
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
    public async Task<IActionResult> GetAdditionalInfo(ClientModel model)
    {
        if (ModelState.IsValid)
        {
            User user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
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
                Role = _context.Roles.ToList()[(int)user.RoleId - 1],
                IdentificationNumber = model.IdentificationNumber,
                PassportNumberAndSeries = model.PassportNumberAndSeries
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
        return View(new ClientModel()
        {
            Client = _context.Clients.FirstOrDefault(c => c.Email.Equals(User.Identity.Name)),
        });
    }
}