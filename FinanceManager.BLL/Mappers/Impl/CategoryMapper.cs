using FinanceManager.BLL.DTO;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Mappers
{
    public class CategoryMapper : IGeneralMapper<Category, CategoryDTO>
    {
        public CategoryDTO Map(Category entity)
        {
            return new CategoryDTO()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Category MapBack(CategoryDTO model)
        {
            return new Category()
            {
                Name = model.Name
            };
        }
        //
        // public Category MapUpdate(CategoryDTO model, Category entity)
        // {
        //     entity.Name = model.Name;
        //     return entity;
        // }
    }
}