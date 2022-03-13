using System.Security.Claims;
using LAB1.Data;
using LAB1.Entities;
using LAB1.Models;
using LAB1.Entities.UserCategories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LAB1.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Profile()
    {
        return View(new RoleModel() { Roles = _context.Roles.ToList() });
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Profile(RoleModel model)
    {
        User user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name));

        if (model.IdOfSelectedRole != null)
        {
            if (user != null)
            {
                user.RoleId = model.IdOfSelectedRole;
                _context.Users.Update(user);
            }

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Profile", "Account");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Register", "Account");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            User user = (await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email))!;
            if (user == null)
            {
                if (model.PhoneNumber.Length < 6)
                {
                    return RedirectToAction("Register", "Account");
                }

                user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    PhoneNumber = model.PhoneNumber,
                    //IdentificationNumber = model.IdentificationNumber,
                    //SeriesAndPassportNumber = model.SeriesAndPassportNumber
                };
                Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                if (userRole != null)
                {
                    user.Role = userRole;
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                await Authenticate(user);

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                await Authenticate(user);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }

        return View(model);
    }

    private async Task Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
        };
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}