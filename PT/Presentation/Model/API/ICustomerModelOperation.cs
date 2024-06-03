using DataLayer.API;
using Presentation.Model.Implementation;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface ICustomerModelOperation
    {
        static ICustomerModelOperation CreateModelOperation(ICustomerCRUD? customerCrud = null)
        {
            return new CustomerModelOperation(customerCrud ?? ICustomerCRUD.CreateCustomerCRUD());
        }

        Task AddCustomer(int id, string firstName, string lastName, decimal balance);
        Task<ICustomerModel> GetCustomer(int id);
        Task<ICustomerModel> GetCustomerAsyncMethodSyntax(int id);
        Task UpdateCustomer(int id, string firstName, string lastName, decimal balance);
        Task DeleteCustomer(int id);
        Task<Dictionary<int, ICustomerModel>> GetAllCustomers();
        Task<int> GetCustomersCount();
    }
}
