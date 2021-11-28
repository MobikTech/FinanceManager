using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface ITransactionService
    {
        public TransactionDTO MakeTransaction(TransactionDTO dto);
        
        // public TransactionDTO GetTransaction(int id);

        public decimal CheckIncome(int categoryId, int accountId);
        
        public decimal CheckCosts(int categoryId, int accountId);

        // public IEnumerable<TransactionDTO> GetAllTransactions();
        
    }
}