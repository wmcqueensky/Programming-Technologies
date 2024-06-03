﻿using DataLayer.API;
using Service.API;

namespace Service.Implementation;

internal class EventCRUD : IEventCRUD
{
    private IDataRepository _repository;

    public EventCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    public IEventDTO Map(IEvent currentEvent)
    {
        return new EventDTO(currentEvent.EventId, currentEvent.StateId, currentEvent.EmployeeId, currentEvent.CustomerId, currentEvent.ProductId);
    }
    public async Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid)
    {
        await this._repository.AddEvent(id, stateId, employeeId, customerid, productid);
    }

    public async Task<IEventDTO> GetEvent(int id)
    {
        return this.Map(await this._repository.GetEvent(id));
    }

    public async Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productid)
    {
        await this._repository.UpdateEvent(id, stateId, employeeId, customerid, productid);
    }

    public async Task DeleteEvent(int id)
    {
        await this._repository.DeleteEvent(id);
    }

    public async Task<Dictionary<int, IEventDTO>> GetAllEvents()
    {
        Dictionary<int, IEventDTO> result = new Dictionary<int, IEventDTO>();

        foreach (IEvent currentEvent in (await this._repository.GetAllEvents()).Values)
        {
            result.Add(currentEvent.EventId, this.Map(currentEvent));
        }

        return result;
    }

    public async Task<int> GetEventsCount()
    {
        return await this._repository.GetEventsCount();
    }
}
