using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.ViewModels;

namespace FinanceManager.BLL.Abstraction
{
    public interface ICategoryService
    {
        public Task<CategoryViewModel> CreateCategory(CategoryViewModel viewModel);
        
        public Task<CategoryViewModel> GetCategory(int id);
        
        public Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        
        public Task UpdateCategory(CategoryViewModel viewModel);
        
        public Task DeleteCategory(int id);
    }
}