using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Abstr
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public Category GetCategoryByName(string name);
    }
}   