using Service.API;
using ServiceTest.FakeItems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceTest.Mocks
{
    internal class MockCustomerCrud : ICustomerCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        // Add Customer
        public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._dataRepository.AddCustomer(id, firstName, lastName, balance);
        }

        // Delete Customer
        public async Task DeleteCustomer(int id)
        {
            await this._dataRepository.DeleteCustomer(id);
        }

        // Get All Customers
        public async Task<Dictionary<int, ICustomerDTO>> GetAllCustomers()
        {
            return await this._dataRepository.GetAllCustomers();
        }

        // Get Customer by ID
        public async Task<ICustomerDTO> GetCustomer(int id)
        {
            return await this._dataRepository.GetCustomer(id);
        }

        // Get Customer by ID using async method syntax
        public async Task<ICustomerDTO> GetCustomerAsyncMethodSyntax(int id)
        {
            return await Task.Run(() => _dataRepository.GetCustomer(id).Result);
        }

        // Get Customers Count
        public async Task<int> GetCustomersCount()
        {
            return await this._dataRepository.GetCustomersCount();
        }

        // Update Customer
        public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._dataRepository.UpdateCustomer(id, firstName, lastName, balance);
        }
    }
}
