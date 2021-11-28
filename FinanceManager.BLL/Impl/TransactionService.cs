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
            if (dto.SourceId.HasValue)
            {
                Account sourceAccount = Database.AccountRepository.GetById(dto.SourceId.Value);
                sourceAccount.Count -= dto.Sum;
                Database.AccountRepository.Update(sourceAccount);
            }
            if (dto.TargetId.HasValue)
            {
                Account targetAccount = Database.AccountRepository.GetById(dto.TargetId.Value);
                targetAccount.Count += dto.Sum;
                Database.AccountRepository.Update(targetAccount);
            }
            
            Database.Save();
            return _transactionMapper.Map(result);
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