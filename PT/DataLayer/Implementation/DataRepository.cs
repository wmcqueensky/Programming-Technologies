using DataLayer.API;

namespace DataLayer.Implementation
{
    public class DataRepository : IDataRepository
    {
        private IDataContext _context;

        public DataRepository(IDataContext context)
        {
            this._context = context;
        }


        public async Task AddEmployee(int id, string firstName, string lastName)
        {
            IEmployee employee = new Employee(id, firstName, lastName);

            await this._context.AddEmployee(employee);
        }

        public async Task<IEmployee> GetEmployee(int id)
        {
            IEmployee? employee = await this._context.GetEmployeeAsyncQuerySyntax(id);

            if (employee is null)
                throw new Exception("This user does not exist!");

            return employee;
        }

        public async Task<IEmployee> GetEmployeeAsyncMethodSyntax(int id)
        {
            IEmployee? employee = await this._context.GetEmployeeAsyncMethodSyntax(id);

            if (employee is null)
                throw new Exception("This user does not exist!");

            return employee;
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName)
        {
            IEmployee employee = new Employee(id, firstName, lastName);

            if (!await this.CheckIfEmployeeExists(employee.EmployeeId))
                throw new Exception("This user does not exist");

            await this._context.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            if (!await this.CheckIfEmployeeExists(id))
                throw new Exception("This user does not exist");

            await this._context.DeleteEmployee(id);
        }

        public async Task<Dictionary<int, IEmployee>> GetAllEmployees()
        {
            return await this._context.GetAllEmployees();
        }

        public async Task<int> GetEmployeesCount()
        {
            return await this._context.GetEmployeesCount();
        }



        public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
        {
            ICustomer customer = new Customer(id, firstName, lastName, balance);

            await this._context.AddCustomer(customer);
        }

        public async Task<ICustomer> GetCustomer(int id)
        {
            ICustomer? customer = await this._context.GetCustomerAsyncQuerySyntax(id);

            if (customer is null)
                throw new Exception("This customer does not exist!");

            return customer;
        }

        public async Task<ICustomer> GetCustomerAsyncMethodSyntax(int id)
        {
            ICustomer? customer = await this._context.GetCustomerAsyncMethodSyntax(id);

            if (customer is null)
                throw new Exception("This customer does not exist!");

            return customer;
        }

        public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
        {
            ICustomer customer = new Customer(id, firstName, lastName, balance);

            if (!await this.CheckIfCustomerExists(customer.CustomerId))
                throw new Exception("This customer does not exist");

            await this._context.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            if (!await this.CheckIfCustomerExists(id))
                throw new Exception("This customer does not exist");

            await this._context.DeleteCustomer(id);
        }

        public async Task<Dictionary<int, ICustomer>> GetAllCustomers()
        {
            return await this._context.GetAllCustomers();
        }

        public async Task<int> GetCustomersCount()
        {
            return await this._context.GetCustomersCount();
        }



        public async Task AddProduct(int productId, string name)
        {
            IProduct product = new Product(productId, name);

            await this._context.AddProduct(product);
        }

        public async Task<IProduct> GetProduct(int productId)
        {
            IProduct? product = await this._context.GetProduct(productId);

            if (product is null)
                throw new Exception("This product does not exist!");

            return product;
        }

        public async Task UpdateProduct(int productId, string name)
        {
            IProduct product = new Product(productId, name);

            if (!await this.CheckIfProductExists(productId))
                throw new Exception("This product does not exist");

            await this._context.UpdateProduct(product);
        }

        public async Task DeleteProduct(int productId)
        {
            if (!await this.CheckIfProductExists(productId))
                throw new Exception("This product does not exist");

            await this._context.DeleteProduct(productId);
        }

        public async Task<Dictionary<int, IProduct>> GetAllProducts()
        {
            return await this._context.GetAllProducts();
        }

        public async Task<int> GetProductsCount()
        {
            return await this._context.GetProductsCount();
        }





        public async Task AddState(int stateId, int catalogId, int quantity)
        {
            IState state = new State(stateId, catalogId, quantity);

            await this._context.AddState(state);
        }

