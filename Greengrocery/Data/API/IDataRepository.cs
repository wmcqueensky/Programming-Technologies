using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    public interface IDataRepository
    {
        Task AddUserAsync(int id, string firstName, string lastName);
        Task<IUser> GetUserAsync(int id);
        Task<IUser> GetUserAsyncMethodSyntax(int id);
        Task UpdateUserAsync(int id, string firstName, string lastName);
        Task DeleteUserAsync(int id);
        Task<Dictionary<int, IUser>> GetAllUsersAsync();
        Task<int> GetUsersCountAsync();

        Task AddProductAsync(int id, string name, string description, decimal price);
        Task<IProduct> GetProductAsync(int id);
        Task UpdateProductAsync(int id, string name, string description, decimal price);
        Task DeleteProductAsync(int id);
        Task<Dictionary<int, IProduct>> GetAllProductsAsync();
        Task<int> GetProductsCountAsync();

        Task AddStateAsync(int id, int productId, bool available);
        Task<IState> GetStateAsync(int id);
        Task UpdateStateAsync(int id, int productId, bool available);
        Task DeleteStateAsync(int id);
        Task<Dictionary<int, IState>> GetAllStatesAsync();
        Task<int> GetStatesCountAsync();

        Task AddEventAsync(int id, int stateId, int userId, string type);
        Task<IEvent> GetEventAsync(int id);
        Task UpdateEventAsync(int id, int stateId, int userId, string type);
        Task DeleteEventAsync(int id);
        Task<Dictionary<int, IEvent>> GetAllEventsAsync();
        Task<int> GetEventsCountAsync();
    }
}
