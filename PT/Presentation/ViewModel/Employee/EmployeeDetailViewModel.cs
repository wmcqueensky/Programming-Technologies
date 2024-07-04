using Presentation.Model.API;
using System.Windows.Input;
namespace Presentation.ViewModel;

internal class EmployeeDetailViewModel : IViewModel, IEmployeeDetailViewModel
{
    public ICommand UpdateEmployee { get; set; }

    private readonly IEmployeeModelOperation _modelOperation;


    private int _employeeId;
    public int EmployeeId
    {
        get => _employeeId;
        set
        {
            _employeeId = value;
            OnPropertyChanged(nameof(EmployeeId));
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

    public EmployeeDetailViewModel(IEmployeeModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateEmployee = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IEmployeeModelOperation.CreateModelOperation();

    }

    public EmployeeDetailViewModel(int id, string firstName, string lastName, IEmployeeModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.EmployeeId = id;
        this.Name = firstName;
        this.Surname = lastName;

        this.UpdateEmployee = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IEmployeeModelOperation.CreateModelOperation();

    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateEmployee(this.EmployeeId, this.Name, this.Surname);

            Informer.InformSuccess("Employee successfully updated!");
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
