using System;
using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Implementation
{
    public class CategoryService : BaseService<IUnitOfWork>, ICategoryService
    {
        private readonly IGeneralMapper<Category, CategoryDTO> _categoryMapper;

        public CategoryService(IUnitOfWork uow, IGeneralMapper<Category, CategoryDTO> categoryMapper) 
            : base(uow)
        {
            _categoryMapper = categoryMapper;
        }


        public CategoryDTO CreateCategory(CategoryDTO dto)
        {
            if (dto.Name == null)
            {
                throw new ValidationException("Name cannot be a null", null);
            }
            if (Database.CategoryRepository.GetCategoryByName(dto.Name) != null)
            {
                throw new ValidationException("Already exists category with the same name", null);
            }
            Category category = _categoryMapper.MapBack(dto);
            Category result = Database.CategoryRepository.Create(category);
            Database.Save();
            return _categoryMapper.Map(result);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            Category result = Database.CategoryRepository.GetById(id);
            if (result == null)
            {
                throw new ValidationException("Category doesn't exist", null);
            }

            return _categoryMapper.Map(result);
        }

        public CategoryDTO GetCategoryByName(string name)
        {
            Category result = Database.CategoryRepository.GetCategoryByName(name);
            if (result == null)
            {
                throw new ValidationException("Category doesn't exist", null);
            }

            return _categoryMapper.Map(result);
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            List<Category> result = Database.CategoryRepository.GetAll(); 
            return result.Select(_categoryMapper.Map);
        }

        public void UpdateCategory(CategoryDTO dto)
        {
            if (dto.Name == null)
            {
                throw new ValidationException("Name cannot be null", null);
            }
            Category category = Database.CategoryRepository.GetById(dto.Id);
            if (category == null)
            {
                throw new ValidationException("Category doesn't exist", null);
            }
            category = _categoryMapper.MapUpdate(dto, category);
            category.Name = dto.Name;
            Database.CategoryRepository.Update(category);
            Database.Save();
        }

        public bool TryDeleteCategory(int id)
        {
            Category category = Database.CategoryRepository.GetById(id);
            if (category == null)
            {
                throw new ValidationException("Category doesn't exist", null);
            }
            Database.CategoryRepository.Delete(category);
            Database.Save();
            return true;
        }
    }
}