using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Implementation
{
    public class AccountService : BaseService<IUnitOfWork>, IAccountService
    {
        private readonly IGeneralMapper<Account, AccountDTO> _accountMapper;

        public AccountService(IUnitOfWork uow, IGeneralMapper<Account, AccountDTO> accountMapper) 
            : base(uow)
        {
            _accountMapper = accountMapper;
        }
        
        public AccountDTO CreateAccount(AccountDTO dto)
        {
            if (dto.Number == null)
            {
                throw new ValidationException("Number cannot be a null", null);
            }
            if (Database.AccountRepository.GetByNumber(dto.Number) != null)
            {
                throw new ValidationException("Already exists account with the same number", null);
            }
            Account account = _accountMapper.MapBack(dto);
            Account result = Database.AccountRepository.Create(account);
            // if (result == null)
            // {
            //     throw new ValidationException("Couldn't create an account", null);
            // }
            Database.Save();
            return _accountMapper.Map(result);
        }

        public AccountDTO GetAccountById(int id)
        {
            Account account = Database.AccountRepository.GetById(id);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }

            return _accountMapper.Map(account);
        }
        
        public AccountDTO GetAccountByNumber(string number)
        {
            Account account = Database.AccountRepository.GetByNumber(number);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }

            return _accountMapper.Map(account);
        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            List<Account> result = Database.AccountRepository.GetAll(); 
            // if (result == null)
            // {
            //     throw new ValidationException("Here is no any account", null);
            // }
            return result.Select(_accountMapper.Map);
        }

        public decimal CheckIncome(int categoryId, int accountId)
        {
            Account account = Database.AccountRepository.GetById(accountId);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }
            decimal totalIncome = account.TransactionsAsTarget
                .Where(transaction => transaction.CategoryId == categoryId)
                .Select(transaction => transaction.Sum)
                .Sum();
            return totalIncome;
        }
        public decimal CheckCosts(int categoryId, int accountId)
        {
            Account account = Database.AccountRepository.GetById(accountId);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }
            decimal totalIncome = account.TransactionsAsSource
                .Where(transaction => transaction.CategoryId == categoryId)
                .Select(transaction => transaction.Sum)
                .Sum();
            return totalIncome;
        }

        public decimal CheckIncome(int accountId)
        {
            Account account = Database.AccountRepository.GetById(accountId);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }
            decimal totalIncome = account.TransactionsAsTarget
                .Select(transaction => transaction.Sum)
                .Sum();
            return totalIncome;
        }

        public decimal CheckCosts(int accountId)
        {
            Account account = Database.AccountRepository.GetById(accountId);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }
            decimal totalIncome = account.TransactionsAsSource
                .Select(transaction => transaction.Sum)
                .Sum();
            return totalIncome;
        }

        public bool DeleteAccount(string number)
        {
            if (number == null)
            {
                throw new ValidationException("Number cannot be null", null);
            }
            Account account = Database.AccountRepository.GetByNumber(number);
            if (account == null)
            {
                throw new ValidationException("Account doesn't exist", null);
            }
            Database.AccountRepository.Delete(account);
            Database.Save();
            return true;
        }
    }
}