        public async Task<IState> GetState(int stateId)
        {
            IState? state = await this._context.GetState(stateId);

            if (state is null)
                throw new Exception("This state does not exist!");

            return state;
        }

        public async Task UpdateState(int stateId, int catalogId, int quantity)
        {
            IState state = new State(stateId, catalogId, quantity);

            if (!await this.CheckIfStateExists(stateId))
                throw new Exception("This state does not exist");

            await this._context.UpdateState(state);
        }

        public async Task DeleteState(int stateId)
        {
            if (!await this.CheckIfStateExists(stateId))
                throw new Exception("This state does not exist");

            await this._context.DeleteState(stateId);
        }

        public async Task<Dictionary<int, IState>> GetAllStates()
        {
            return await this._context.GetAllStates();
        }

        public async Task<int> GetStatesCount()
        {
            return await this._context.GetStatesCount();
        }




        public async Task AddCatalog(int catalogId, decimal price)
        {
            ICatalog catalog = new Catalog(catalogId, price);

            await this._context.AddCatalog(catalog);
        }

        public async Task<ICatalog> GetCatalog(int catalogId)
        {
            ICatalog? catalog = await this._context.GetCatalog(catalogId);

            if (catalog is null)
                throw new Exception("This catalog does not exist!");

            return catalog;
        }

        public async Task UpdateCatalog(int catalogId, decimal price)
        {
            ICatalog catalog = new Catalog(catalogId, price);

            if (!await this.CheckIfCatalogExists(catalogId))
                throw new Exception("This catalog does not exist");

            await this._context.UpdateCatalog(catalog);
        }

        public async Task DeleteCatalog(int catalogId)
        {
            if (!await this.CheckIfCatalogExists(catalogId))
                throw new Exception("This catalog does not exist");

            await this._context.DeleteCatalog(catalogId);
        }

        public async Task<Dictionary<int, ICatalog>> GetAllCatalogs()
        {
            return await this._context.GetAllCatalogs();
        }

        public async Task<int> GetCatalogsCount()
        {
            return await this._context.GetCatalogsCount();
        }







        public async Task AddEvent(int eventId, int stateId, int employeeId, int customerId, int productId)
        {
            IEmployee employee = await this.GetEmployee(employeeId);
            ICustomer customer = await this.GetCustomer(customerId);
            IState state = await this.GetState(stateId);
            IProduct product = await this.GetProduct(productId);

            IEvent newEvent = new Event(eventId, stateId, employeeId, customerId, productId);

            await this._context.AddEvent(newEvent);
        }

        public async Task<IEvent> GetEvent(int eventId)
        {
            IEvent? evnt = await this._context.GetEvent(eventId);

            if (evnt is null)
                throw new Exception("This event does not exist!");

            return evnt;
        }

        public async Task UpdateEvent(int eventId, int stateId, int employeeId, int customerId, int productId)
        {
            IEvent newEvent = new Event(eventId, stateId, employeeId, customerId, productId);

            if (!await this.CheckIfEventExists(eventId))
                throw new Exception("This event does not exist");

            await this._context.UpdateEvent(newEvent);
        }

        public async Task DeleteEvent(int eventId)
        {
            if (!await this.CheckIfEventExists(eventId))
                throw new Exception("This event does not exist");

            await this._context.DeleteEvent(eventId);
        }

        public async Task<Dictionary<int, IEvent>> GetAllEvents()
        {
            return await this._context.GetAllEvents();
        }

        public async Task<int> GetEventsCount()
        {
            return await this._context.GetEventsCount();
        }





        public async Task<bool> CheckIfEmployeeExists(int id)
        {
            return await this._context.CheckIfEmployeeExists(id);
        }

        public async Task<bool> CheckIfCustomerExists(int id)
        {
            return await this._context.CheckIfCustomerExists(id);
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return await this._context.CheckIfProductExists(id);
        }

        public async Task<bool> CheckIfStateExists(int id)
        {
            return await this._context.CheckIfStateExists(id);
        }

        public async Task<bool> CheckIfCatalogExists(int id)
        {
            return await this._context.CheckIfCatalogExists(id);
        }

        public async Task<bool> CheckIfEventExists(int id)
        {
            return await this._context.CheckIfEventExists(id);
        }
    }
}
