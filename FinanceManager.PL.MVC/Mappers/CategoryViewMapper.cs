using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Mappers
{
    public class CategoryViewMapper : IMap<CategoryDTO, CategoryViewModel>, IMapBack<CategoryViewModel, CategoryDTO>
    {
        public CategoryViewModel Map(CategoryDTO dto)
        {
            return new CategoryViewModel()
            {
                Name = dto.Name
            };
        }

        public CategoryDTO MapBack(CategoryViewModel model)
        {
            return new CategoryDTO()
            {
                Name = model.Name
            };
        }
    }
}