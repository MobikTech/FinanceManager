using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.PL.MVC.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Controllers
{
    public sealed class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly AccountViewMapper _accountViewMapper;

        public AccountController(IAccountService accountService, AccountViewMapper accountViewMapper)
        {
            _accountService = accountService;
            _accountViewMapper = accountViewMapper;
        }

        #region Read

        [HttpGet]
        public IActionResult Accounts()
        {
            IEnumerable<AccountViewModel> accountViewModels = _accountService.GetAllAccounts()
                .Select(dto => _accountViewMapper.Map(dto));
            return View(accountViewModels);
        }
        
        [HttpGet]
        public IActionResult Details(AccountViewModel accountViewModel)
        {
            AccountDTO dto = _accountViewMapper.MapBack(accountViewModel);
            return View(dto);
        }
        
        // [HttpGet]
        // public IActionResult Details(int id)
        // {
        //     AccountDTO dto = _accountService.GetAccountById(id);
        //     return View(dto);
        // }
        
        [HttpGet]
        public IActionResult CheckCount(int _accountId, int? _categoryId, string income, string costs)
        {
            if (income is not null)
            {
                return RedirectToAction("CheckIncome", new {accountId = _accountId, categoryId = _categoryId});
            }
            else if (costs is not null)
            {
                return RedirectToAction("CheckCosts", new {accountId = _accountId, categoryId = _categoryId});
            }

            throw new InvalidDataException();
        }
        
        [HttpGet]
        public IActionResult CheckIncome(int accountId, int? categoryId)
        {
            decimal totalIncome = categoryId.HasValue 
                ? _accountService.CheckIncome(accountId, categoryId.Value) 
                : _accountService.CheckIncome(accountId);

            ViewBag.AccountId = accountId;
            ViewBag.CategoryId = categoryId;
            
            return Content(totalIncome.ToString(CultureInfo.CurrentCulture));
        }
        
        [HttpGet]
        public IActionResult CheckCosts(int accountId, int? categoryId)
        {
            decimal totalCosts = categoryId.HasValue 
                ? _accountService.CheckCosts(accountId, categoryId.Value) 
                : _accountService.CheckCosts(accountId);

            ViewBag.AccountId = accountId;
            ViewBag.CategoryId = categoryId;
            
            return Content(totalCosts.ToString(CultureInfo.CurrentCulture));
        }

        #endregion

        #region Create
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(AccountViewModel model)
        {
            AccountDTO createdAccount = _accountService.CreateAccount(_accountViewMapper.MapBack(model));
            return RedirectToAction("Accounts");
            // return Json(createdAccount);
        }

        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Remove(AccountViewModel model)
        {
            AccountDTO dto = _accountService.GetAccountByNumber(model.Number);
            // AccountViewModel model = _accountViewMapper.Map(dto);
            if (_accountService.TryDeleteAccount(model.Number))
            {
                return Redirect("~/Account/Accounts");
                // return Json(model);
            }

            return NotFound("Account with that number doesn't exist");
        }
        
        // [HttpPost, ActionName("Remove")]
        // public IActionResult RemoveAccount(string number)
        // {
        //     AccountDTO dto = _accountService.GetAccountByNumber(number);
        //     AccountViewModel model = _accountViewMapper.Map(dto);
        //     if (_accountService.TryDeleteAccount(number))
        //     {
        //         return Redirect("~/Account/Accounts");
        //         // return Json(model);
        //     }
        //
        //     return Content("Account was not removed");
        // }
        //
        #endregion
    }
}