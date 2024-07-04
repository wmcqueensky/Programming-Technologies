using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class CustomerDetailViewModel : IViewModel, ICustomerDetailViewModel
{
    public ICommand UpdateCustomer { get; set; }

    private readonly ICustomerModelOperation _modelOperation;



    private int _customerId;

    public int CustomerId
    {
        get => _customerId;
        set
        {
            _customerId = value;
            OnPropertyChanged(nameof(CustomerId));
        }
    }

    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private string _surname;

    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }

    private decimal _balance;

    public decimal Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            OnPropertyChanged(nameof(Balance));
        }
    }

    public CustomerDetailViewModel(ICustomerModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateCustomer = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? ICustomerModelOperation.CreateModelOperation();

    }

    public CustomerDetailViewModel(int id, string firstName, string lastName, decimal balance, ICustomerModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.CustomerId = id;
        this.Name = firstName;
        this.Surname = lastName;
        this.Balance = balance;

        this.UpdateCustomer = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? ICustomerModelOperation.CreateModelOperation();

    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateCustomer(this.CustomerId, this.Name, this.Surname, this.Balance);

            Informer.InformSuccess("Customer successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Name) ||
            string.IsNullOrWhiteSpace(this.Surname)
        );
    }
}
