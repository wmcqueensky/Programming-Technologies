using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IEventDetailViewModel
{
    static IEventDetailViewModel CreateViewModel(int id, int stateId, int employeeId, int customerId, int productId, IEventModelOperation model, IErrorInformer informer)
    {
        return new EventDetailViewModel(id, stateId, employeeId, customerId, productId, model, informer);
    }

    ICommand UpdateEvent { get; set; }

    int EventId { get; set; }
    int StateId { get; set; }

    int EmployeeId { get; set; }

    int CustomerId { get; set; }

    int ProductId { get; set; }

    DateTime EventDate { get; set; }
}
