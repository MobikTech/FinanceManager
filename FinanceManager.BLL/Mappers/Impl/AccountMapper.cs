using FinanceManager.BLL.DTO;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Mappers
{
    public class AccountMapper : IGeneralMapper<Account, AccountDTO>
    {
        public AccountDTO Map(Account entity)
        {
            return new AccountDTO()
            {
                Id = entity.Id,
                Count = entity.Count,
                Number = entity.Number
            };
        }

        public Account MapBack(AccountDTO model)
        {
            return new Account()
            {
                Count = model.Count,
                Number = model.Number
            };
        }

        public Account MapUpdate(AccountDTO model, Account entity)
        {
            throw new System.NotImplementedException();
        }
    }
}