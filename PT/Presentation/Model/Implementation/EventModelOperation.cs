using DataLayer.API;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class EventModelOperation : IEventModelOperation
{
    private IEventCRUD _eventCRUD;

    public EventModelOperation(IEventCRUD? eventCrud = null)
    {
        this._eventCRUD = eventCrud ?? IEventCRUD.CreateEventCRUD();
    }

    private IEventModel Map(IEventDTO currentEvent)
    {
        return new EventModel(currentEvent.EventId, currentEvent.StateId, currentEvent.EmployeeId, currentEvent.CustomerId, currentEvent.ProductId);
    }

    public async Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid)
    {
        await this._eventCRUD.AddEvent(id, stateId, employeeId, customerid, productid);
    }

    public async Task<IEventModel> GetEvent(int id, string type)
    {
        return this.Map(await this._eventCRUD.GetEvent(id));
    }

    public async Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productid)
    {
        await this._eventCRUD.UpdateEvent(id, stateId, employeeId, customerid, productid);
    }
    public async Task DeleteEvent(int id)
    {
        await this._eventCRUD.DeleteEvent(id);
    }
   
    public async Task<Dictionary<int, IEventModel>> GetAllEvents()
    {
        Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

        foreach (IEventDTO even in (await this._eventCRUD.GetAllEvents()).Values)
        {
            result.Add(even.EventId, this.Map(even));
        }

        return result;
    }

    public async Task<int> GetEventsCount()
    {
        return await this._eventCRUD.GetEventsCount();
    }
}
