using System.Linq;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Implementation
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