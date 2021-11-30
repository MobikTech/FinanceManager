using System.Linq;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using NUnit.Framework;

namespace FinanceManager.Tests
{
    public class TransactionServiceTests : BaseServiceTests
    {
        [Test]
        public void MakeTransaction_CorrectTransaction_ReturnedTransactionDTO()
        {
            TransactionDTO dto = new TransactionDTO()
            {
                Sum = 100,
                SourceId = 1,
                TargetId = 2,
                CategoryId = null
            };
            _transactionService.MakeTransaction(dto);
            Assert.NotNull(_transactionRepository
                .GetAll()
                .FirstOrDefault(transaction => transaction.Sum == 100));
        }
        
        [TestCase(1, null, null, null)]
        [TestCase(1, null, 1, null)]
        [TestCase(1, 1, null, null)]
        [TestCase(1, 1, 2, 1)]
        [TestCase(-10, 1, null, 1)]
        [TestCase(10000, 1, null, 1)]
        public void MakeTransaction_WrongInput_Exception(decimal sum, int sourceId, int targetId, int categoryId)
        {
            TransactionDTO dto = new TransactionDTO()
            {
                Sum = sum,
                SourceId = sourceId,
                TargetId = targetId,
                CategoryId = categoryId
            };
            Assert.Throws(typeof(ValidationException), () => _transactionService.MakeTransaction(dto));
        }
    }
}