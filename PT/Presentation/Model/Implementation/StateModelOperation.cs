using DataLayer.API;
using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class StateModelOperation : IStateModelOperation
{
    private IStateCRUD _stateCrud;

    public StateModelOperation(IStateCRUD? stateCrud = null)
    {
        this._stateCrud = stateCrud ?? IStateCRUD.CreateStateCRUD();
    }

    private IStateModel Map(IStateDTO state)
    {
        return new StateModel(state.StateId, state.CatalogId, state.Quantity);
    }

    public async Task AddState(int id, int catalogid, int quantity)
    {
        await this._stateCrud.AddState(id, catalogid, quantity);
    }

    public async Task<IStateModel> GetState(int stateId)
    {
        return this.Map(await this._stateCrud.GetState(stateId));
    }

    public async Task UpdateState(int id, int catalogid, int quantity)
    {
        await this._stateCrud.UpdateState(id, catalogid, quantity);
    }

    public async Task DeleteState(int stateId)
    {
        await this._stateCrud.DeleteState(stateId);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllStates()
    {
        Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

        foreach (IStateDTO state in (await this._stateCrud.GetAllStates()).Values)
        {
            result.Add(state.StateId, this.Map(state));
        }

        return result;
    }

    public async Task<int> GetStatesCount()
    {
        return await this._stateCrud.GetStatesCount();
    }
}
