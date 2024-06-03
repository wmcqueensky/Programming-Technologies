using Service.API;
using ServiceTest.FakeItems;
using ServiceTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public async Task EmployeeServiceTests()
        {
            IEmployeeCRUD employeeCrud = new MockEmployeeCrud();
            //int id, string firstName, string lastName
            await employeeCrud.AddEmployee(1, "John", "Doe");
            //int id
            IEmployeeDTO employee = await employeeCrud.GetEmployee(1);

            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("John", employee.Name);
            Assert.AreEqual("Doe", employee.Surname);

            Assert.IsNotNull(await employeeCrud.GetAllEmployees());
            Assert.IsTrue(await employeeCrud.GetEmployeesCount() > 0);

            await employeeCrud.UpdateEmployee(1, "Johnny", "Doer");

            IEmployeeDTO updatedEmployee = await employeeCrud.GetEmployee(1);

            Assert.IsNotNull(updatedEmployee);
            Assert.AreEqual(1, updatedEmployee.EmployeeId);
            Assert.AreEqual("Johnny", updatedEmployee.Name);
            Assert.AreEqual("Doer", updatedEmployee.Surname);

            await employeeCrud.DeleteEmployee(1);
        }

        [TestMethod]
        public async Task CustomerServiceTests()
        {
            ICustomerCRUD customerCrud = new MockCustomerCrud();
            // int id, string firstName, string lastName, decimal balance
            await customerCrud.AddCustomer(1, "John", "Doe", 100.50m);
            // int id
            ICustomerDTO customer = await customerCrud.GetCustomer(1);

            Assert.IsNotNull(customer);
            Assert.AreEqual(1, customer.CustomerId);
            Assert.AreEqual("John", customer.Name);
            Assert.AreEqual("Doe", customer.Surname);
            Assert.AreEqual(100.50m, customer.Balance);

            Assert.IsNotNull(await customerCrud.GetAllCustomers());
            Assert.IsTrue(await customerCrud.GetCustomersCount() > 0);

            await customerCrud.UpdateCustomer(1, "Johnny", "Doer", 150.75m);

            ICustomerDTO updatedCustomer = await customerCrud.GetCustomer(1);

            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual(1, updatedCustomer.CustomerId);
            Assert.AreEqual("Johnny", updatedCustomer.Name);
            Assert.AreEqual("Doer", updatedCustomer.Surname);
            Assert.AreEqual(150.75m, updatedCustomer.Balance);

            await customerCrud.DeleteCustomer(1);
        }

        [TestMethod]
        public async Task ProductServiceTests()
        {
            IProductCRUD productCrud = new MockProductCRUD();
            // int id, string name
            await productCrud.AddProduct(1, "Onion");

            IProductDTO product = await productCrud.GetProduct(1);

            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.ProductId);
            Assert.AreEqual("Onion", product.Name);

            Assert.IsNotNull(await productCrud.GetAllProducts());
            Assert.IsTrue(await productCrud.GetProductsCount() > 0);

            await productCrud.UpdateProduct(1, "Onion - New");

            IProductDTO updatedProduct = await productCrud.GetProduct(1);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(1, updatedProduct.ProductId);
            Assert.AreEqual("Onion - New", updatedProduct.Name);

            await productCrud.DeleteProduct(1);
        }

        [TestMethod]
        public async Task StateServiceTests()
        {
            IProductCRUD productCrud = new MockProductCRUD();
            await productCrud.AddProduct(1, "Onion");

            IProductDTO product = await productCrud.GetProduct(1);

            IStateCRUD stateCrud = new MockStateCRUD();
            // int id, int catalogId, int quantity
            await stateCrud.AddState(1, 1, 100); // Using 1 as catalogId for simplicity

            IStateDTO state = await stateCrud.GetState(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.StateId);
            Assert.AreEqual(1, state.CatalogId);
            Assert.AreEqual(100, state.Quantity);

            await stateCrud.UpdateState(1, 1, 50); // Updating quantity to 50

            IStateDTO updatedState = await stateCrud.GetState(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual(1, updatedState.StateId);
            Assert.AreEqual(1, updatedState.CatalogId);
            Assert.AreEqual(50, updatedState.Quantity);

            await stateCrud.DeleteState(1);
            await productCrud.DeleteProduct(1);
        }

        [TestMethod]
        public async Task PlaceEventServiceTests()
        {
            IProductCRUD productCrud = new MockProductCRUD();
            await productCrud.AddProduct(1, "Onion");

            IProductDTO product = await productCrud.GetProduct(1);
            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.ProductId);
            Assert.AreEqual("Onion", product.Name);

            IStateCRUD stateCrud = new MockStateCRUD();
            await stateCrud.AddState(1, 1, 100); // Using 1 as catalogId and 100 as quantity for simplicity

            IStateDTO state = await stateCrud.GetState(1);
            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.StateId);
            Assert.AreEqual(1, state.CatalogId);
            Assert.AreEqual(100, state.Quantity);

            ICustomerCRUD customerCrud = new MockCustomerCrud();
            await customerCrud.AddCustomer(1, "John", "Doe", 100.00m);

            ICustomerDTO customer = await customerCrud.GetCustomer(1);
            Assert.IsNotNull(customer);
            Assert.AreEqual(1, customer.CustomerId);
            Assert.AreEqual("John", customer.Name);
            Assert.AreEqual("Doe", customer.Surname);
            Assert.AreEqual(100.00m, customer.Balance);

            IEmployeeCRUD employeeCrud = new MockEmployeeCrud();
            await employeeCrud.AddEmployee(1, "Jane", "Smith");

            IEmployeeDTO employee = await employeeCrud.GetEmployee(1);
            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("Jane", employee.Name);
            Assert.AreEqual("Smith", employee.Surname);

            IEventCRUD eventCrud = new MockEventCRUD();
            await eventCrud.AddEvent(1, state.StateId, employee.EmployeeId, customer.CustomerId, product.ProductId);

            IEventDTO eventDto = await eventCrud.GetEvent(1);
            Assert.IsNotNull(eventDto);
            Assert.AreEqual(1, eventDto.EventId);
            Assert.AreEqual(state.StateId, eventDto.StateId);
            Assert.AreEqual(employee.EmployeeId, eventDto.EmployeeId);
            Assert.AreEqual(customer.CustomerId, eventDto.CustomerId);
            Assert.AreEqual(product.ProductId, eventDto.ProductId);

            await eventCrud.DeleteEvent(1);
            await stateCrud.DeleteState(1);
            await productCrud.DeleteProduct(1);
            await customerCrud.DeleteCustomer(1);
            await employeeCrud.DeleteEmployee(1);
        }


        [TestMethod]
        public async Task PayedEventServiceTests()
        {
            // Initialize Product CRUD and add a product
            IProductCRUD productCrud = new MockProductCRUD();
            await productCrud.AddProduct(1, "Onion");

            IProductDTO product = await productCrud.GetProduct(1);
            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.ProductId);
            Assert.AreEqual("Onion", product.Name);

            // Initialize Catalog CRUD and add a catalog
            ICatalogCRUD catalogCrud = new MockCatalogCRUD();
            await catalogCrud.AddCatalog(1, 15.99m);

            ICatalogDTO catalog = await catalogCrud.GetCatalog(1);
            Assert.IsNotNull(catalog);
            Assert.AreEqual(1, catalog.CatalogId);
            Assert.AreEqual(15.99m, catalog.Price);

            // Initialize State CRUD and add a state
            IStateCRUD stateCrud = new MockStateCRUD();
            await stateCrud.AddState(1, catalog.CatalogId, 100); // assuming quantity instead of available flag

            IStateDTO state = await stateCrud.GetState(1);
            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.StateId);
            Assert.AreEqual(catalog.CatalogId, state.CatalogId);
            Assert.AreEqual(100, state.Quantity); // assuming quantity instead of available flag

            // Initialize Customer CRUD and add a customer
            ICustomerCRUD customerCrud = new MockCustomerCrud();
            await customerCrud.AddCustomer(1, "John", "Doe", 100.00m);

            ICustomerDTO customer = await customerCrud.GetCustomer(1);
            Assert.IsNotNull(customer);
            Assert.AreEqual(1, customer.CustomerId);
            Assert.AreEqual("John", customer.Name);
            Assert.AreEqual("Doe", customer.Surname);
            Assert.AreEqual(100.00m, customer.Balance);

            // Initialize Employee CRUD and add an employee
            IEmployeeCRUD employeeCrud = new MockEmployeeCrud();
            await employeeCrud.AddEmployee(1, "Jane", "Smith");

            IEmployeeDTO employee = await employeeCrud.GetEmployee(1);
            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("Jane", employee.Name);
            Assert.AreEqual("Smith", employee.Surname);

            // Initialize Event CRUD and add events
            IEventCRUD eventCrud = new MockEventCRUD();
            await eventCrud.AddEvent(1, state.StateId, employee.EmployeeId, customer.CustomerId, product.ProductId);
            await eventCrud.AddEvent(2, state.StateId, employee.EmployeeId, customer.CustomerId, product.ProductId);

            // Retrieve and verify the first event
            IEventDTO event1 = await eventCrud.GetEvent(1);
            Assert.IsNotNull(event1);
            Assert.AreEqual(1, event1.EventId);
            Assert.AreEqual(state.StateId, event1.StateId);
            Assert.AreEqual(employee.EmployeeId, event1.EmployeeId);
            Assert.AreEqual(customer.CustomerId, event1.CustomerId);
            Assert.AreEqual(product.ProductId, event1.ProductId);

            // Retrieve and verify the second event
            IEventDTO event2 = await eventCrud.GetEvent(2);
            Assert.IsNotNull(event2);
            Assert.AreEqual(2, event2.EventId);
            Assert.AreEqual(state.StateId, event2.StateId);
            Assert.AreEqual(employee.EmployeeId, event2.EmployeeId);
            Assert.AreEqual(customer.CustomerId, event2.CustomerId);
            Assert.AreEqual(product.ProductId, event2.ProductId);

            // Clean up: Delete events, state, product, customer, employee, and catalog
            await eventCrud.DeleteEvent(2);
            await eventCrud.DeleteEvent(1);
            await stateCrud.DeleteState(1);
            await productCrud.DeleteProduct(1);
            await customerCrud.DeleteCustomer(1);
            await employeeCrud.DeleteEmployee(1);
            await catalogCrud.DeleteCatalog(1);
        }

        [TestMethod]
        public async Task CatalogCRUDTests()
        {
            // Create instance of MockCatalogCRUD
            ICatalogCRUD catalogCrud = new MockCatalogCRUD();

            // Add a new catalog
            await catalogCrud.AddCatalog(1, 9.99m);

            // Retrieve the catalog and verify its properties
            ICatalogDTO catalog = await catalogCrud.GetCatalog(1);
            Assert.IsNotNull(catalog);
            Assert.AreEqual(1, catalog.CatalogId);
            Assert.AreEqual(9.99m, catalog.Price);

            // Update the catalog's price
            await catalogCrud.UpdateCatalog(1, 19.99m);

            // Retrieve the updated catalog and verify its new price
            catalog = await catalogCrud.GetCatalog(1);
            Assert.IsNotNull(catalog);
            Assert.AreEqual(1, catalog.CatalogId);
            Assert.AreEqual(19.99m, catalog.Price);

            // Retrieve all catalogs and verify the count
            var catalogs = await catalogCrud.GetAllCatalogs();
            Assert.AreEqual(1, catalogs.Count);

            // Retrieve catalog count using GetCatalogsCount
            int catalogCount = await catalogCrud.GetCatalogsCount();
            Assert.AreEqual(1, catalogCount);

            // Delete the catalog
            await catalogCrud.DeleteCatalog(1);

            // Verify the catalog has been deleted
            catalogs = await catalogCrud.GetAllCatalogs();
            Assert.AreEqual(0, catalogs.Count);

            catalogCount = await catalogCrud.GetCatalogsCount();
            Assert.AreEqual(0, catalogCount);
        }
    }
}
