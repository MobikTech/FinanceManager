using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstr.UoWs;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Impl
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
                throw new NullException(typeof(Category), "Name");
            }
            if (Database.CategoryRepository.GetCategoryByName(dto.Name) != null)
            {
                throw new AlreadyExistException(typeof(Category));
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
                throw new NotFoundException(typeof(Category));
            }

            return _categoryMapper.Map(result);
        }

        public CategoryDTO GetCategoryByName(string name)
        {
            Category result = Database.CategoryRepository.GetCategoryByName(name);
            if (result == null)
            {
                throw new NotFoundException(typeof(Category));
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
                throw new NullException(typeof(Category), "Name");
            }
            if (Database.CategoryRepository.GetById(dto.Id) == null)
            {
                throw new NotFoundException(typeof(Category));
            }
            Category category = _categoryMapper.MapBack(dto);
            Database.CategoryRepository.Update(category);
            Database.Save();
        }

        public bool TryDeleteCategory(int id)
        {
            Category category = Database.CategoryRepository.GetById(id);
            if (category == null)
            {
                throw new NotFoundException(typeof(Category));
            }
            Database.CategoryRepository.Delete(category);
            Database.Save();
            return true;
        }
    }
}