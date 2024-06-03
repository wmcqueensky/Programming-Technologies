using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.Mocks
{
    internal class MockEmployeeCRUD : IEmployeeModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockEmployeeCRUD() { }

        public async Task AddEmployee(int id, string firstName, string lastName)
        {
            await _testRepository.AddEmployee(id, firstName, lastName);
        }

        public async Task<IEmployeeModel> GetEmployee(int id)
        {
            return await _testRepository.GetEmployee(id);
        }

        public async Task<IEmployeeModel> GetEmployeeAsyncMethodSyntax(int id)
        {
            return await Task.Run(() => _testRepository.GetEmployee(id).Result);
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName)
        {
            await _testRepository.UpdateEmployee(id, firstName, lastName);
        }

        public async Task DeleteEmployee(int id)
        {
            await _testRepository.DeleteEmployee(id);
        }

        public async Task<Dictionary<int, IEmployeeModel>> GetAllEmployees()
        {
            Dictionary<int, IEmployeeModel> result = new Dictionary<int, IEmployeeModel>();

            foreach (IEmployeeModel employee in (await _testRepository.GetAllEmployees()).Values)
            {
                result.Add(employee.EmployeeId, employee);
            }

            return result;
        }

        public async Task<int> GetEmployeesCount()
        {
            return await _testRepository.GetEmployeesCount();
        }
    }
}
