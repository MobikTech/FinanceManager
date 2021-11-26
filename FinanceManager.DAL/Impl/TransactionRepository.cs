using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;

namespace FinanceManager.DAL.Implementation
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(FinanceManagerDbContext context) : base(context) { }
    }
}