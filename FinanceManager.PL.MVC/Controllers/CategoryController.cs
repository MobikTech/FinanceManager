using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.PL.MVC.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Controllers
{
    public sealed class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryViewMapper _categoryViewMapper;

        public CategoryController(ICategoryService categoryService, CategoryViewMapper categoryViewMapper)
        {
            _categoryService = categoryService;
            _categoryViewMapper = categoryViewMapper;
        }
        
        #region Read

        [HttpGet]
        [ActionName("Categories")]
        public IActionResult GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categoryViewModels = _categoryService.GetAllCategories()
                .Select(dto => _categoryViewMapper.Map(dto));
            return View(categoryViewModels);
        }

        #endregion

        #region Create
        
        [HttpGet]
        [ActionName("Create")]
        public IActionResult AddCategory()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            CategoryDTO createdCategory = _categoryService.CreateCategory(_categoryViewMapper.MapBack(model));
            return Json(createdCategory);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [ActionName("Remove")]
        public IActionResult RemoveCategory(int id)
        {
            AccountDTO dto = _categoryService.GetAccountByNumber(number);
            AccountViewModel model = _accountViewMapper.Map(dto);
            if (_categoryService.TryDeleteAccount(number))
            {
                return Json(model);
            }

            return Content("Account was not removed");
        }

        #endregion
    }
}