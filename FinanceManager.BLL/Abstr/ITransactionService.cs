using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface ITransactionService
    {
        public TransactionDTO MakeTransaction(TransactionDTO dto);
    }
}