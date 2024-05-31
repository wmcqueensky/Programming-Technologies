using DataLayer.API;
using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class CustomerModelOperation : ICustomerModelOperation
    {

        private ICustomerCRUD _customerCrud;

        public CustomerModelOperation(ICustomerCRUD? customerCrud = null)
        {
            this._customerCrud = customerCrud ?? ICustomerCRUD.CreateCustomerCRUD();
        }

        private ICustomerModel Map(ICustomer customer)
        {
            return new CustomerModel(customer.CustomerId, customer.Name, customer.Surname, customer.Balance);
        }

        public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._customerCrud.AddCustomer(id, firstName, lastName, balance);
        }

        public async Task DeleteCustomer(int id)
        {
            await this._customerCrud.DeleteCustomer(id);
        }

        public async Task<Dictionary<int, ICustomerModel>> GetAllCustomers()
        {
            Dictionary<int, ICustomerModel> result = new Dictionary<int, ICustomerModel>();

            foreach (ICustomer customer in (await this._customerCrud.GetAllCustomers()).Values)
            {
                result.Add(customer.CustomerId, this.Map(customer));
            }

            return result;
        }

        public async Task<ICustomerModel> GetCustomer(int id)
        {
            return this.Map(await this._customerCrud.GetCustomer(id));
        }

        public async Task<ICustomerModel> GetCustomerAsyncMethodSyntax(int id)
        {
            return await Task.Run(() => this.Map(_customerCrud.GetCustomer(id).Result));
        }

        public async Task<int> GetCustomersCount()
        {
            return await this._customerCrud.GetCustomersCount();
        }

        public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
        {
            await this._customerCrud.UpdateCustomer(id, firstName, lastName, balance);
        }
    }
}
