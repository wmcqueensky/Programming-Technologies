namespace Presentation.Model.API;

public interface IEventModel
{
    int EventId { get; set; }
    int StateId { get; set; }
    int EmployeeId { get; set; }
    int CustomerId { get; set; }
    int ProductId { get; set; }
    DateTime EventDate { get; }

}
