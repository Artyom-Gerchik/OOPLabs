using LAB1.Data;
using LAB1.Entities.UserCategories;
using LAB1.Models.Operator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class OperatorController : Controller
{
    private readonly ApplicationDbContext _context;

    public OperatorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Operator GetOperator()
    {
        var bankOperator = _context.Operators
            .Include(o => o.ClientsWaitingForSalaryProject)
            .FirstOrDefaultAsync(o => o.Email.Equals(User.Identity.Name)).Result;

        return bankOperator!;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        var bankOperator = GetOperator();
        return View(new OperatorProfileModel()
        {
            Operator = bankOperator
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new OperatorAdditionalInfoModel
        {
            Banks = _context.Banks.ToList()
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAdditionalInfo(OperatorAdditionalInfoModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(User.Identity.Name)).Result;
            var operatorRole = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == "operator"))!;

            var bankOperator = new Operator
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Role = operatorRole,
                BankId = model.SelectedBankId,
                ClientsWaitingForSalaryProject = new List<Client>()
            };

            if (model.SelectedBankId != null)
            {
                var bank = await _context.Banks.FirstOrDefaultAsync(b =>
                    b.Id.ToString().Equals(model.SelectedBankId.ToString()));
                bank!.AmountOfOperators++;
            }

            if (bankOperator != null)
            {
                _context.Users.Remove(user);
                _context.Operators.Add(bankOperator);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Operator");
            }
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Approve()
    {
        var bankOperator = GetOperator();
        return View(new OperatorApproveModel()
        {
            Clients = bankOperator.ClientsWaitingForSalaryProject
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Approve(OperatorApproveModel model)
    {
        if (ModelState.IsValid)
        {
            var bankOperator = GetOperator();
            foreach (var client in bankOperator.ClientsWaitingForSalaryProject!)
            {
                client.AtSalaryProject = true;
                _context.Clients.Update(client);
            }

            bankOperator.ClientsWaitingForSalaryProject.Clear();

            _context.Operators.Update(bankOperator);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Profile", "Operator");
    }
}