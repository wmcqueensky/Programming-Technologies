using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface ICatalogDetailViewModel
    {
        static ICatalogDetailViewModel CreateViewModel(int id, decimal price, ICatalogModelOperation model, IErrorInformer informer)
        {
            return new CatalogDetailViewModel(id, price, model, informer);
        }

        ICommand UpdateCatalog { get; set; }

        int CatalogId { get; set; }
        decimal Price { get; set; }
    }
}
