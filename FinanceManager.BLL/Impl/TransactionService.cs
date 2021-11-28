using System;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Implementation
{
    public class TransactionService : BaseService<IUnitOfWork>, ITransactionService
    {
        private readonly IGeneralMapper<Transaction, TransactionDTO> _transactionMapper;

        public TransactionService(IUnitOfWork uow, IGeneralMapper<Transaction, TransactionDTO> transactionMapper) 
            : base(uow)
        {
            _transactionMapper = transactionMapper;
        }

        public TransactionDTO MakeTransaction(TransactionDTO dto)
        {
            Transaction transaction = _transactionMapper.MapBack(dto);
            Transaction result = Database.TransactionRepository.Create(transaction);
            if (result == null)
            {
                throw new NotImplementedException();
            }
            
            Database.Save();
            return _transactionMapper.Map(result);
        }

        public decimal CheckIncome(int categoryId, int accountId)
        {
            decimal totalIncome = Database.TransactionRepository.GetAll()
                .Where(transaction => transaction.CategoryId == categoryId)
                .Where(transaction => transaction.TargetId == accountId)
                .Select(transaction => transaction.Sum)
                .Sum();
            return totalIncome;
        }

        public decimal CheckCosts(int categoryId, int accountId)
        {
            decimal totalCosts = Database.TransactionRepository.GetAll()
                .Where(transaction => transaction.CategoryId == categoryId)
                .Where(transaction => transaction.SourceId == accountId)
                .Select(transaction => transaction.Sum)
                .Sum();
            return totalCosts;
        }

        // public TransactionDTO GetTransaction(int id)
        // {
        //     Transaction result = Database.TransactionRepository.GetById(id);
        //     if (result == null)
        //     {
        //         throw new NotImplementedException();
        //     }
        //
        //     return _transactionMapper.Map(result);
        // }

        // public IEnumerable<TransactionDTO> GetAllTransactions()
        // {
        //     List<Transaction> result = Database.TransactionRepository.GetAll(); 
        //     if (result == null)
        //     {
        //         throw new NotImplementedException();
        //     }
        //     return result.Select(_transactionMapper.Map);
        // }
    }
}