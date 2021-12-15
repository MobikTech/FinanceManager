using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.ExceptionModels;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace FinanceManager.Tests
{
    public class CategoryServiceTests : BaseServiceTests
    {
        #region CreateCategory

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

        #region GetCategoryById

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

        #region GetCategoryByName

        [Test]
        public void GetCategoryByName_CorrectPeeking_ReturnedCategoryDTO()
        {
            string existedName = "Products";
            
            CategoryDTO actual = _categoryService.GetCategoryByName(existedName);

            int expectedId = 1;
            Assert.AreEqual(expectedId, actual.Id);
        }
        
        [Test]
        public void GetAccountByNumber_DoesntExist_Exception()
        {
            Assert.Throws(typeof(ValidationException), () => _categoryService.GetCategoryByName("wrong_name"));
        }

        #endregion

        #region GetAllACategories

        [Test]
        public void GetAllCategories_CorrectPeeking_ReturnedCategoriesDTO()
        {
            IEnumerable<CategoryDTO> actual = _categoryService.GetAllCategories();

            IEnumerable<CategoryDTO> expected = _categoryRepository.GetAll()
                .Select(category => _categporyMapper.Map(category));
            Assert.AreEqual(expected.Count(), actual.Count());
        }

        #endregion
        
        #region UpdateCategory

        [Test]
        public void UpdateCategory_CorrectUpdating_Success()
        {
            int testedCategoryId = 2;
            CategoryDTO newCategoryDto = new CategoryDTO()
            {
                Id = testedCategoryId,
                Name = "SalaryUpdated"
            };
            _categoryService.UpdateCategory(newCategoryDto);
            Category actual = _categoryRepository.GetById(testedCategoryId);
            Assert.AreEqual(newCategoryDto.Name, actual.Name);
        }
        
        [TestCase(2, null)]
        [TestCase(-10, "TestName")]
        public void UpdateCategory_WrongInputData_Exception(int id, string name)
        {
            CategoryDTO newCategoryDto = new CategoryDTO()
            {
                Id = id,
                Name = name
            };
            Assert.Throws(typeof(ValidationException), () => _categoryService.UpdateCategory(newCategoryDto));
        }

        #endregion

        #region DeleteCategory

        [Test]
        public void DeleteCategory_CorrectDeleting_ReturnedTrue()
        {
            int existedId = 3;
            Assert.Multiple(() =>
            {
                Assert.IsTrue(_categoryService.TryDeleteCategory(existedId));
                Assert.IsNull(_categoryRepository.GetById(existedId));

            });
        }
        
        [TestCase(-10)]
        public void DeleteAccount_WrongNumber_Exception(int id)
        {
            Assert.Throws(typeof(ValidationException), () => _categoryService.TryDeleteCategory(id));
        }

        #endregion
    }
}