using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.PL.WebApi.Models;

namespace FinanceManager.PL.WebApi.Mappers
{
    public class AccountViewMapper : IMap<AccountDTO, AccountViewModel>, IMapBack<AccountViewModel, AccountDTO>
    {
        private readonly IAccountService _accountService;

        public AccountViewMapper(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public AccountViewModel Map(AccountDTO dto)
        {
            return new AccountViewModel()
            {
                Id = dto.Id,
                Number = dto.Number,
                Count = dto.Count
            };
        }

        public AccountDTO MapBack(AccountViewModel model)
        {
            return new AccountDTO()
            {
                // Id = model.Id,
                Number = model.Number,
                Count = model.Count
            };
        }
    }
}