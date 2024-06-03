using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface IEmployeeDetailViewModel
    {
        static IEmployeeDetailViewModel CreateViewModel(int id, string firstName, string lastName, IEmployeeModelOperation model, IErrorInformer informer)
        {
            return new EmployeeDetailViewModel(id, firstName, lastName, model, informer);
        }

        ICommand UpdateEmployee { get; set; }

        int EmployeeId { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

    }
}
