using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    internal interface IDataContext
    {
        IQueryable<ICatalog> Catalog { get; }
        Task AddCatalogEntryAsync(ICatalog catalogEntry);
        Task RemoveCatalogEntryAsync(int id);

        IQueryable<ICustomer> Customer { get; }
        Task AddCustomerAsync(ICustomer userEntry);
        Task RemoveCustomerAsync(int id);

        IQueryable<IEmployee> Employee { get; }
        Task AddEmployeeAsync(IEmployee userEntry);
        Task RemoveEmployeeAsync(int id);

        IQueryable<ISupplier> Supplier { get; }
        Task AddSupplierasync(ISupplier userEntry);
        Task RemoveSupplierAsync(int id);

        IQueryable<IProduct> Product { get; }
        Task AddProductasync(IProduct userEntry);
        Task RemoveProductAsync(int id);

        IQueryable<IEvent> Event { get; }
        Task AddEventAsync(IEvent eventEntry);
        Task RemoveEventAsync(int id);

        IQueryable<IState> State { get; }
        Task AddStateAsync(IState stateEntry);
        Task RemoveStateAsync(int id);
    }
}
