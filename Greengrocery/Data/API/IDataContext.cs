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

        IQueryable<IUser> User { get; }
        Task AddUserAsync(IUser userEntry);
        Task RemoveUserAsync(int id);

        IQueryable<IEvent> Event { get; }
        Task AddEventAsync(IEvent eventEntry);
        Task RemoveEventAsync(int id);

        IQueryable<IState> State { get; }
        Task AddStateAsync(IState stateEntry);
        Task RemoveStateAsync(int id);
    }
}
