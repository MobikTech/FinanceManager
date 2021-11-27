using FinanceManager.BLL.DTO;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Mappers
{
    public class TransactionMapper : IGeneralMapper<Transaction, TransactionDTO>
    {
        public TransactionDTO Map(Transaction entity)
        {
            throw new System.NotImplementedException();
        }

        public Transaction MapBack(TransactionDTO model)
        {
            throw new System.NotImplementedException();
        }

        public Transaction MapUpdate(TransactionDTO model, Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}