using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.PL.WebApi.Mappers;
using FinanceManager.PL.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.PL.WebApi.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public sealed class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly AccountViewMapper _accountViewMapper;

        public AccountController(IAccountService accountService, AccountViewMapper accountViewMapper)
        {
            _accountService = accountService;
            _accountViewMapper = accountViewMapper;
        }

        #region Read

        [HttpGet]
        public List<AccountViewModel> GetAll() =>
            _accountService.GetAllAccounts().Select(dto => _accountViewMapper.Map(dto)).ToList();

        [HttpGet]
        [Route("{id:int}")]
        public AccountViewModel Get([FromRoute] int id) => _accountViewMapper.Map(_accountService.GetAccountById(id));

        [HttpGet]
        [Route("income")]
        public decimal CheckIncome([Required] int accountId, int? categoryId) => CheckIncomePrivate(accountId, categoryId);
        
        [HttpGet]
        [Route("costs")]
        public decimal CheckCosts([Required] int accountId, int? categoryId) => CheckCostsPrivate(accountId, categoryId);
        
        #endregion

        #region Create

        [HttpPost]
        public void Create([FromBody] AccountViewModel model) =>
            _accountService.CreateAccount(_accountViewMapper.MapBack(model));

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id:int}")]
        public void Remove([FromRoute] int id) => _accountService.DeleteAccount(id);

        #endregion
        
        
        private decimal CheckIncomePrivate(int accountId, int? categoryId)
        {
            return categoryId.HasValue
                ? _accountService.CheckIncome(categoryId.Value, accountId)
                : _accountService.CheckIncome(accountId);
        }
        
        private decimal CheckCostsPrivate(int accountId, int? categoryId)
        {
            return categoryId.HasValue
                ? _accountService.CheckCosts(categoryId.Value, accountId)
                : _accountService.CheckCosts(accountId);
        }
    }
}