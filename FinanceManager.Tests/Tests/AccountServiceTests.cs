using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;


namespace FinanceManager.Tests
{
    public class AccountServiceTests : BaseServiceTests
    {
        private IAccountService _accountService;
        private IAccountRepository _accountRepository;
        private IGeneralMapper<Account, AccountDTO> _accountMapper;
        
        
        public AccountServiceTests()
        {
            _accountService = _serviceProvider.GetService<IAccountService>();
            _accountRepository = _serviceProvider.GetService<IUnitOfWork>().AccountRepository;
            _accountMapper = _serviceProvider.GetService<IGeneralMapper<Account, AccountDTO>>();
        }

        [SetUp]
        public void Setup()
        {
        }

        #region CreateAccount

        [Test]
        public void CreateAccount_CorrectCreating_CreatedAccountDTO()
        {
            AccountDTO dto = new AccountDTO() {Number = "1111", Count = 0};
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => { _accountService.CreateAccount(dto);});
                Assert.NotNull(_accountRepository.GetByNumber(dto.Number));
            });
        }
        
        [Test]
        public void CreateAccount_NullNumber_Exception()
        {
            AccountDTO dto = new AccountDTO() {Number = null, Count = 0};

            Assert.Throws(typeof(ValidationException), () => _accountService.CreateAccount(dto));
        }
        
        [Test]
        public void CreateAccount_AlreadyExists_Exception()
        {
            AccountDTO dto = new AccountDTO() {Number = "12345", Count = 0};
        
            Assert.Throws(typeof(ValidationException), () => _accountService.CreateAccount(dto));
        }
        

        #endregion

        #region GetAccountById

        [Test]
        public void GetAccountById_CorrectPeeking_ReturnedAccountDTO()
        {
            int id = 1;
            AccountDTO actual = _accountService.GetAccountById(id);
            string expectedNumber = "12345";
            Assert.AreEqual(expectedNumber, actual.Number);
        }
        
        [Test]
        public void GetAccountById_DoesntExist_Exception()
        {
            Assert.Throws(typeof(ValidationException), () => _accountService.GetAccountById(100));
        }

        #endregion

        #region GetAccountByNumber

        [Test]
        public void GetAccountByNumber_CorrectPeeking_ReturnedAccountDTO()
        {
            string existedNumber = "12345";
            
            AccountDTO actual = _accountService.GetAccountByNumber(existedNumber);

            int expectedId = 1;
            Assert.AreEqual(expectedId, actual.Id);
        }
        
        [Test]
        public void GetAccountByNumber_DoesntExist_Exception()
        {
            Assert.Throws(typeof(ValidationException), () => _accountService.GetAccountByNumber("wrong_number"));
        }

        #endregion

        #region GetAllAccounts

        [Test]
        public void GetAllAccounts_CorrectPeeking_ReturnedAccountsDTO()
        {
            IEnumerable<AccountDTO> actual = _accountService.GetAllAccounts();

            IEnumerable<AccountDTO> expected = _accountRepository.GetAll()
                .Select(account => _accountMapper.Map(account));
            Assert.AreEqual(expected.Count(), actual.Count());
        }

        #endregion

        #region DeleteAccount

        [Test]
        public void DeleteAccount_CorrectDeleting_ReturnedTrue()
        {
            string existingNumber = "54321";

            Assert.Multiple(() =>
            {
                Assert.IsTrue(_accountService.DeleteAccount(existingNumber));
                Assert.IsNull(_accountRepository.GetByNumber(existingNumber));
            });
        }
        
        [TestCase(null)]
        [TestCase("fffff")]
        public void DeleteAccount_WrongNumber_Exception(string number)
        {
            Assert.Throws(typeof(ValidationException), () => _accountService.DeleteAccount(number));
        }

        #endregion
        
    }
}