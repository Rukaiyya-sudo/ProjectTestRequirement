using Microsoft.AspNetCore.Mvc;
using WebAPIMVC8CRUD.Controllers;
using WebAPIMVC8CRUD.Models;


namespace CoreServices.Test
{
    public class CategoryControllerTest
    {
        [Fact]
       {
        CategoryController _controller;
        

        public CategoryControllerTest()
        {
            _service = new EmployeeService();
            _controller = new EmployeeController(_service);
        }

        [Fact]
        public void GetAll_Employee_Success()
        {
            //Arrange

            //Act
            var result = _controller.Get();
            var resultType = result as OkObjectResult;
            var resultList = resultType.Value as List<Employee>;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Employee>>(resultType.Value);
            Assert.Equal(3, resultList.Count);
        }

        [Fact]
        public void GetById_Employee_Success()
        {
            //Arrange
            int valid_empid = 101;
            int invalid_empid = 110;

            //Act
            var errorResult = _controller.Get(invalid_empid);
            var successResult = _controller.Get(valid_empid);
            var successModel = successResult as OkObjectResult;
            var fetchedEmp = successModel.Value as Employee;

            //Assert
            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundResult>(errorResult);
            Assert.Equal(101, fetchedEmp.Id);
        }

        [Fact]
        public void Add_Employee_Success()
        {
            Employee employee = new Employee()
            {
                Id = 105,
                Name = "Shane Warne",
                PhoneNo = "5555555555",
                EmailId = "shane@email.com"
            };

            var response = _controller.Post(employee);

            Assert.IsType<CreatedAtActionResult>(response);

            var createdEmp = response as CreatedAtActionResult;
            Assert.IsType<Employee>(createdEmp.Value);

            var employeeItem = createdEmp.Value as Employee;

            Assert.Equal("Shane Warne", employeeItem.Name);
            Assert.Equal("5555555555", employeeItem.PhoneNo);
            Assert.Equal("shane@email.com", employeeItem.EmailId);
        }


        [Fact]
        public void Delete_Employee_Success()
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
