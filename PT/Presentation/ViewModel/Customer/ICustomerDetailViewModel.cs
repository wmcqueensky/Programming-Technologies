using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface ICustomerDetailViewModel
    {
        static ICustomerDetailViewModel CreateViewModel(int id, string firstName, string lastName, decimal balance, ICustomerModelOperation model, IErrorInformer informer)
        {
            return new CustomerDetailViewModel(id, firstName, lastName, balance, model, informer);
        }

        ICommand UpdateCustomer { get; set; }

        int CustomerId { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        decimal Balance { get; set; }
    }
}
