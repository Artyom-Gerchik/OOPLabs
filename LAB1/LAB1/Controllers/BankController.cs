using LAB1.Data;
using LAB1.Entities;
using LAB1.Entities.AdminRollBack;
using LAB1.Entities.UserCategories;
using LAB1.Models.Bank;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers;

public class BankController : Controller
{
    private readonly ApplicationDbContext _context;

    private int _idForTransfer = 0;

    public BankController(ApplicationDbContext context)
    {
        _context = context;
    }

    public Client GetClient()
    {
        var client = _context.Clients
            .Include(c => c.Banks)!
            .ThenInclude(c => c.OpennedBankAccounts)
            .Include(c => c.OpennedBankAccounts)
            .Include(c => c.BanksAndApproves)!
            .ThenInclude(c => c.Bank)
            .Include(c => c.OpennedBankDeposits)
            .Include(c => c.InstallmentPlansAndApproves)!
            .ThenInclude(c => c.Bank)
            .Include(c => c.InstallmentPlansAndApproves)!
            .ThenInclude(c => c.InstallmentPlan)
            .Include(c => c.CreditsAndApproves)!
            .ThenInclude(c => c.Credit)
            .FirstAsync(u => u.Email.Equals(User.Identity.Name)).Result;
        return client;
    }

    public Bank GetBank(Client client)
    {
        var bank = _context.Banks
            .Include(b => b.OpennedBankAccounts)
            .Include(b => b.OpennedBankDeposits)
            .Include(b => b.OpennedInstallmentPlans)
            .Include(b => b.OpennedCredits)
            .FirstAsync(b => b.Id == client.CurrentBankId).Result;
        return bank;
    }

