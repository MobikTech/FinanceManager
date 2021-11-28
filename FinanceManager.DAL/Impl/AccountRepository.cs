using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Implementation
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(FinanceManagerDbContext context) : base(context) { }
        
        public Account GetByNumber(string number)
        {
            throw new System.NotImplementedException();
        }
    }
}