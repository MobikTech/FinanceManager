
using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Abstraction
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        public Account GetByNumber(string number);
    }
}