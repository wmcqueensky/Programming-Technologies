using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IProductDetailViewModel
{
    static IProductDetailViewModel CreateViewModel(int id, string name, IProductModelOperation model, IErrorInformer informer)
    {
        return new ProductDetailViewModel(id, name, model, informer);
    }

    ICommand UpdateProduct { get; set; }

    int ProductId { get; set; }

    string Name { get; set; }
}
