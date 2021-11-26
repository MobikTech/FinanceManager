using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.ViewModels;
using FinanceManager.DAL.Abstraction;

namespace FinanceManager.BLL.Implementation
{
    public class CategoryService : BaseService<IUnitOfWork>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow) { }
        
        public Task<CategoryViewModel> CreateCategory(CategoryViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryViewModel> GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCategory(CategoryViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        
    }
}