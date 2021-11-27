using System;
using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
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
            Category category = _categoryMapper.MapBack(dto);
            Category result = Database.CategoryRepository.Create(category);
            if (result == null)
            {
                throw new NotImplementedException();
            }
            
            Database.Save();
            return _categoryMapper.Map(result);
        }

        public CategoryDTO GetCategory(int id)
        {
            Category result = Database.CategoryRepository.GetById(id);
            if (result == null)
            {
                throw new NotImplementedException();
            }

            return _categoryMapper.Map(result);
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            List<Category> result = Database.CategoryRepository.GetAll(); 
            if (result == null)
            {
                throw new NotImplementedException();
            }
            return result.Select(_categoryMapper.Map);
        }

        public void UpdateCategory(CategoryDTO dto)
        {
            Category category = Database.CategoryRepository.GetById(dto.Id);
            if (category == null)
            {
                throw new NotImplementedException();
            }
            category = _categoryMapper.MapUpdate(dto, category);
            Database.CategoryRepository.Update(category);
            Database.Save();
        }

        public void DeleteCategory(int id)
        {
            Category category = Database.CategoryRepository.GetById(id);
            if (category == null)
            {
                throw new NotImplementedException();
            }
            Database.CategoryRepository.Delete(category);
            Database.Save();
        }
    }
}