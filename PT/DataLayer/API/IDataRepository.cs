using DataLayer.Implementation;

namespace DataLayer.API
{   //We store all data manipulation methods here for use with Dependency Injection
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(string connectionString)
        {
            return new DataRepository(new DataContext(connectionString));
        }

        Task AddEmployee(int id, string firstName, string lastName);
        Task<IEmployee> GetEmployee(int id);
        Task<IEmployee> GetEmployeeAsyncMethodSyntax(int id);
        Task UpdateEmployee(int id, string firstName, string lastName);
        Task DeleteEmployee(int id);
        Task<Dictionary<int, IEmployee>> GetAllEmployees();
        Task<int> GetEmployeesCount();

        Task AddCustomer(int id, string firstName, string lastName, decimal balance);
        Task<ICustomer> GetCustomer(int id);
        Task<ICustomer> GetCustomerAsyncMethodSyntax(int id);
        Task UpdateCustomer(int id, string firstName, string lastName, decimal balance);
        Task DeleteCustomer(int id);
        Task<Dictionary<int, ICustomer>> GetAllCustomers();
        Task<int> GetCustomersCount();

        Task AddProduct(int id, string name);
        Task<IProduct> GetProduct(int id);
        Task UpdateProduct(int id, string name);
        Task DeleteProduct(int id);
        Task<Dictionary<int, IProduct>> GetAllProducts();
        Task<int> GetProductsCount();

        Task AddState(int id, int catalogid, decimal price);
        Task<IState> GetState(int id);
        Task UpdateState(int id, int catalogid, decimal price);
        Task DeleteState(int id);
        Task<Dictionary<int, IState>> GetAllStates();
        Task<int> GetStatesCount();

        Task AddCatalog(int id, decimal price);
        Task<ICatalog> GetCatalog(int id);
        Task UpdateCatalog(int id, decimal price);
        Task DeleteCatalog(int id);
        Task<Dictionary<int, ICatalog>> GetAllCatalogs();
        Task<int> GetCatalogsCount();

        Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid);
        Task<IEvent> GetEvent(int id);
        Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productid);
        Task DeleteEvent(int id);
        Task<Dictionary<int, IEvent>> GetAllEvents();
        Task<int> GetEventsCount();
    }
}