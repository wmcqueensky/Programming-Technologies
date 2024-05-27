using DataLayer.API;
using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockDataRepository
    {
        public Dictionary<int, IEmployeeDTO> Employees = new Dictionary<int, IEmployeeDTO>();

        public Dictionary<int, ICustomerDTO> Customers = new Dictionary<int, ICustomerDTO>();

        public Dictionary<int, IProductDTO> Products = new Dictionary<int, IProductDTO>();

        public Dictionary<int, IStateDTO> States = new Dictionary<int, IStateDTO>();

        public Dictionary<int, ICatalogDTO> Catalogs = new Dictionary<int, ICatalogDTO>();

        public Dictionary<int, IEventDTO> Events = new Dictionary<int, IEventDTO>();

        public async Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid)
        {
            Events.Add(id, new MockEventDTO(id, stateId, employeeId, customerid, productid));
        }

        public async Task AddProduct(int id, string name)
        {
            Products.Add(id, new MockProductDTO(id, name));
        }

        public async Task AddState(int id, int catalogid, int quantity)
        {
            States.Add(id, new MockStateDTO(id, catalogid, quantity));
        }

        public async Task AddEmployee(int id, string firstName, string lastName)
        {
            Employees.Add(id, new MockEmployeeDTO(id, firstName, lastName));
        }

        public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
        {
            Customers.Add(id, new MockCustomerDTO(id, firstName, lastName, balance));
        }

        public async Task DeleteEvent(int id)
        {
            Events.Remove(id);
        }

        public async Task DeleteProduct(int id)
        {
            Products.Remove(id);
        }

        public async Task DeleteState(int id)
        {
            States.Remove(id);
        }

        public async Task DeleteCustomer(int id)
        {
            Customers.Remove(id);
        }

        public async Task DeleteEmployee(int id)
        {
            Employees.Remove(id);
        }

        public async Task<Dictionary<int, IEventDTO>> GetAllEvents()
        {
            return await Task.FromResult(Events);
        }

        public async Task<Dictionary<int, IProductDTO>> GetAllProducts()
        {
            return await Task.FromResult(Products);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStates()
        {
            return await Task.FromResult(States);
        }

        public async Task<Dictionary<int, IEmployeeDTO>> GetAllEmployees()
        {
            return await Task.FromResult(Employees);
        }

        public async Task<Dictionary<int, ICustomerDTO>> GetAllCustomers()
        {
            return await Task.FromResult(Customers);
        }

        public async Task<IEventDTO> GetEvent(int id)
        {
            return await Task.FromResult(Events[id]);
        }

        public async Task<int> GetEventsCount()
        {
            return await Task.FromResult(Events.Count);
        }

        public async Task<IProductDTO> GetProduct(int id)
        {
            return await Task.FromResult(Products[id]);
        }

        public async Task<int> GetProductsCount()
        {
            return await Task.FromResult(Products.Count);
        }

        public async Task<IStateDTO> GetState(int id)
        {
            return await Task.FromResult(States[id]);
        }

        public async Task<int> GetStatesCount()
        {
            return await Task.FromResult(States.Count);
        }

        public async Task<IEmployeeDTO> GetEmployee(int id)
        {
            return await Task.FromResult(Employees[id]);
        }

        public async Task<int> GetEmployeesCount()
        {
            return await Task.FromResult(Employees.Count);
        }

        public async Task<ICustomerDTO> GetCustomer(int id)
        {
            return await Task.FromResult(Customers[id]);
        }

        public async Task<int> GetCustomersCount()
        {
            return await Task.FromResult(Customers.Count);
        }

        public async Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productid)
        {
            Events[id].StateId = stateId;
            Events[id].EmployeeId = employeeId;
            Events[id].CustomerId = customerid;
            Events[id].ProductId = productid;
        }

        public async Task UpdateProduct(int id, string name)
        {
            Products[id].Name = name;
        }

        public async Task UpdateState(int id, int catalogid, int quantity)
        {
            States[id].CatalogId = catalogid;
            States[id].Quantity = quantity;
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName)
        {
            Employees[id].Name = firstName;
            Employees[id].Surname = lastName;
        }

        public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
        {
            Customers[id].Name = firstName;
            Customers[id].Surname = lastName;
            Customers[id].Balance = balance;
        }
    }
}
