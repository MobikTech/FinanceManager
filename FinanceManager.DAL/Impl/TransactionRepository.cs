using FinanceManager.DAL.Abstr;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Impl
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(FinanceManagerDbContext context) : base(context) { }
    }
}