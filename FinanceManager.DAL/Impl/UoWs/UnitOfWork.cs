using System;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceManagerDbContext _context;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;
        private ITransactionRepository _transactionRepository;
        private bool disposed = false;
        
        // todo
        // public UnitOfWork(FinanceManagerDbContext context)
        // {
        //     _context = context;
        // }
        public UnitOfWork(DbContextOptions<FinanceManagerDbContext> options)
        {
            _context = new FinanceManagerDbContext(options);
        }

        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_context);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
        public ITransactionRepository TransactionRepository => _transactionRepository ??= new TransactionRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}