    public Administrator GetAdministrator(Client client)
    {
        var administrator = _context.Administrators
            .Include(a => a.OpennedBankAccounts)!.ThenInclude(c => c.Client)
            .Include(a => a.OpennedBankAccounts)!.ThenInclude(c => c.BankAccount)
            .Include(a => a.DeletedBankAccounts)!.ThenInclude(c => c.Client)
            .Include(a => a.DeletedBankAccounts)!.ThenInclude(c => c.BankAccount)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.Transfer)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountWhereWithdrawed)
            .Include(a => a.TransfersBetweenBankAccounts)!.ThenInclude(c => c.BankAccountToDeposited)
            .Include(a => a.OpennedDepositsToRollBack)!.ThenInclude(c => c.BankDeposit)
            .Include(a => a.OpennedDepositsToRollBack)!.ThenInclude(c => c.Client)
            .Include(a => a.ClosedDepositsToRollBack)!.ThenInclude(c => c.BankDeposit)
            .Include(a => a.ClosedDepositsToRollBack)!.ThenInclude(c => c.Client)
            .Include(a => a.TransfersBetweenBankDeposits)!.ThenInclude(c => c.Transfer)
            .Include(a => a.TransfersBetweenBankDeposits)!.ThenInclude(c => c.BankDepositWhereWithdrawed)
            .Include(a => a.TransfersBetweenBankDeposits)!.ThenInclude(c => c.BankDepositToDeposited)
            .Include(a => a.OpennedInstallmentPlans)!.ThenInclude(c => c.Client)
            .Include(a => a.OpennedInstallmentPlans)!.ThenInclude(c => c.InstallmentPlan)
            .FirstOrDefaultAsync(a => a.BankId == client.CurrentBankId).Result;
        return administrator!;
    }

    // public void Log(string funcName, Client client, Bank bank, TextWriter w, int bankAccountId)
    // {
    //     if (funcName.Equals("OpenBankAccountForClient"))
    //     {
    //         w.WriteLine($"\r\nLog {funcName}");
    //         w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
    //         w.WriteLine("--------------------------------------------------------------");
    //         w.WriteLine($"ClientId: {client.Id}");
    //         w.WriteLine($"BankId: {bank.Id}");
    //         w.WriteLine($"BankAccountId: {bankAccountId}");
    //         w.WriteLine("--------------------------------------------------------------");
    //     }
    //     else
    //     {
    //         w.WriteLine($"\r\nLog {funcName}");
    //         w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
    //         w.WriteLine("--------------------------------------------------------------");
    //         w.WriteLine($"ClientId: {client.Id}");
    //         w.WriteLine($"BankId: {bank.Id}");
    //         w.WriteLine("--------------------------------------------------------------");
    //     }
    // }

    // await using (StreamWriter w = System.IO.File.AppendText($"ClientLogs/{client.Id}/log.txt"))
    // {
    //     Log("OpenBankAccountForClient", client, bank, w, (int)bankAccount.Id);
    // }


    [HttpGet]
    [Authorize]
    public IActionResult BankProfileForClient()
    {
        var client = GetClient();
        var bank = GetBank(client);
        // var admin = GetAdministrator(client);
        //
        // bank.OpennedBankAccounts!.Clear();
        // client.OpennedBankAccounts!.Clear();
        // admin.OpennedBankAccounts!.Clear();
        // admin.DeletedBankAccounts!.Clear();
        //
        // _context.Banks.Update(bank);
        // _context.Clients.Update(client);
        // _context.Administrators.Update(admin);
        // _context.SaveChangesAsync();


        return View(new BankProfileModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpGet]
    [Authorize]
    public IActionResult OpenBankAccountForClient()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> OpenBankAccountForClient(OpenBankAccountForClientModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var admin = GetAdministrator(client);

            var bankAccount = new BankAccount
            {
                ClientId = client.Id,
                BankId = bank.Id,
                AmountOfMoney = model.InitiallAmountOfMoney,
                Name = model.Name,
                Hidden = false
            };

            client.OpennedBankAccounts!.Add(bankAccount);
            bank.OpennedBankAccounts!.Add(bankAccount);
            admin.OpennedBankAccounts!.Add(new OpennedBankAccount(client, bankAccount));

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult CloseBankAccountForClient()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new CloseBankAccountForClientModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CloseBankAccountForClient(CloseBankAccountForClientModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var admin = GetAdministrator(client);

            var bankAccountToRemove = new BankAccount();
            foreach (var bankAccount in client.OpennedBankAccounts!)
            {
                if (bankAccount.Id == model.IdOfBankAccountToClose)
                {
                    bankAccountToRemove = bankAccount;
                    break;
                }
            }


            foreach (var opennedBankAccount in admin.OpennedBankAccounts!)
            {
                if (opennedBankAccount.BankAccount!.Equals(bankAccountToRemove))
                {
                    admin.OpennedBankAccounts.Remove(opennedBankAccount);
                    bankAccountToRemove.Hidden = true;
                    break;
                }
            }

            admin.DeletedBankAccounts!.Add(new DeletedBankAccount(client, bankAccountToRemove));


            //client.OpennedBankAccounts.Remove(bankAccountToRemove);
            //bank.OpennedBankAccounts?.Remove(bankAccountToRemove);

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            _context.Administrators.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetMoneyFromBankAccountForClient()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new GetMoneyFromBankAccountForClientModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetMoneyFromBankAccountForClient(GetMoneyFromBankAccountForClientModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();

            var bankAccountToWithDraw = new BankAccount();
            foreach (var bankAccount in client.OpennedBankAccounts)
                if (bankAccount.Id == model.IdOfBankAccountToWithdraw)
                {
                    bankAccountToWithDraw = bankAccount;
                    break;
                }

            bankAccountToWithDraw.AmountOfMoney -= model.AmountOfMoney;
            client.BankBalance += model.AmountOfMoney;

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult MoveMoneyBetweenBankAccount()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new MoveMoneyBetweenBankAccountModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> MoveMoneyBetweenBankAccount(MoveMoneyBetweenBankAccountModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var admin = GetAdministrator(client);

            var bankAccountToWithDraw = new BankAccount();
            var bankAccountToDeposit = new BankAccount();
            foreach (var bankAccount in client.OpennedBankAccounts)
            {
                if (bankAccount.Id == model.IdOfBankAccountToWithdraw)
                    bankAccountToWithDraw = bankAccount;
                //break;

                if (bankAccount.Id == model.IdOfBankAccountToDeposit) bankAccountToDeposit = bankAccount;
            }

            Transfer transfer = new Transfer();
            transfer.AmountOfMoney = model.AmountOfMoney;
            transfer.Id = ++_idForTransfer;
            bankAccountToWithDraw.AmountOfMoney -= transfer.AmountOfMoney;
            bankAccountToDeposit.AmountOfMoney += transfer.AmountOfMoney;
            //_context.Transfers.Add(transfer);

            admin.TransfersBetweenBankAccounts!.Add(
                new RollBackTransferBetweenBankAccounts(bankAccountToWithDraw, bankAccountToDeposit, transfer));

            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult OpenBankDepositForClient()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> OpenBankDepositForClient(OpenBankDepositForClientModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var admin = GetAdministrator(client);

            var bankDeposit = new BankDeposit();

            bankDeposit.Name = model.Name;
            bankDeposit.AmountOfMoney = model.AmountOfMoney;
            bankDeposit.DateOfDeal = DateTime.Today;
            bankDeposit.DateOfMoneyBack = model.DateOfMoneyBack;
            bankDeposit.Hidden = false;

            var HowMuchLasts = new TimeSpan();
            HowMuchLasts = DateTime.Today.Subtract(model.DateOfMoneyBack);
            bankDeposit.HowMuchLasts = Math.Abs(HowMuchLasts.Days);
            bankDeposit.Percent = model.Percent;
            client.BankBalance -= model.AmountOfMoney;

            client.OpennedBankDeposits!.Add(bankDeposit);
            bank.OpennedBankDeposits!.Add(bankDeposit);

            admin.OpennedDepositsToRollBack!.Add(new RollBackOpenedDeposit(client, bankDeposit));

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            _context.Administrators.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetMoneyFromDeposit()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new GetMoneyFromDepositModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetMoneyFromDeposit(GetMoneyFromDepositModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var admin = GetAdministrator(client);

            var bankDeposit = client.OpennedBankDeposits!.Find(b => b.Id == model.IdOfDepositToWithdraw);
            client.BankBalance += bankDeposit!.AmountOfMoney + bankDeposit.AmountOfMoney * (bankDeposit.Percent / 100);

            foreach (var opennedDeposit in admin.OpennedDepositsToRollBack!)
            {
                if (opennedDeposit.BankDeposit!.Equals(bankDeposit))
                {
                    admin.OpennedDepositsToRollBack.Remove(opennedDeposit);
                    opennedDeposit.BankDeposit.Hidden = true;
                    break;
                }
            }

            admin.ClosedDepositsToRollBack!.Add(new RollBackClosedDeposit(client, bankDeposit));

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            _context.Administrators.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }


    [HttpGet]
    [Authorize]
    public IActionResult SpeedRunDeposit()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new SpeedRunDepositModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SpeedRunDeposit(SpeedRunDepositModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);

            var bankDeposit = client.OpennedBankDeposits!.Find(b => b.Id == model.IdOfDepositToSpeedRun);

            bankDeposit!.HowMuchLasts = 0;
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult MoveMoneyBetweenBankDeposits()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new MoveMoneyBetweenBankDepositsModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> MoveMoneyBetweenBankDeposits(MoveMoneyBetweenBankDepositsModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var admin = GetAdministrator(client);

            var bankDepositToWithdraw = new BankDeposit();
            var bankDepositToDeposit = new BankDeposit();
            foreach (var bankDeposit in client.OpennedBankDeposits!)
            {
                if (bankDeposit.Id == model.IdOfBankDepositToWithdraw) bankDepositToWithdraw = bankDeposit;

                if (bankDeposit.Id == model.IdOfBankDepositToDeposit) bankDepositToDeposit = bankDeposit;
            }

            Transfer transfer = new Transfer();

            transfer.Id = ++_idForTransfer;

            foreach (var transferDb in _context.Transfers.ToList())
            {
                if (transfer.Id == transferDb.Id)
                {
                    transfer.Id = ++_idForTransfer;
                }
            }

            transfer.AmountOfMoney = bankDepositToWithdraw.AmountOfMoney +
                                     bankDepositToWithdraw.AmountOfMoney * (bankDepositToWithdraw.Percent / 100);

            bankDepositToDeposit.AmountOfMoney += transfer.AmountOfMoney;
            bankDepositToWithdraw.AmountOfMoney -= transfer.AmountOfMoney;
            bankDepositToWithdraw.Hidden = true;

            var tmp = admin.OpennedDepositsToRollBack!.FirstOrDefault(b =>
                b.BankDeposit!.Equals(bankDepositToWithdraw));

            admin.OpennedDepositsToRollBack!.Remove(tmp);
            admin.TransfersBetweenBankDeposits!.Add(
                new RollBackTransferBetweenBankDeposits(bankDepositToWithdraw, bankDepositToDeposit, transfer));

            //client.OpennedBankDeposits.Remove(bankDepositToWithdraw);
            //bank.OpennedBankDeposits!.Remove(bankDepositToWithdraw);
            _context.Administrators.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAnInstallmentPlan()
    {
        var client = GetClient();

        var managers = new List<Manager>();
        foreach (var manager in _context.Managers)
            if (manager.BankId == client.CurrentBankId)
                managers.Add(manager);

        var months = new List<int>(new[] { 3, 6, 9, 12, 24 });


        return View(new GetAnInstallmentPlanModel
        {
            Client = client,
            Managers = managers,
            AmountOfMonths = months
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetAnInstallmentPlan(GetAnInstallmentPlanModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var admin = GetAdministrator(client);
            var manager = _context.Managers
                .Include(m => m.WaitingForRegistrationApprove)
                .Include(m => m.WaitingForInstallmentPlanApprove)
                .FirstAsync(m => m.Id == model.IdOfSelectedManager).Result;

            var installmentPlan = new InstallmentPlan();

            installmentPlan.DateOfDeal = DateTime.Today;
            installmentPlan.DateToPay = installmentPlan.DateOfDeal.AddMonths((int)model.SelectedAmountOfMonth);
            installmentPlan.DurationInMonths = model.DurationInMonths;
            installmentPlan.HowMuchLasts =
                Math.Abs(installmentPlan.DateToPay.Subtract(installmentPlan.DateOfDeal).Days);
            installmentPlan.AmountOfMoney = model.AmountOfMoney;
            installmentPlan.BankId = bank.Id;
            installmentPlan.ClientId = client.Id;

            client.InstallmentPlansAndApproves!.Add(new InstallmentPlanApproves(installmentPlan!, false));
            bank.OpennedInstallmentPlans!.Add(installmentPlan);
            

            if (model.IdOfSelectedManager != null)
                if (!manager.WaitingForInstallmentPlanApprove.Contains(client))
                {
                    manager.WaitingForInstallmentPlanApprove.Add(client);
                    _context.Managers.Update(manager);
                    await _context.SaveChangesAsync();
                }

            _context.Managers.Update(manager);
            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetCredit()
    {
        var client = GetClient();

        var managers = new List<Manager>();
        foreach (var manager in _context.Managers)
            if (manager.BankId == client.CurrentBankId)
                managers.Add(manager);

        var months = new List<int>(new[] { 3, 6, 9, 12, 24 });


        return View(new GetCreditModel
        {
            Managers = managers,
            AmountOfMonths = months
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetCredit(GetCreditModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);
            var manager = _context.Managers
                .Include(m => m.WaitingForRegistrationApprove)
                .Include(m => m.WaitingForInstallmentPlanApprove)
                .Include(m => m.WaitingForCreditApprove)
                .FirstAsync(m => m.Id == model.IdOfSelectedManager).Result;

            var credit = new Credit();

            credit.DateOfDeal = DateTime.Today;
            credit.DateToPay = credit.DateOfDeal.AddMonths((int)model.SelectedAmountOfMonth);
            credit.DurationInMonths = model.DurationInMonths;
            credit.HowMuchLasts =
                Math.Abs(credit.DateToPay.Subtract(credit.DateOfDeal).Days);
            credit.AmountOfMoney = model.AmountOfMoney;
            credit.BankId = bank.Id;
            credit.ClientId = client.Id;
            credit.Percent = model.Percent;

            client.CreditsAndApproves!.Add(new CreditsAndApproves(credit!, false));
            bank.OpennedCredits!.Add(credit);

            if (model.IdOfSelectedManager != null)
                if (!manager.WaitingForCreditApprove!.Contains(client))
                {
                    manager.WaitingForCreditApprove.Add(client);
                    _context.Managers.Update(manager);
                    await _context.SaveChangesAsync();
                }

            _context.Managers.Update(manager);
            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult SpeedRunInstallmentPlan()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new SpeedRunInstallmentPlanModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SpeedRunInstallmentPlan(SpeedRunInstallmentPlanModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();

            var installmentPlan =
                client.InstallmentPlansAndApproves.Find(b => b.Id == model.IdOfInstallmentPlanToSpeedRun);

            installmentPlan.InstallmentPlan.HowMuchLasts = 0;
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }


    [HttpGet]
    [Authorize]
    public IActionResult SpeedRunCredit()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new SpeedRunCreditModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SpeedRunCredit(SpeedRunCreditModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();

            var credit =
                client.CreditsAndApproves!.Find(c => c.Id == model.IdOfCreditToSpeedRun);

            credit.Credit.HowMuchLasts = 0;
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult PayForInstallmentPlan()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new PayForInstallmentPlanModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PayForInstallmentPlan(PayForInstallmentPlanModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);

            var installmentPlan = client.InstallmentPlansAndApproves.Find(b => b.Id == model.IdOfInstallmentPlanToPay);

            client.BankBalance -= installmentPlan.InstallmentPlan.AmountOfMoney;

            client.InstallmentPlansAndApproves.Remove(installmentPlan);
            bank.OpennedInstallmentPlans!.Remove(installmentPlan.InstallmentPlan);

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }


    [HttpGet]
    [Authorize]
    public IActionResult PayForCredit()
    {
        var client = GetClient();
        var bank = GetBank(client);


        return View(new PayForCreditModel
        {
            Client = client,
            Bank = bank
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PayForCredit(PayForCreditModel model)
    {
        if (ModelState.IsValid)
        {
            var client = GetClient();
            var bank = GetBank(client);

            var credit = client.CreditsAndApproves.Find(b => b.Id == model.IdOfCreditToPay);

            client.BankBalance -= credit.Credit.AmountOfMoney +
                                  credit.Credit.AmountOfMoney * (credit.Credit.Percent / 100);

            client.CreditsAndApproves.Remove(credit);
            bank.OpennedCredits!.Remove(credit.Credit);

            _context.Clients.Update(client);
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Client");
        }

        return View(model);
    }
}