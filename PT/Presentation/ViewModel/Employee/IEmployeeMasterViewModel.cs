using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface IEmployeeMasterViewModel
    {
        static IEmployeeMasterViewModel CreateViewModel(IEmployeeModelOperation operation, IErrorInformer informer)
        {
            return new EmployeeMasterViewModel(operation, informer);
        }

        ICommand CreateEmployee { get; set; }

        ICommand RemoveEmployee { get; set; }

        ObservableCollection<IEmployeeDetailViewModel> Employees { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        bool IsEmployeeSelected { get; set; }

        Visibility IsEmployeeDetailVisible { get; set; }

        IEmployeeDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
