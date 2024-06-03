using DataLayer.API;
using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IStateModelOperation
{
    static IStateModelOperation CreateModelOperation(IStateCRUD? stateCrud = null)
    {
        return new StateModelOperation(stateCrud ?? IStateCRUD.CreateStateCRUD());
    }

    Task AddState(int id, int catalogid, int quantity);

    Task<IStateModel> GetState(int id);

    Task UpdateState(int id, int catalogid, int quantity);

    Task DeleteState(int id);

    Task<Dictionary<int, IStateModel>> GetAllStates();

    Task<int> GetStatesCount();
}
