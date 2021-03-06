using System.Linq;
using FinanceManager.DAL.Abstr;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Impl
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(FinanceManagerDbContext context) : base(context) { }
        public Category GetCategoryByName(string name)
        {
            return DbSet
                .Include(category => category.Transactions)
                .FirstOrDefault(category => category.Name == name);
        }
    }
}