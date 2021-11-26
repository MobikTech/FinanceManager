using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Implementation
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(FinanceManagerDbContext context) : base(context) { }
    }
}