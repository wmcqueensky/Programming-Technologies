using DataLayer.API;
using Service.Implementation;

namespace Service.API;

public interface IStateCRUD
{
    static IStateCRUD CreateStateCRUD(IDataRepository? dataRepository = null)
    {
        return new StateCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddState(int id, int catalogid, int quantity);

    Task<IStateDTO> GetState(int id);

    Task UpdateState(int id, int catalogid, int quantity);

    Task DeleteState(int id);

    Task<Dictionary<int, IStateDTO>> GetAllStates();

    Task<int> GetStatesCount();
}
