using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Abstr
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        public Account GetByNumber(string number);
    }
}