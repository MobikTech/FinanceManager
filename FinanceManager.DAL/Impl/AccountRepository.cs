using System.Linq;
using FinanceManager.DAL.Abstr;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Impl
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(FinanceManagerDbContext context) : base(context) { }
        
        public Account GetByNumber(string number) =>
            DbSet
                .Include(account => account.TransactionsAsSource)
                .Include(account => account.TransactionsAsTarget)
                .FirstOrDefault(account => account.Number == number);

        public override Account GetById(int id) =>
            DbSet
                .Include(account => account.TransactionsAsSource)
                .Include(account => account.TransactionsAsTarget)
                .FirstOrDefault(account => account.Id == id);
    }
}