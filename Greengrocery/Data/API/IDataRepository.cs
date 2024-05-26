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
        Task AddProductAsync(int product_id, string name, string type, decimal price);
        Task<IProduct> GetProductAsync(int product_id);
        Task UpdateProductAsync(int product_id, string name, string type, decimal price);
        Task DeleteProductAsync(int product_id);
        Task<Dictionary<int, IProduct>> GetAllProductsAsync();
        Task<int> GetProductsCountAsync();

        Task AddStateAsync(int state_id, int catalog_id);
        Task<IState> GetStateAsync(int state_id);
        Task UpdateStateAsync(int state_id, int catalog_id);
        Task DeleteStateAsync(int state_id);
        Task<Dictionary<int, IState>> GetAllStatesAsync();
        Task<int> GetStatesCountAsync();

        Task AddEventAsync(int event_id, int state_id, int employee_id, int supplier_id, int customer_id, string type);
        Task<IEvent> GetEventAsync(int event_id);
        Task UpdateEventAsync(int event_id, int state_id, int employee_id, int supplier_id, int customer_id, string type);
        Task DeleteEventAsync(int event_id);
        Task<Dictionary<int, IEvent>> GetAllEventsAsync();
        Task<int> GetEventsCountAsync();

        Task AddEmployeeAsync(int employee_id, string name, string surname, decimal phone, string email, decimal salary);
        Task<IEmployee> GetEmployeeAsync(int employee_id);
        Task UpdateEmployeeAsync(int employee_id, string name, string surname, decimal phone, string email, decimal salary);
        Task DeleteEmployeeAsync(int employee_id);
        Task<Dictionary<int, IEmployee>> GetAllEmployeesAsync();
        Task<int> GetEmployeesCountAsync();

        Task AddSupplierAsync(int supplier_id, string name, string surname, decimal phone, string email);
        Task<ISupplier> GetSupplierAsync(int supplier_id);
        Task UpdateSupplierAsync(int supplier_id, string name, string surname, decimal phone, string email);
        Task DeleteSupplierAsync(int supplier_id);
        Task<Dictionary<int, ISupplier>> GetAllSuppliersAsync();
        Task<int> GetSuppliersCountAsync();

        Task AddCustomerAsync(int customer_id, string name, string surname, string phone, string email, decimal balance);
        Task<ICustomer> GetCustomerAsync(int customer_id);
        Task UpdateCustomerAsync(int customer_id, string name, string surname, string phone, string email, decimal balance);
        Task DeleteCustomerAsync(int customer_id);
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
