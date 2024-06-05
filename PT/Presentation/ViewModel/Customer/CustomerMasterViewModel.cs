using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class CustomerMasterViewModel : IViewModel, ICustomerMasterViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand SwitchToCatalogMasterPage { get; set; }

    public ICommand SwitchToEmployeeMasterPage { get; set; }

    public ICommand CreateCustomer { get; set; }

    public ICommand RemoveCustomer { get; set; }

    private readonly ICustomerModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<ICustomerDetailViewModel> _customers;

    public ObservableCollection<ICustomerDetailViewModel> Customers
    {
        get => _customers;
        set
        {
            _customers = value;
            OnPropertyChanged(nameof(Customers));
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

    private bool _isCustomerSelected;

    public bool IsCustomerSelected
    {
        get => _isCustomerSelected;
        set
        {
            this.IsCustomerDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isCustomerSelected = value;
            OnPropertyChanged(nameof(IsCustomerSelected));
        }
    }

    private Visibility _isCustomerDetailVisible;

    public Visibility IsCustomerDetailVisible
    {
        get => _isCustomerDetailVisible;
        set
        {
            _isCustomerDetailVisible = value;
            OnPropertyChanged(nameof(IsCustomerDetailVisible));
        }
    }

    private ICustomerDetailViewModel _selectedDetailViewModel;

    public ICustomerDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsCustomerSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public CustomerMasterViewModel(ICustomerModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");
        this.SwitchToCatalogMasterPage = new SwitchViewCommand("CatalogMasterView");
        this.SwitchToEmployeeMasterPage = new SwitchViewCommand("CustomerMasterView");

        this.CreateCustomer = new OnClickCommand(e => this.StoreCustomer(), c => this.CanStoreCustomer());
        this.RemoveCustomer = new OnClickCommand(e => this.DeleteCustomer());

        this.Customers = new ObservableCollection<ICustomerDetailViewModel>();

        this._modelOperation = model ?? ICustomerModelOperation.CreateModelOperation();

        this.IsCustomerSelected = false;

        Task.Run(this.LoadCustomers);
    }

    private bool CanStoreCustomer()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Name) ||
            string.IsNullOrWhiteSpace(this.Surname)
        );
    }

    private void StoreCustomer()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetCustomersCount() + 1;

            await this._modelOperation.AddCustomer(lastId, this.Name, this.Surname, this.Balance);

            this._informer.InformSuccess("Customer successfully created!");

            this.LoadCustomers();
        });
    }

    private void DeleteCustomer()
    {
        Task.Run(async () =>
        {
            try
            {
                await this._modelOperation.DeleteCustomer(this.SelectedDetailViewModel.CustomerId);

                this._informer.InformSuccess("Customer successfully deleted!");

                this.LoadCustomers();
            }
            catch (Exception e)
            {
                this._informer.InformError("Error while deleting Customer! Remember to remove all associated events!");
            }
        });
    }

    private async void LoadCustomers()
    {
        Dictionary<int, ICustomerModel> customers = await this._modelOperation.GetAllCustomers();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._customers.Clear();

            foreach (ICustomerModel c in customers.Values)
            {
                this._customers.Add(new CustomerDetailViewModel(c.CustomerId, c.Name, c.Surname, c.Balance));
            }
        });

        OnPropertyChanged(nameof(Customers));
    }
}
