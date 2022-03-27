using LAB1.Data;
using LAB1.Entities.ManagerRollBack;
using LAB1.Entities.UserCategories;
using LAB1.Models.Specialist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            .Include(s => s.Company).ThenInclude(c => c.Workers)
            .FirstOrDefaultAsync(s => s.Email.Equals(User.Identity.Name)).Result;
        return specialist!;
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetAdditionalInfo()
    {
        return View(new SpecialistGetAdditionalInfoModel
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

            var specialist = new Specialist
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

        return View(new SpecialistProfileModel
        {
            Specialist = specialist
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult SendRequestForSalaryProject()
    {
        var specialist = GetSpecialist();
        return View(new SendRequestForSalaryProjectModel
        {
            Clients = specialist.ClientsToPaymentProject
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SendRequestForSalaryProject(SendRequestForSalaryProjectModel model)
    {
        if (ModelState.IsValid)
        {
            var specialist = GetSpecialist();
            var bankId = 0;


            foreach (var bank in _context.Banks)
                if (bank.BankIdentificationCode == specialist.Company!.BankIdentificationCode)
                {
                    bankId = (int)bank.Id!;
                    break;
                }

            var manager = _context.Managers
                .Include(m => m.WaitingForRegistrationApprove)
                .Include(m => m.WaitingForInstallmentPlanApprove)
                .Include(m => m.WaitingForCreditApprove)
                .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
                .FirstAsync(o => o.BankId == bankId && o.RoleId == 6).Result;

            var bankOperator = _context.Operators
                .Include(o => o.ClientsWaitingForSalaryProject)
                .FirstAsync(o => o.BankId == bankId && o.RoleId == 7)
                .Result;

            bankOperator.ClientsWaitingForSalaryProject!.Clear(); ////////////

            foreach (var item in specialist.ClientsToPaymentProject!)
            {
                manager.SendClientsList!.Add(new SpecialistSendClients(item));
            }

            bankOperator.ClientsWaitingForSalaryProject!.AddRange(specialist.ClientsToPaymentProject!);
            specialist.ClientsToPaymentProject!.Clear();

            _context.Specialists.Update(specialist);
            _context.Operators.Update(bankOperator);
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Specialist");
        }

        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult GiveMoneyForWorker()
    {
        var spec = GetSpecialist();
        return View(new GiveMoneyForWorkerModel()
        {
            Specialist = spec
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GiveMoneyForWorker(GiveMoneyForWorkerModel model)
    {
        if (ModelState.IsValid)
        {
            var specialist = GetSpecialist();
            var client = _context.Clients.FirstOrDefaultAsync(c => c.Id == model.IdOfWorkerToGiveMoney).Result;
            var bankId = 0;

            foreach (var bank in _context.Banks)
                if (bank.BankIdentificationCode == specialist.Company!.BankIdentificationCode)
                {
                    bankId = (int)bank.Id!;
                    break;
                }

            var manager = _context.Managers
                .Include(m => m.WaitingForRegistrationApprove)
                .Include(m => m.WaitingForInstallmentPlanApprove)
                .Include(m => m.WaitingForCreditApprove)
                .Include(m => m.SendClientsList)!.ThenInclude(c => c.Client)
                .Include(m=>m.SpecialistAddedMonies)!.ThenInclude(c=>c.Client)
                .FirstAsync(o => o.BankId == bankId && o.RoleId == 6).Result;

            client!.BankBalance += 10000;

            manager.SpecialistAddedMonies!.Add(new SpecialistAddedMoney(client));

            _context.Clients.Update(client);
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Specialist");
        }

        return View();
    }
}