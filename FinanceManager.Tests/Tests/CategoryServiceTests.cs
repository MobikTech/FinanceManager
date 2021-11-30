using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace FinanceManager.Tests
{
    public class CategoryServiceTests : BaseServiceTests
    {
        private ICategoryService _categoryService;
        private ICategoryRepository _categoryRepository;
        private IGeneralMapper<Category, CategoryDTO> _categporyMapper;
        
        
        public CategoryServiceTests()
        {
            _categoryService = _serviceProvider.GetService<ICategoryService>();
            _categoryRepository = _serviceProvider.GetService<IUnitOfWork>().CategoryRepository;
            _categporyMapper = _serviceProvider.GetService<IGeneralMapper<Category, CategoryDTO>>();
        }

        [SetUp]
        public void Setup()
        {
        }

        #region CreateAccount

        [Test]
        public void CreateCategory_CorrectCreating_CreatedAccountDTO()
        {
            CategoryDTO dto = new CategoryDTO() {Name = "TestCategory"};
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => { _categoryService.CreateCategory(dto);});
                Assert.NotNull(_categoryRepository.GetCategoryByName(dto.Name));
            });
        }
        
        [TestCase(null)]
        [TestCase("Salary")]
        public void CreateCategory_WrongName_Exception(string name)
        {
            CategoryDTO dto = new CategoryDTO() {Name = name};

            Assert.Throws(typeof(ValidationException), () => _categoryService.CreateCategory(dto));
        }
        

        #endregion

        #region GetAccountById

        [Test]
        public void GetCategoryById_CorrectPeeking_ReturnedCategoryDTO()
        {
            int id = 1;
            CategoryDTO actual = _categoryService.GetCategoryById(id);
            string expectedName = "Products";
            Assert.AreEqual(expectedName, actual.Name);
        }
        
        [Test]
        public void GetCategoryById_DoesntExist_Exception()
        {
            Assert.Throws(typeof(ValidationException), () => _categoryService.GetCategoryById(100));
        }

        #endregion

        #region GetAccountByNumber

        [Test]
        public void GetCategoryByName_CorrectPeeking_ReturnedCategoryDTO()
        {
            string existedNumber = "Products";
            
            CategoryDTO actual = _accountService.GetAccountByNumber(existedNumber);

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