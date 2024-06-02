using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.Mocks
{
    internal class MockCustomerCRUD : ICustomerModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockEmployeeCRUD() {}

        public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._testRepository.AddCustomer(id, firstName, lastName, balance);
        }

        public async Task<ICustomerModel> GetCustomer(int id)
        {
            return await this._testRepository.GetCustomer(id);
        }

        public async Task<ICustomerModel> GetCustomerAsyncMethodSyntax(int id)
        {
            return await _testRepository.GetEmployeeAsyncMethodSyntax(id);
        }

        public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._testRepository.UpdateCustomer(id, firstName, lastName, balance);
        }

        public async Task DeleteCustomer(int id)
        {
            await _testRepository.DeleteCustomer(id);
        }

        public async Task<Dictionary<int, ICustomerModel>> GetAllCustomers()
        {
            Dictionary<int, ICustomerModel> result = new Dictionary<int, ICustomerModel>();

            foreach (ICustomerModel customer in (await _testRepository.GetAllCustomers()).Values)
            {
                result.Add(customer.CustomerId, customer);
            }

            return result;
        }

        public async Task<int> GetCustomersCount()
        {
            return await _testRepository.GetCustomersCount();
        }
    }
}
