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
            IEnumerable<CategoryViewModel> categoryViewModels = _categoryService.GetAllCategories()
                .Select(dto => _categoryViewMapper.Map(dto));
            return View(categoryViewModels);
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
        public IActionResult Remove(CategoryViewModel model)
        {
            CategoryDTO dto = _categoryService.GetCategoryByName(model.Name);
            // CategoryDTO dto = _categoryService.GetCategoryById(id);
            // CategoryViewModel model = _categoryViewMapper.Map(dto);
            if (_categoryService.TryDeleteCategory(dto.Id))
            {
                return Redirect("~/Category/Categories");
                // return Json(model);
            }

            return Content("Account was not removed");
        }

        #endregion
    }
}