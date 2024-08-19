
using Microsoft.AspNetCore.Mvc;
using WebAPIMVC8CRUD.Controllers;
using WebAPIMVC8CRUD.Model;
using WebAPIMVC8CRUD.Services;

namespace UnitTestCaseDemo.Test
{
    public class CategoryControllerTest
    {
        CategoryController _controller;
        ICategoryService _service;

        public CategoryControllerTest()
        {
            _service = new CategoryService();
            _controller = new CategoryController(_service);
        }

        [Fact]
        public void GetAll_Category_Success()
        {
            //Arrange

            //Act
            var result = _controller.Get();
            var resultType = result as OkObjectResult;
            var resultList = resultType.Value as List<Category>;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(resultType.Value);
            Assert.Equal(3, resultList.Count);
        }

        [Fact]
        public void GetById_Category_Success()
        {
            //Arrange
            int valid_empid = 101;
            int invalid_empid = 110;

            //Act
            var errorResult = _controller.Get(invalid_empid);
            var successResult = _controller.Get(valid_empid);
            var successModel = successResult as OkObjectResult;
            var fetchedEmp = successModel.Value as Category;

            //Assert
            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundResult>(errorResult);
            Assert.Equal(101, fetchedEmp.CategoryId);
        }

        [Fact]
        public void Add_Category_Success()
        {
            Category category = new Category()
            {
                CategoryId = 105,
                CategoryName = "hello",

            };

            var response = _controller.Post(category);

            Assert.IsType<CreatedAtActionResult>(response);

            var createdEmp = response as CreatedAtActionResult;
            Assert.IsType<Category>(createdEmp.Value);

            var CategoryItem = createdEmp.Value as Category;

            Assert.Equal("hello", CategoryItem.CategoryName);

        }


        [Fact]
        public void Delete_Category_Success()
        {
            int valid_empid = 101;
            int invalid_empid = 110;

            var errorResult = _controller.Delete(invalid_empid);
            var successResult = _controller.Delete(valid_empid);

            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundObjectResult>(errorResult);
        }
    }
}