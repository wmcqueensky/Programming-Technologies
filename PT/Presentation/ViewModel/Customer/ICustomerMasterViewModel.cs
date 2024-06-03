using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface ICustomerMasterViewModel
    {
        static ICustomerMasterViewModel CreateViewModel(ICustomerModelOperation operation, IErrorInformer informer)
        {
            return new CustomerMasterViewModel(operation, informer);
        }

        ICommand CreateCustomer { get; set; }

        ICommand RemoveCustomer { get; set; }

        ObservableCollection<ICustomerDetailViewModel> Customers { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        decimal Balance { get; set; }


        bool IsCustomerSelected { get; set; }

        Visibility IsCustomerDetailVisible { get; set; }

        ICustomerDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
