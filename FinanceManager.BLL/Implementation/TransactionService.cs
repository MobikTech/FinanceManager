using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.Mappers;
using FinanceManager.BLL.ViewModels;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Implementation
{
    public class TransactionService : BaseService<IUnitOfWork>, ITransactionService
    {
        private readonly IGeneralMapper<Transaction, TransactionViewModel> _transactionMapper;

        public TransactionService(
            IUnitOfWork uow,
            IGeneralMapper<Transaction, TransactionViewModel> transactionMapper) : base(uow)
        {
            _transactionMapper = transactionMapper;
        }

        public async Task<TransactionViewModel> CreateTransaction(TransactionViewModel viewModel)
        {
            Transaction transaction = _transactionMapper.MapBack(viewModel);
            Transaction result = await Database.TransactionRepository.Create(transaction);
            if (result == null)
            {
                throw new NotImplementedException();
            }
            
            return _transactionMapper.Map(result);
        }

        public async Task<TransactionViewModel> GetTransaction(int id)
        {
            Transaction result = await Database.TransactionRepository.GetById(id);
            if (result == null)
            {
                throw new NotImplementedException();
            }

            return _transactionMapper.Map(result);
        }

        public async Task<IEnumerable<TransactionViewModel>> GetAllTransactions()
        {
            List<Transaction> result = await Database.TransactionRepository.GetAll(); 
            if (result == null)
            {
                throw new NotImplementedException();
            }
            return result.Select(_transactionMapper.Map);
        }

        public async Task UpdateTransaction(TransactionViewModel viewModel)
        {
            Transaction transaction = await Database.TransactionRepository.GetById(viewModel.Id);
            if (transaction == null)
            {
                throw new NotImplementedException();
            }
            transaction = _transactionMapper.MapUpdate(viewModel, transaction);
            await Database.TransactionRepository.Update(transaction);
        }

        public async Task DeleteTransaction(int id)
        {
            Transaction transaction = await Database.TransactionRepository.GetById(id);
            if (transaction == null)
            {
                throw new NotImplementedException();
            }
            await Database.AccountRepository.Delete(transaction);
        }
    }
}