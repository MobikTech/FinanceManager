using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;

namespace FinanceManager.PL.Controllers
{
    public sealed class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        
        
        
    }
}