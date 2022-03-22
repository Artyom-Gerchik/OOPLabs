using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models.Client;
using LAB1.Models.Specialist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LAB1.Controllers;

public class SpecialistController : Controller
{
    private readonly ApplicationDbContext _context;

    public SpecialistController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Specialist GetSpecialist()
    {
        var specialist = _context.Specialists
            .Include(s => s.ClientsToPaymentProject)
            .Include(s => s.Company)
            .FirstOrDefaultAsync(s => s.Email.Equals(User.Identity.Name)).Result;
        return specialist!;
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new SpecialistGetAdditionalInfoModel()
        {
            Companies = _context.Companies.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(SpecialistGetAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            var role = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "specialist"))!;
            var selectedCompany = _context.Companies.FirstOrDefaultAsync(c => c.Id == model.IdOfSelectedCompany).Result;

            var specialist = new Specialist()
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
                Company = selectedCompany,
                CompanyId = selectedCompany!.Id,
                ClientsToPaymentProject = new List<Client>()
            };
            if (specialist != null)
            {
                _context.Users.Remove(user);
                _context.Specialists.Add(specialist);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Profile", "Specialist");
        }

        return View(model);
    }


    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var specialist = GetSpecialist();
        return View(new SpecialistProfileModel()
        {
            Specialist = specialist
        });
    }
}