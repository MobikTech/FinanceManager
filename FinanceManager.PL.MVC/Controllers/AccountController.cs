using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.PL.MVC.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Controllers
{
    public sealed class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly AccountViewMapper _accountViewMapper;

        public AccountController(IAccountService accountService, AccountViewMapper accountViewMapper, ICategoryService categoryService)
        {
            _accountService = accountService;
            _accountViewMapper = accountViewMapper;
            _categoryService = categoryService;
        }

        #region Read

        [HttpGet]
        public IActionResult Accounts()
        {
            IEnumerable<AccountDTO> accountDtos = _accountService.GetAllAccounts();
                // .Select(dto => _accountViewMapper.Map(dto));
            return View(accountDtos);
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            AccountDTO dto = _accountService.GetAccountById(id);
            return View(dto);
        }
        
        [HttpGet]
        public IActionResult CheckCount(int _accountId, string categoryName, CheckType checkType)
        {
            int? _categoryId;
            try
            {
                _categoryId = _categoryService.GetCategoryByName(categoryName).Id;
            }
            catch (ValidationException)
            {
                _categoryId = null;
            }
            switch (checkType)  
            {
                case CheckType.Income:
                    return RedirectToAction("CheckIncome", new {accountId = _accountId, categoryId = _categoryId});
                case CheckType.Costs:
                    return RedirectToAction("CheckCosts", new {accountId = _accountId, categoryId = _categoryId});
                default:
                    throw new ArgumentOutOfRangeException(nameof(checkType), checkType, null);
            }
        }
        
        [HttpGet]
        public IActionResult CheckIncome(int accountId, int? categoryId)
        {
            decimal totalIncome = categoryId.HasValue 
                ? _accountService.CheckIncome(accountId, categoryId.Value) 
                : _accountService.CheckIncome(accountId);
            
            ViewBag.Account = _accountService.GetAccountById(accountId);
            ViewBag.Category = null;
            if (categoryId.HasValue)
            {
                ViewBag.Category = _categoryService.GetCategoryById(categoryId.Value);
            }
            ViewBag.CheckType = "Income";
            ViewBag.TotalSum = totalIncome;
            return View("CheckResult");
        }
        
        [HttpGet]
        public IActionResult CheckCosts(int accountId, int? categoryId)
        {
            decimal totalCosts = categoryId.HasValue 
                ? _accountService.CheckCosts(accountId, categoryId.Value) 
                : _accountService.CheckCosts(accountId);
            
            ViewBag.Account = _accountService.GetAccountById(accountId);
            ViewBag.Category = null;
            if (categoryId.HasValue)
            {
                ViewBag.Category = _categoryService.GetCategoryById(categoryId.Value);
            }
            ViewBag.CheckType = "Costs";
            ViewBag.TotalSum = totalCosts;
            return View("CheckResult");
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
            _accountService.CreateAccount(_accountViewMapper.MapBack(model));
            return RedirectToAction("Accounts");
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Remove(int id)
        {
            _accountService.DeleteAccount(id);
            return Redirect("~/Account/Accounts");
        }

        #endregion
    }
}