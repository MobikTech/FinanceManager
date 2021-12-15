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
        public IActionResult Categories()
        {
            IEnumerable<CategoryDTO> categoryDTOs = _categoryService.GetAllCategories();
            return View(categoryDTOs);
        }

        #endregion

        #region Create
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            CategoryDTO createdCategory = _categoryService.CreateCategory(_categoryViewMapper.MapBack(model));
            return RedirectToAction("Categories");
            // return Json(createdCategory);
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Remove(int id)
        {
            if (_categoryService.TryDeleteCategory(id))
            {
                return Redirect("~/Category/Categories");
            }

            return Content("Account was not removed");
        }

        #endregion
    }
}