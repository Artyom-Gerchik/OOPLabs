using System.Security.Claims;
using LAB1.Data;
using LAB1.Models;
using LAB1.Entities.UserCategories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult Profile()
    {
        return View(new RoleModel() { Roles = _context.Roles.ToList() });
    }

    [HttpPost]
    public async Task<IActionResult> Profile(RoleModel model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name));

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

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = (await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email))!;
            if (user == null)
            {
                if (model.PhoneNumber.Length < 6) return RedirectToAction("Register", "Account");

                user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    PhoneNumber = model.PhoneNumber
                    //IdentificationNumber = model.IdentificationNumber,
                    //SeriesAndPassportNumber = model.SeriesAndPassportNumber
                };
                var userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                if (userRole != null) user.Role = userRole;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                await Authenticate(user);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
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
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                await Authenticate(user);
                //await HttpContext.SignInAsync();
                return RedirectToAction("Profile", "Account");
            }

            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }

        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("Index", "Home");
    }

    private async Task Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
        };
        var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}