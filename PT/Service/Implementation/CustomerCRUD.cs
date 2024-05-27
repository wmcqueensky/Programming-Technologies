using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal class CustomerCRUD : ICustomerCRUD
    {
        private readonly IDataRepository _repository;

        public CustomerCRUD(IDataRepository repository)
        {
            this._repository = repository;
        }

        private ICustomerDTO Map(ICustomer customer)
        {
            return new CustomerDTO(customer.CustomerId, customer.Name, customer.Surname, customer.Balance);
        }

        public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._repository.AddCustomer(id, firstName, lastName, balance);
        }

        public async Task DeleteCustomer(int id)
        {
            await this._repository.DeleteCustomer(id);
        }

        public async Task<Dictionary<int, ICustomerDTO>> GetAllCustomers()
        {
            Dictionary<int, ICustomerDTO> result = new Dictionary<int, ICustomerDTO>();

            foreach (ICustomer customer in (await this._repository.GetAllCustomers()).Values)
            {
                result.Add(customer.CustomerId, this.Map(customer));
            }

            return result;
        }

        public async Task<ICustomerDTO> GetCustomer(int id)
        {
            return this.Map(await this._repository.GetCustomer(id));
        }

        public async Task<ICustomerDTO> GetCustomerAsyncMethodSyntax(int id)
        {
            return await Task.Run(() => this.Map(_repository.GetCustomer(id).Result));
        }

        public async Task<int> GetCustomersCount()
        {
            return await this._repository.GetCustomersCount();
        }

        public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._repository.UpdateCustomer(id, firstName, lastName, balance);
        }
    }
}