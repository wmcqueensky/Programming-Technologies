using Greengrocery.Data.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greengrocery.Data.Implementation
{
    internal class DataContext : DbContext, IDataContext
    {
        private readonly string? _connectionString;
        public DataContext(string? connectionString = null)
        {
            this._connectionString = connectionString;
        }

        // ------------------------------------------------------------------------------
        internal List<ICatalog> catalogData = new();
        public DbSet<Catalog> _catalogDBSet { get; set; }
        public IQueryable<ICatalog> Catalog => _catalogDBSet;
        public async Task AddCatalogEntryAsync(ICatalog catalogEntry)
        {
            Catalog c = new() { Id = catalogEntry.Id, Name = catalogEntry.Name, Price = catalogEntry.Price };
            await _catalogDBSet.AddAsync(c);
            await SaveChangesAsync();
        }
        public async Task RemoveCatalogEntryAsync(int id)
        {
            Catalog? c = await _catalogDBSet.FindAsync(id);
            if (c != null)
            {
                _catalogDBSet.Remove(c);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<IUser> userData = new();
        public DbSet<User> _userDBSet { get; set; }
        public IQueryable<IUser> User => _userDBSet;
        public async Task AddUserAsync(IUser userEntry)
        {
            User u = new() { Id = userEntry.Id, FirstName = userEntry.FirstName, LastName = userEntry.LastName };
            await _userDBSet.AddAsync(u);
            await SaveChangesAsync();
        }
        public async Task RemoveUserAsync(int id)
        {
            User? u = await _userDBSet.FindAsync(id);
            if (u != null)
            {
                _userDBSet.Remove(u);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<IEvent> eventData = new();
        public DbSet<Event> _eventDBSet { get; set; }
        public IQueryable<IEvent> Event => _eventDBSet;
        public async Task AddEventAsync(IEvent eventEntry)
        {
            Event e = new() { Id = eventEntry.Id, StateId = eventEntry.StateId, UserId = eventEntry.UserId };
            await _eventDBSet.AddAsync(e);
            await SaveChangesAsync();
        }
        public async Task RemoveEventAsync(int id)
        {
            Event? e = await _eventDBSet.FindAsync(id);
            if (e != null)
            {
                _eventDBSet.Remove(e);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<IState> stateData = new();
        public DbSet<State> _stateDBSet { get; set; }
        public IQueryable<IState> State => _stateDBSet;
        public async Task AddStateAsync(IState stateEntry)
        {
            State s = new() { StateId = stateEntry.StateId, CatalogId = stateEntry.Catalog, Quantity = stateEntry.Quantity };
            await _stateDBSet.AddAsync(s);
            await SaveChangesAsync();
        }
        public async Task RemoveStateAsync(int id)
        {
            State? s = await _stateDBSet.FindAsync(id);
            if (s != null)
            {
                _stateDBSet.Remove(s);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<ICustomer> customerData = new();
        public DbSet<Customer> _customerDBSet { get; set; }
        public IQueryable<ICustomer> Customer => _customerDBSet;
        public async Task AddCustomerAsync(ICustomer customerEntry)
        {
            Customer c = new() { Id = customerEntry.Id, Name = customerEntry.Name, Surname = customerEntry.Surname, Phone = customerEntry.Phone, Email = customerEntry.Email, Balance = customerEntry.Balance };
            await _customerDBSet.AddAsync(c);
            await SaveChangesAsync();
        }
        public async Task RemoveCustomerAsync(int id)
        {
            Customer? c = await _customerDBSet.FindAsync(id);
            if (c != null)
            {
                _customerDBSet.Remove(c);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<IEmployee> employeeData = new();
        public DbSet<Employee> _employeeDBSet { get; set; }
        public IQueryable<IEmployee> Employee => _employeeDBSet;
        public async Task AddEmployeeAsync(IEmployee employeeEntry)
        {
            Employee e = new() { Id = employeeEntry.Id, Name = employeeEntry.Name, Surname = employeeEntry.Surname, Phone = employeeEntry.Phone, Email = employeeEntry.Email, Salary = employeeEntry.Salary };
            await _employeeDBSet.AddAsync(e);
            await SaveChangesAsync();
        }
        public async Task RemoveEmployeeAsync(int id)
        {
            Employee? e = await _employeeDBSet.FindAsync(id);
            if (e != null)
            {
                _employeeDBSet.Remove(e);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<ISupplier> supplierData = new();
        public DbSet<Supplier> _supplierDBSet { get; set; }
        public IQueryable<ISupplier> Supplier => _supplierDBSet;
        public async Task AddSupplierAsync(ISupplier supplierEntry)
        {
            Supplier s = new() { Id = supplierEntry.Id, Name = supplierEntry.Name, Surname = supplierEntry.Surname, Phone = supplierEntry.Phone, Email = supplierEntry.Email };
            await _supplierDBSet.AddAsync(s);
            await SaveChangesAsync();
        }
        public async Task RemoveSupplierAsync(int id)
        {
            Supplier? s = await _supplierDBSet.FindAsync(id);
            if (s != null)
            {
                _supplierDBSet.Remove(s);
                await SaveChangesAsync();
            }
        }

        // ------------------------------------------------------------------------------
        internal List<IProduct> productData = new();
        public DbSet<Product> _productDBSet { get; set; }
        public IQueryable<IProduct> Product => _productDBSet;
        public async Task AddProductAsync(IProduct productEntry)
        {
            Product p = new() { Id = productEntry.Id, Name = productEntry.Name, Type = productEntry.Type, Price = productEntry.Price };
            await _productDBSet.AddAsync(p);
            await SaveChangesAsync();
        }
        public async Task RemoveProductAsync(int id)
        {
            Product? p = await _productDBSet.FindAsync(id);
            if (p != null)
            {
                _productDBSet.Remove(p);
                await SaveChangesAsync();
            }
        }
    }
}
