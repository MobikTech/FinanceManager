using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;

namespace FinanceManager.PL.MVC.Controllers
{
    public sealed class CategoryController : Controller
    {
        private readonly ICategoryService _accountService;

        public CategoryController(ICategoryService accountService)
        {
            _accountService = accountService;
        }
        
        
    }
}