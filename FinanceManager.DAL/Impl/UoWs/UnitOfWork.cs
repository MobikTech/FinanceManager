using System;
using FinanceManager.DAL.Abstr;
using FinanceManager.DAL.Abstr.UoWs;
using FinanceManager.DAL.DB;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Impl.UoWs
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceManagerDbContext _context;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;
        private ITransactionRepository _transactionRepository;
        private bool _disposed = false;

        public UnitOfWork(DbContextOptions<FinanceManagerDbContext> options)
        {
            _context = new FinanceManagerDbContext(options);
        }

        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_context);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);

        public ITransactionRepository TransactionRepository =>
            _transactionRepository ??= new TransactionRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}