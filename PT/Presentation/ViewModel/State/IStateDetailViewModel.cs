using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IStateDetailViewModel
{
    static IStateDetailViewModel CreateViewModel(int id, int catalogId, int quantity,
        IStateModelOperation model, IErrorInformer informer)
    {
        return new StateDetailViewModel(id, catalogId, quantity, model, informer);
    }

    ICommand UpdateState { get; set; }

    int StateId { get; set; }

    int CatalogId { get; set; }

    int Quantity { get; set; }
}
