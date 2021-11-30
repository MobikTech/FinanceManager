using System.Collections.Generic;
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
        [ActionName("Accounts")]
        public IActionResult GetAllAccounts()
        {
            IEnumerable<AccountViewModel> accountViewModels = _accountService.GetAllAccounts()
                .Select(dto => _accountViewMapper.Map(dto));
            return View(accountViewModels);
        }

        #endregion

        #region Create
        
        [HttpGet]
        [ActionName("Create")]
        public IActionResult AddAccount()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddAccount(AccountViewModel model)
        {
            AccountDTO createdAccount = _accountService.CreateAccount(_accountViewMapper.MapBack(model));
            return Json(createdAccount);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [ActionName("Remove")]
        public IActionResult RemoveAccount(string number)
        {
            AccountDTO dto = _accountService.GetAccountByNumber(number);
            AccountViewModel model = _accountViewMapper.Map(dto);
            if (_accountService.TryDeleteAccount(number))
            {
                return Json(model);
            }

            return Content("Account was not removed");
        }

        #endregion
        
    }
}