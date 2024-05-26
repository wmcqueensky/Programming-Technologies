using Greengrocery.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    public interface IDataRepository
    {
        // Methods for User entity
        Task AddUserAsync(int id, string firstName, string lastName);
        Task<IUser> GetUserAsync(int id);
        Task<IUser> GetUserAsyncMethodSyntax(int id);
        Task UpdateUserAsync(int id, string firstName, string lastName);
        Task DeleteUserAsync(int id);
        Task<Dictionary<int, IUser>> GetAllUsersAsync();
        Task<int> GetUsersCountAsync();

        // Methods for Product entity
        Task AddProductAsync(int id, string name, string description, decimal price);
        Task<IProduct> GetProductAsync(int id);
        Task UpdateProductAsync(int id, string name, string description, decimal price);
        Task DeleteProductAsync(int id);
        Task<Dictionary<int, IProduct>> GetAllProductsAsync();
        Task<int> GetProductsCountAsync();

        // Methods for State entity
        Task AddStateAsync(int id, int productId, bool available);
        Task<IState> GetStateAsync(int id);
        Task UpdateStateAsync(int id, int productId, bool available);
        Task DeleteStateAsync(int id);
        Task<Dictionary<int, IState>> GetAllStatesAsync();
        Task<int> GetStatesCountAsync();

        // Methods for Event entity
        Task AddEventAsync(int id, int stateId, int userId, string type);
        Task<IEvent> GetEventAsync(int id);
        Task UpdateEventAsync(int id, int stateId, int userId, string type);
        Task DeleteEventAsync(int id);
        Task<Dictionary<int, IEvent>> GetAllEventsAsync();
        Task<int> GetEventsCountAsync();

        // Methods for Employee entity
        Task AddEmployeeAsync(int id, string firstName, string lastName, decimal salary);
        Task<IEmployee> GetEmployeeAsync(int id);
        Task UpdateEmployeeAsync(int id, string firstName, string lastName, decimal salary);
        Task DeleteEmployeeAsync(int id);
        Task<Dictionary<int, IEmployee>> GetAllEmployeesAsync();
        Task<int> GetEmployeesCountAsync();

        // Methods for Supplier entity
        Task AddSupplierAsync(int id, string name, string email, string phone, int supplierId);
        Task<ISupplier> GetSupplierAsync(int id);
        Task UpdateSupplierAsync(int id, string name, string email, string phone, int supplierId);
        Task DeleteSupplierAsync(int id);
        Task<Dictionary<int, ISupplier>> GetAllSuppliersAsync();
        Task<int> GetSuppliersCountAsync();

        // Methods for Customer entity
        Task AddCustomerAsync(int id, string name, string email, string phone, int customerId, decimal balance);
        Task<ICustomer> GetCustomerAsync(int id);
        Task UpdateCustomerAsync(int id, string name, string email, string phone, int customerId, decimal balance);
        Task DeleteCustomerAsync(int id);
        Task<Dictionary<int, ICustomer>> GetAllCustomersAsync();
        Task<int> GetCustomersCountAsync();

        public abstract void ClearAll();

        public static IDataRepository CreateNewRepository()
        {
            return new DataRepository();
        }

        public static IDataRepository CreateNewRepository(string connectionString)
        {
            return new DataRepository(connectionString);
        }

    }
}
