using FinanceManager.BLL.Abstraction;
using FinanceManager.PL.WebApi.Mappers;
using FinanceManager.PL.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.PL.WebApi.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly TransactionViewMapper _transactionViewMapper;

        public TransactionController(ITransactionService transactionService, TransactionViewMapper transactionViewMapper)
        {
            _transactionService = transactionService;
            _transactionViewMapper = transactionViewMapper;
        }

        #region Create

        [HttpPost]
        public void Make([FromBody] TransactionViewModel model) =>
            _transactionService.MakeTransaction(_transactionViewMapper.MapBack(model));

        #endregion
    }
}