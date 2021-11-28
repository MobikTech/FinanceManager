using System.Linq;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Implementation
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(FinanceManagerDbContext context) : base(context) { }
        
        public Account GetByNumber(string number)
        {
            return DbSet
                .Include(account => account.TransactionsAsSource)
                .Include(account => account.TransactionsAsTarget)
                .FirstOrDefault(account => account.Number == number);
        }
    }
}