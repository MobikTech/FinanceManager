using System;

namespace FinanceManager.DAL.Abstr.UoWs
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITransactionRepository TransactionRepository { get; }

        void Save();
    }
}