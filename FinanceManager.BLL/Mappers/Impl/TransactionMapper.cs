using FinanceManager.BLL.DTO;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Mappers
{
    public class TransactionMapper : IGeneralMapper<Transaction, TransactionDTO>
    {
        public TransactionDTO Map(Transaction entity)
        {
            return new TransactionDTO()
            {
                Id = entity.Id,
                Sum = entity.Sum,
                Date = entity.Date,
                CategoryId = entity.CategoryId,
                SourceId = entity.SourceId,
                TargetId = entity.TargetId
            };
        }

        public Transaction MapBack(TransactionDTO model)
        {
            return new Transaction()
            {
                Sum = model.Sum,
                Date = model.Date,
                CategoryId = model.CategoryId,
                SourceId = model.SourceId,
                TargetId = model.TargetId
            };
        }

        public Transaction MapUpdate(TransactionDTO model, Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}