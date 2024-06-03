namespace Service.API;

public interface IEventDTO
{
    int EventId { get; set; }
    int StateId { get; set; }
    int EmployeeId { get; set; }
    int CustomerId { get; set; }
    int ProductId { get; set; }
    DateTime EventDate { get; }
}
