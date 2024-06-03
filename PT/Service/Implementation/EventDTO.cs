using Service.API;

namespace Service.Implementation;

internal class EventDTO : IEventDTO
{
    public EventDTO(int id, int stateId, int employeeId, int customerid, int productid)
    {
        this.EventId = id;
        this.StateId = stateId;
        this.EmployeeId = employeeId;
        this.CustomerId = customerid;
        this.ProductId = productid;
        this.EventDate = DateTime.Now;
    }

    public int EventId { get; set; }
    public int StateId { get; set; }
    public DateTime EventDate { get; }
    public int EmployeeId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}
