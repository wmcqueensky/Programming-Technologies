using DataLayer.Implementation;
using DataLayer.Instrumentation;

namespace DataLayer.API
{
    public interface IDataContext
    {

        static IDataContext CreateContext(string? connectionString = null)
        {
            return new DataContext(connectionString);
        }

        Task AddEmployee(IEmployee employee);
        Task<IEmployee?> GetEmployeeAsyncQuerySyntax(int id);
        Task<IEmployee?> GetEmployeeAsyncMethodSyntax(int id);
        Task UpdateEmployee(IEmployee employee);
        Task DeleteEmployee(int id);
        Task<Dictionary<int, IEmployee>> GetAllEmployees();
        Task<int> GetEmployeesCount();

        Task AddCustomer(ICustomer customer);
        Task<ICustomer?> GetCustomerAsyncQuerySyntax(int id);
        Task<ICustomer?> GetCustomerAsyncMethodSyntax(int id);
        Task UpdateCustomer(ICustomer customer);
        Task DeleteCustomer(int id);
        Task<Dictionary<int, ICustomer>> GetAllCustomers();
        Task<int> GetCustomersCount();

        Task AddProduct(IProduct product);
        Task<IProduct?> GetProduct(int id);
        Task UpdateProduct(IProduct product);
        Task DeleteProduct(int id);
        Task<Dictionary<int, IProduct>> GetAllProducts();
        Task<int> GetProductsCount();

        Task AddState(IState state);
        Task<IState?> GetState(int id);
        Task UpdateState(IState state);
        Task DeleteState(int id);
        Task<Dictionary<int, IState>> GetAllStates();
        Task<int> GetStatesCount();

        Task AddCatalog(ICatalog catalog);
        Task<ICatalog?> GetCatalog(int id);
        Task UpdateCatalog(ICatalog catalog);
        Task DeleteCatalog(int id);
        Task<Dictionary<int, ICatalog>> GetAllCatalogs();
        Task<int> GetCatalogsCount();

        Task AddEvent(IEvent even);
        Task<IEvent?> GetEvent(int id);
        Task UpdateEvent(IEvent even);
        Task DeleteEvent(int id);
        Task<Dictionary<int, IEvent>> GetAllEvents();
        Task<int> GetEventsCount();

        Task<bool> CheckIfEmployeeExists(int id);
        Task<bool> CheckIfCustomerExists(int id);
        Task<bool> CheckIfProductExists(int id);
        Task<bool> CheckIfStateExists(int id);
        Task<bool> CheckIfEventExists(int id);
    }
}
