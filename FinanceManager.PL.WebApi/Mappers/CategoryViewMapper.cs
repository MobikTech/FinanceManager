using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.PL.WebApi.Models;

namespace FinanceManager.PL.WebApi.Mappers
{
    public class CategoryViewMapper : IMap<CategoryDTO, CategoryViewModel>, IMapBack<CategoryViewModel, CategoryDTO>
    {
        public CategoryViewModel Map(CategoryDTO dto)
        {
            return new CategoryViewModel()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public CategoryDTO MapBack(CategoryViewModel model)
        {
            return new CategoryDTO()
            {
                // Id = model.Id,
                Name = model.Name
            };
        }
    }
}