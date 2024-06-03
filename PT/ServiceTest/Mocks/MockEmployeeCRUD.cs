using Service.API;
using ServiceTest.FakeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest.Mocks
{
    internal class MockEmployeeCrud : IEmployeeCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddEmployee(int id, string firstName, string lastName)
        {
            await this._dataRepository.AddEmployee(id, firstName, lastName);
        }

        public async Task DeleteEmployee(int id)
        {
            await this._dataRepository.DeleteEmployee(id);
        }

        public async Task<Dictionary<int, IEmployeeDTO>> GetAllEmployees()
        {
            return await this._dataRepository.GetAllEmployees();
        }

        public async Task<IEmployeeDTO> GetEmployee(int id)
        {
            return await this._dataRepository.GetEmployee(id);
        }

        public Task<IEmployeeDTO> GetEmployeeAsyncMethodSyntax(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetEmployeesCount()
        {
            return await this._dataRepository.GetEmployeesCount();
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName)
        {
            await this._dataRepository.UpdateEmployee(id, firstName, lastName);
        }
    }
}
