using EmployeeService.Model;
using EmployeeService.Repository;
using EmployeeService.Repository.TestData;
using FluentAssertions;

namespace Assignment_01
{
    public class EmployeeTest
    {
        private EmployeeRepository repository;
        private EmployeeRepoData _employeeRepoData;

        public EmployeeTest()
        {
            repository = new EmployeeRepository();
            _employeeRepoData = new EmployeeRepoData();
        }

        [Fact]
        public void AddingEmployee_should_BeInRangeFromOnetoTen()
        {
            //arrange
            Employee emp = new Employee()
            {
                EmployeeId = 1,
                EmployeeTypeId = 1,
                FirstName = "TestFirst",
                LastName = "TestLast",
                MiddleName = "TestMiddle",
                DateOfBirth = new DateTime(1990, 1, 1),
                CreateDate = DateTime.Now,
                EmployeeAddress = new(),
                EmployeeType = new(),
                EmployeeSalary = new()
            };

            //act
            int value= repository.CreateEmployee(emp);

            //assert
            value.Should().BeInRange(1, 10);
        }

        [Fact]
        public void GetEmployeeCount_should_BeTheSameInEmployeeRepoDataCount() {
            //arrange
            var count = _employeeRepoData._EmployeeList.Count();

            //act 
            var value = repository.GetEmployees();

            //assert
            value.Should().HaveCount(count).Should().NotBeNull();
        }

        [Fact]
        public void GetEmployeeById_ReturnsTrue() {

            //arrange
            int id = 1;

            //act
            var value=repository.GetEmployeeById(id);

            //assert
            value.EmployeeId.Equals(id).Should().BeTrue();
        }

        [Fact]
        public void GetEmployeeById_PassWrongId_ReturnsFalse()
        {

            //arrange
            int id = 1000;

            //act
            var value = repository.GetEmployeeById(id);

            //assert
            value.EmployeeId.Equals(id).Should().BeFalse();
        }
    }
}
