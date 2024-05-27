using DataLayer.API;
using Service.API;

namespace Service.Implementation;

internal class StateCRUD : IStateCRUD
{
    private IDataRepository _repository;

    public StateCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    private IStateDTO Map(IState state)
    {
        return new StateDTO(state.StateId, state.CatalogId, state.Quantity);
    }

    public async Task AddState(int id, int catalogid, int quantity)
    {
        await _repository.AddState(id, catalogid, quantity);
    }

    public async Task<IStateDTO> GetState(int id)
    {
        return this.Map(await this._repository.GetState(id));
    }

    public async Task UpdateState(int id, int catalogid, int quantity)
    {
        await this._repository.UpdateState(id, catalogid, quantity);
    }

    public async Task DeleteState(int id)
    {
        await this._repository.DeleteState(id);
    }

    public async Task<Dictionary<int, IStateDTO>> GetAllStates()
    {
        Dictionary<int, IStateDTO> result = new Dictionary<int, IStateDTO>();

        foreach (IState state in (await this._repository.GetAllStates()).Values)
        {
            result.Add(state.StateId, this.Map(state));
        }

        return result;
    }

    public async Task<int> GetStatesCount()
    {
        return await this._repository.GetStatesCount();
    }
}
