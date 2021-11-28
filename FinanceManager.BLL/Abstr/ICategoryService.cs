using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface ICategoryService
    {
        public CategoryDTO CreateCategory(CategoryDTO dto);
        
        public CategoryDTO GetCategory(int id);
        
        public CategoryDTO GetCategoryByName(string name);

        public IEnumerable<CategoryDTO> GetAllCategories();
        
        public void UpdateCategory(CategoryDTO dto);
        
        public void DeleteCategory(int id);
    }
}