using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class EmployeeMasterViewModel : IViewModel, IEmployeeMasterViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand SwitchToCatalogMasterPage { get; set; }

    public ICommand SwitchToCustomerMasterPage { get; set; }

    public ICommand CreateEmployee { get; set; }

    public ICommand RemoveEmployee { get; set; }

    private readonly IEmployeeModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<IEmployeeDetailViewModel> _employees;

    public ObservableCollection<IEmployeeDetailViewModel> Employees
    {
        get => _employees;
        set
        {
            _employees = value;
            OnPropertyChanged(nameof(Employees));
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

    private bool _isEmployeeSelected;

    public bool IsEmployeeSelected
    {
        get => _isEmployeeSelected;
        set
        {
            this.IsEmployeeDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isEmployeeSelected = value;
            OnPropertyChanged(nameof(IsEmployeeSelected));
        }
    }

    private Visibility _isEmployeeDetailVisible;

    public Visibility IsEmployeeDetailVisible
    {
        get => _isEmployeeDetailVisible;
        set
        {
            _isEmployeeDetailVisible = value;
            OnPropertyChanged(nameof(IsEmployeeDetailVisible));
        }
    }

    private IEmployeeDetailViewModel _selectedDetailViewModel;

    public IEmployeeDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsEmployeeSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public EmployeeMasterViewModel(IEmployeeModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");
        this.SwitchToCatalogMasterPage = new SwitchViewCommand("CatalogMasterView");
        this.SwitchToCustomerMasterPage = new SwitchViewCommand("CustomerMasterView");


        this.CreateEmployee = new OnClickCommand(e => this.StoreEmployee(), c => this.CanStoreEmployee());
        this.RemoveEmployee = new OnClickCommand(e => this.DeleteEmployee());

        this.Employees = new ObservableCollection<IEmployeeDetailViewModel>();

        this._modelOperation = model ?? IEmployeeModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.IsEmployeeSelected = false;

        Task.Run(this.LoadEmployees);
    }

    private bool CanStoreEmployee()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Name) ||
            string.IsNullOrWhiteSpace(this.Surname)
        );
    }

    private void StoreEmployee()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetEmployeesCount() + 1;

            await this._modelOperation.AddEmployee(lastId, this.Name, this.Surname);

            this._informer.InformSuccess("Employee successfully created!");

            this.LoadEmployees();
        });
    }

    private void DeleteEmployee()
    {
        Task.Run(async () =>
        {
            try
            {
                await this._modelOperation.DeleteEmployee(this.SelectedDetailViewModel.EmployeeId);

                this._informer.InformSuccess("Employee successfully deleted!");

                this.LoadEmployees();
            }
            catch (Exception e)
            {
                this._informer.InformError("Error while deleting Employee! Remember to remove all associated events!");
            }
        });
    }

    private async void LoadEmployees()
    {
        Dictionary<int, IEmployeeModel> Employees = await this._modelOperation.GetAllEmployees();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._employees.Clear();

            foreach (IEmployeeModel e in Employees.Values)
            {
                this._employees.Add(new EmployeeDetailViewModel(e.EmployeeId, e.Name, e.Surname));
            }
        });

        OnPropertyChanged(nameof(Employees));
    }
}
