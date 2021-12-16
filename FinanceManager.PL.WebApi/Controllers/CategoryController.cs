using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.PL.WebApi.Mappers;
using FinanceManager.PL.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.PL.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
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
        public List<CategoryViewModel> GetAll() =>
            _categoryService.GetAllCategories().Select(dto => _categoryViewMapper.Map(dto)).ToList();

        [HttpGet]
        [Route("{id:int}")]
        public CategoryViewModel Get([FromRoute] int id) =>
            _categoryViewMapper.Map(_categoryService.GetCategoryById(id));

        #endregion

        #region Create

        [HttpPost]
        public void Create([FromBody] CategoryViewModel model) =>
            _categoryService.CreateCategory(_categoryViewMapper.MapBack(model));

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id:int}")]
        public void Remove([FromRoute] int id) => _categoryService.TryDeleteCategory(id);

        #endregion
    }
}