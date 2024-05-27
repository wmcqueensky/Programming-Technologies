using DataLayer.API;
using DataLayer.Instrumentation;
using Microsoft.Extensions.Logging;

namespace DataLayer.Implementation
{
    internal class DataContext : IDataContext
    {
        public DataContext(string? connectionString = null)
        {
            this.ConnectionString = connectionString;
        }

        private readonly string ConnectionString;

        public async Task AddEmployee(IEmployee employee)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Employee entity = new Instrumentation.Employee()
                {
                    EmployeeId = employee.EmployeeId,
                    Name = employee.Name,
                    Surname = employee.Surname,
                };

                context.Employees.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IEmployee?> GetEmployeeAsyncQuerySyntax(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Employee? employee = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Employee> query =
                        from e in context.Employees
                        where e.EmployeeId == id
                        select e;

                    return query.FirstOrDefault();
                });

                return employee is not null ? new Employee(employee.EmployeeId, employee.Name, employee.Surname) : null;
            }
        }

        public async Task<IEmployee?> GetEmployeeAsyncMethodSyntax(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Employee? employee = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Employee> query = context.Employees.Where(e => e.EmployeeId == id);

                    return query.FirstOrDefault();
                });

                return employee is not null ? new Employee(employee.EmployeeId, employee.Name, employee.Surname) : null;
            }
        }

        public async Task UpdateEmployee(IEmployee employee)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Employee toUpdate = (from e in context.Employees where e.EmployeeId == employee.EmployeeId select e).FirstOrDefault()!;

                toUpdate.EmployeeId = employee.EmployeeId;
                toUpdate.Name = employee.Name;
                toUpdate.Surname = employee.Surname;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteEmployee(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Employee toDelete = (from e in context.Employees where e.EmployeeId == id select e).FirstOrDefault()!;

                context.Employees.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IEmployee>> GetAllEmployees()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                IQueryable<IEmployee> usersQuery = from e in context.Employees
                                               select
                                                   new Employee(e.EmployeeId, e.Name, e.Surname) as IEmployee;

                return await Task.Run(() => usersQuery.ToDictionary(k => k.EmployeeId));
            }
        }

        public async Task<int> GetEmployeesCount()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Employees.Count());
            }
        }

        public async Task AddCustomer(ICustomer customer)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Customer entity = new Instrumentation.Customer()
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Balance = customer.Balance
                };

                context.Customers.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<ICustomer?> GetCustomerAsyncQuerySyntax(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Customer? customer = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Customer> query =
                        from c in context.Customers
                        where c.CustomerId == id
                        select c;

                    return query.FirstOrDefault();
                });

                return customer is not null ? new Customer(customer.CustomerId, customer.Name, customer.Surname, customer.Balance) : null;
            }
        }

        public async Task<ICustomer?> GetCustomerAsyncMethodSyntax(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Customer? customer = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Customer> query = context.Customers.Where(c => c.CustomerId == id);

                    return query.FirstOrDefault();
                });

                return customer is not null ? new Customer(customer.CustomerId, customer.Name, customer.Surname, customer.Balance) : null;
            }
        }

        public async Task UpdateCustomer(ICustomer customer)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Customer toUpdate = (from c in context.Customers where c.CustomerId == customer.CustomerId select c).FirstOrDefault()!;

                toUpdate.CustomerId = customer.CustomerId;
                toUpdate.Name = customer.Name;
                toUpdate.Surname = customer.Surname;
                toUpdate.Balance = customer.Balance;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteCustomer(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Customer toDelete = (from c in context.Customers where c.CustomerId == id select c).FirstOrDefault()!;

                context.Customers.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, ICustomer>> GetAllCustomers()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                IQueryable<ICustomer> customersQuery = from c in context.Customers
                                                       select
                                                           new Customer(c.CustomerId, c.Name, c.Surname, c.Balance) as ICustomer;

                return await Task.Run(() => customersQuery.ToDictionary(k => k.CustomerId));
            }
        }

        public async Task<int> GetCustomersCount()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Customers.Count());
            }
        }


        public async Task AddProduct(IProduct product)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Product entity = new Instrumentation.Product()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                };

                context.Products.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IProduct?> GetProduct(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Product? product = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Product> query =
                        from p in context.Products
                        where p.ProductId == id
                        select p;

                    return query.FirstOrDefault();
                });

                return product is not null ? new Product(product.ProductId, product.Name) : null;
            }
        }

        public async Task UpdateProduct(IProduct product)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Product toUpdate = (from p in context.Products where p.ProductId == product.ProductId select p).FirstOrDefault()!;

                toUpdate.Name = product.Name;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Product toDelete = (from p in context.Products where p.ProductId == id select p).FirstOrDefault()!;

                context.Products.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IProduct>> GetAllProducts()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                IQueryable<IProduct> productQuery = from p in context.Products
                                                    select
                                                        new Product(p.ProductId, p.Name) as IProduct;

                return await Task.Run(() => productQuery.ToDictionary(k => k.ProductId));
            }
        }

        public async Task<int> GetProductsCount()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Products.Count());
            }
        }




        public async Task AddState(IState state)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.State entity = new Instrumentation.State()
                {
                    StateId = state.StateId,
                    CatalogId = state.CatalogId,
                    Quantity = state.Quantity,
                };

                context.States.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IState?> GetState(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.State? state = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.State> query =
                        from s in context.States
                        where s.StateId == id
                        select s;

                    return query.FirstOrDefault();
                });

                return state is not null ? new State(state.StateId, (int)state.CatalogId, (int)state.Quantity) : null;
            }
        }

        public async Task UpdateState(IState state)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.State toUpdate = (from s in context.States where s.StateId == state.StateId select s).FirstOrDefault()!;

                toUpdate.CatalogId = state.CatalogId;
                toUpdate.Quantity = state.Quantity;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteState(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.State toDelete = (from s in context.States where s.StateId == id select s).FirstOrDefault()!;

                context.States.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IState>> GetAllStates()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                IQueryable<IState> stateQuery = from s in context.States
                                                select
                                                    (new State(s.StateId, (int)s.CatalogId, (int)s.Quantity) as IState);

                return await Task.Run(() => stateQuery.ToDictionary(k => k.StateId));
            }
        }

        public async Task<int> GetStatesCount()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.States.Count());
            }
        }




        public async Task AddEvent(IEvent e)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Event entity = new Instrumentation.Event()
                {
                    EventId = e.EventId,
                    StateId = e.StateId,
                    EmployeeId = e.EmployeeId,
                    CustomerId = e.CustomerId,
                    ProductId = e.ProductId,
                    EventDate = e.EventDate,
                };

                context.Events.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IEvent?> GetEvent(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Event? evend = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Event> query =
                        from e in context.Events
                        where e.EventId == id
                        select e;

                    return query.FirstOrDefault();
                });

                return evend is not null ? new Event(evend.EventId, evend.StateId, evend.EmployeeId, evend.CustomerId, (int)evend.ProductId) : null;
            }
        }

        public async Task UpdateEvent(IEvent evend)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Event toUpdate = (from e in context.Events where e.EventId == evend.EventId select e).FirstOrDefault()!;
                
                toUpdate.EventId = evend.EventId;
                toUpdate.StateId = evend.StateId;
                toUpdate.EmployeeId = evend.EmployeeId;
                toUpdate.CustomerId = evend.CustomerId;
                toUpdate.ProductId = evend.ProductId;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteEvent(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Event toDelete = (from e in context.Events where e.EventId == id select e).FirstOrDefault()!;

                context.Events.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IEvent>> GetAllEvents()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                IQueryable<IEvent> eventQuery = from e in context.Events
                                                select
                                                    (new Event(e.EventId, e.StateId, e.EmployeeId, e.CustomerId, (int)e.ProductId) as IEvent);

                return await Task.Run(() => eventQuery.ToDictionary(k => k.EventId));
            }
        }

        public async Task<int> GetEventsCount()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Events.Count());
            }
        }







        public async Task AddCatalog(ICatalog catalog)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Catalog entity = new Instrumentation.Catalog()
                {
                    CatalogId = catalog.CatalogId,
                    Price = catalog.Price
                };

                context.Catalogs.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<ICatalog?> GetCatalog(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Catalog? catalog = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Catalog> query =
                        from c in context.Catalogs
                        where c.CatalogId == id
                        select c;

                    return query.FirstOrDefault();
                });

                return catalog is not null ? new Catalog(catalog.CatalogId, (decimal)catalog.Price) : null;
            }
        }

        public async Task UpdateCatalog(ICatalog catalog)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Catalog toUpdate = (from c in context.Catalogs where c.CatalogId == catalog.CatalogId select c).FirstOrDefault()!;

                toUpdate.Price = catalog.Price;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteCatalog(int id)
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                Instrumentation.Catalog toDelete = (from c in context.Catalogs where c.CatalogId == id select c).FirstOrDefault()!;

                context.Catalogs.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, ICatalog>> GetAllCatalogs()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                IQueryable<ICatalog> catalogQuery = from c in context.Catalogs
                                                    select
                                                        (new Catalog(c.CatalogId, (decimal)c.Price) as ICatalog);

                return await Task.Run(() => catalogQuery.ToDictionary(k => k.CatalogId));
            }
        }

        public async Task<int> GetCatalogsCount()
        {
            using (GreengrocersDataContext context = new GreengrocersDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Catalogs.Count());
            }
        }








        public async Task<bool> CheckIfCustomerExists(int id)
        {
            return (await this.GetCustomerAsyncQuerySyntax(id)) != null;
        }

        public async Task<bool> CheckIfEmployeeExists(int id)
        {
            return (await this.GetEmployeeAsyncQuerySyntax(id)) != null;
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return (await this.GetProduct(id)) != null;
        }

        public async Task<bool> CheckIfStateExists(int id)
        {
            return (await this.GetState(id)) != null;
        }

        public async Task<bool> CheckIfEventExists(int id)
        {
            return (await this.GetEvent(id)) != null;
        }
    }
}
