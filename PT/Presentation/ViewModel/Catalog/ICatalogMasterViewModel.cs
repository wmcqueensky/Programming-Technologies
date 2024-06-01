using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface ICatalogMasterViewModel
    {
        static ICatalogMasterViewModel CreateViewModel(ICatalogModelOperation operation, IErrorInformer informer)
        {
            return new CatalogMasterViewModel(operation, informer);
        }

        ICommand CreateCatalog { get; set; }

        ICommand RemoveCatalog { get; set; }

        ObservableCollection<ICatalogDetailViewModel> Catalogs { get; set; }

        bool IsCatalogSelected { get; set; }

        Visibility IsCatalogDetailVisible { get; set; }

        ICatalogDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
