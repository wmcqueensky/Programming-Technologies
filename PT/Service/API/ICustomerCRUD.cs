using DataLayer.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface ICustomerCRUD
    {
        static ICustomerCRUD CreateUserCRUD(IDataRepository? dataRepository = null)
        {
            return new CustomerCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
        }

        Task AddCustomer(int id, string firstName, string lastName, decimal balance);
        Task<ICustomerDTO> GetCustomer(int id);
        Task<ICustomerDTO> GetCustomerAsyncMethodSyntax(int id);
        Task UpdateCustomer(int id, string firstName, string lastName, decimal balance);
        Task DeleteCustomer(int id);
        Task<Dictionary<int, ICustomerDTO>> GetAllCustomers();
        Task<int> GetCustomersCount();
    }
}
