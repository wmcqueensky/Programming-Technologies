using DataLayer.API;
using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IEventModelOperation
{
    static IEventModelOperation CreateModelOperation(IEventCRUD? eventCrud = null)
    {
        return new EventModelOperation(eventCrud ?? IEventCRUD.CreateEventCRUD());
    }

    Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid);

    Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productid);

    Task DeleteEvent(int id);

    Task<Dictionary<int, IEventModel>> GetAllEvents();

    Task<int> GetEventsCount();
}
