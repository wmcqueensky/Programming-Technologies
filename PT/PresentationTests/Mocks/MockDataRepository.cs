using DataLayer.Instrumentation;
using Presentation.Model.API;
using PresentationTests.FakeItems;
using Service.API;
using ServiceTest.Mocks;

namespace PresentationTests.Mocks;

internal class MockDataRepository
{
    public Dictionary<int, IProductModel> Products = new Dictionary<int, IProductModel>();

    public Dictionary<int, IEventModel> Events = new Dictionary<int, IEventModel>();

    public Dictionary<int, IStateModel> States = new Dictionary<int, IStateModel>();

    public Dictionary<int, IEmployeeModel> Employees = new Dictionary<int, IEmployeeModel>();

    public Dictionary<int, ICustomerModel> Customers = new Dictionary<int, ICustomerModel>();

    public Dictionary<int, ICatalogModel> Catalogs = new Dictionary<int, ICatalogModel>();



    public async Task AddEmployee(int id, string firstName, string lastName)
    {
        this.Employees.Add(id, new MockEmployeeDTO(id, firstName, lastName));
    }

    public async Task<IEmployeeModel> GetEmployee(int id)
    {
        return await Task.FromResult(this.Employees[id]);
    }

    public async Task UpdateEmployee(int id, string firstName, string lastName)
    {
        this.Employees[id].Name = firstName;
        this.Employees[id].Surname = lastName;
    }

    public async Task DeleteEmployee(int id)
    {
        this.Employees.Remove(id);
    }

    public async Task<Dictionary<int, IEmployeeModel>> GetAllEmployees()
    {
        return await Task.FromResult(this.Employees);
    }

    public async Task<int> GetEmployeesCount()
    {
        return await Task.FromResult(this.Employees.Count);
    }

    public bool CheckIfEmployeeExists(int id)
    {
        return this.Employees.ContainsKey(id);
    }


    public async Task AddCustomer(int id, string firstName, string lastName, decimal balance)
    {
        this.Customers.Add(id, new MockCustomerDTO(id, firstName, lastName, balance));
    }

    public async Task<ICustomerModel> GetCustomer(int id)
    {
        return await Task.FromResult(this.Customers[id]);
    }

    public async Task UpdateCustomer(int id, string firstName, string lastName, decimal balance)
    {
        this.Customers[id].Name = firstName;
        this.Customers[id].Surname = lastName;
        this.Customers[id].Balance = balance;
    }

    public async Task DeleteCustomer(int id)
    {
        this.Customers.Remove(id);
    }

    public async Task<Dictionary<int, ICustomerModel>> GetAllCustomers()
    {
        return await Task.FromResult(this.Customers);
    }

    public async Task<int> GetCustomersCount()
    {
        return await Task.FromResult(this.Customers.Count);
    }

    public bool CheckIfCustomerExists(int id)
    {
        return this.Customers.ContainsKey(id);
    }



    public async Task AddCatalog(int id, decimal price)
    {
        this.Catalogs.Add(id, new MockCatalogDTO(id, price));
    }

    public async Task<ICatalogModel> GetCatalog(int id)
    {
        return await Task.FromResult(this.Catalogs[id]);
    }

    public async Task UpdateCatalog(int id, decimal price)
    {
        this.Catalogs[id].Price = price;
    }

    public async Task DeleteCatalog(int id)
    {
        this.Catalogs.Remove(id);
    }

    public async Task<Dictionary<int, ICatalogModel>> GetAllCatalogs()
    {
        return await Task.FromResult(this.Catalogs);
    }

    public async Task<int> GetCatalogsCount()
    {
        return await Task.FromResult(this.Catalogs.Count);
    }

    public bool CheckIfCatalogExists(int id)
    {
        return this.Catalogs.ContainsKey(id);
    }


    public async Task AddProduct(int id, string name)
    {
        this.Products.Add(id, new MockProductDTO(id, name));
    }

    public async Task<IProductModel> GetProduct(int id)
    {
        return await Task.FromResult(this.Products[id]);
    }

    public async Task UpdateProduct(int id, string name)
    {
        this.Products[id].Name = name;
    }

    public async Task DeleteProduct(int id)
    {
        this.Products.Remove(id);
    }

    public async Task<Dictionary<int, IProductModel>> GetAllProducts()
    {
        return await Task.FromResult(this.Products);
    }

    public async Task<int> GetProductsCount()
    {
        return await Task.FromResult(this.Products.Count);
    }




    public async Task AddState(int id, int catalogId, int quantity)
    {
        this.States.Add(id, new MockStateDTO(id, catalogId, quantity));
    }

    public async Task<IStateModel> GetState(int id)
    {
        return await Task.FromResult(this.States[id]);
    }

    public async Task UpdateState(int id, int productId, int quantity)
    {
        this.States[id].CatalogId = productId;
        this.States[id].Quantity = quantity;
    }

    public async Task DeleteState(int id)
    {
        this.States.Remove(id);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllStates()
    {
        return await Task.FromResult(this.States);
    }

    public async Task<int> GetStatesCount()
    {
        return await Task.FromResult(this.States.Count);
    }


    public async Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid)
    {
        this.Events.Add(id, new MockEventDTO(id, stateId, employeeId, customerid, productid));
    }

    public async Task<IEventModel> GetEvent(int id)
    {
        return await Task.FromResult(this.Events[id]);
    }

    public async Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productid)
    {
        this.Events[id].StateId = stateId;
        this.Events[id].EmployeeId = employeeId;
        this.Events[id].CustomerId = customerid;
        this.Events[id].ProductId = productid;
    }

    public async Task DeleteEvent(int id)
    {
        this.States.Remove(id);
    }

    public async Task<Dictionary<int, IEventModel>> GetAllEvents()
    {
        return await Task.FromResult(this.Events);
    }

    public async Task<int> GetEventsCount()
    {
        return await Task.FromResult(this.Events.Count);
    }
}