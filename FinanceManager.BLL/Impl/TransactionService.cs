using System;
using System.Collections.Generic;
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

        public TransactionDTO CreateTransaction(TransactionDTO dto)
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

        public TransactionDTO GetTransaction(int id)
        {
            Transaction result = Database.TransactionRepository.GetById(id);
            if (result == null)
            {
                throw new NotImplementedException();
            }

            return _transactionMapper.Map(result);
        }

        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            List<Transaction> result = Database.TransactionRepository.GetAll(); 
            if (result == null)
            {
                throw new NotImplementedException();
            }
            return result.Select(_transactionMapper.Map);
        }

        public void UpdateTransaction(TransactionDTO dto)
        {
            Transaction transaction = Database.TransactionRepository.GetById(dto.Id);
            if (transaction == null)
            {
                throw new NotImplementedException();
            }
            transaction = _transactionMapper.MapUpdate(dto, transaction);
            Database.TransactionRepository.Update(transaction);
            Database.Save();
        }

        public void DeleteTransaction(int id)
        {
            Transaction transaction = Database.TransactionRepository.GetById(id);
            if (transaction == null)
            {
                throw new NotImplementedException();
            }
            Database.TransactionRepository.Delete(transaction);
            Database.Save();
        }
    }
}