using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class EventDetailViewModel : IViewModel, IEventDetailViewModel
{
    public ICommand UpdateEvent { get; set; }

    private readonly IEventModelOperation _modelOperation;

    private int _eventId;

    public int EventId
    {
        get => _eventId;
        set
        {
            _eventId = value;
            OnPropertyChanged(nameof(EventId));
        }
    }

    private int _stateId;

    public int StateId
    {
        get => _stateId;
        set
        {
            _stateId = value;
            OnPropertyChanged(nameof(StateId));
        }
    }

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

    private int _productId;

    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged(nameof(ProductId));
        }
    }

    private DateTime _eventDate;

    public DateTime EventDate
    {
        get => _eventDate;
        set
        {
            _eventDate = value;
            OnPropertyChanged(nameof(EventDate));
        }
    }

    private string _type;

    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    public EventDetailViewModel(IEventModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IEventModelOperation.CreateModelOperation();

    }
    public EventDetailViewModel(int id, int stateId, int employeeId, int customerId, int productId, IEventModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IEventModelOperation.CreateModelOperation();


        this.EventId = id;
        this.StateId = stateId;
        this.EmployeeId = employeeId;
        this.CustomerId = customerId;
        this.EmployeeId = productId;
        this.EventDate = DateTime.Now;
    }

    private void Update()
    {
        Task.Run(async () =>
        {
            await this._modelOperation.UpdateEvent(this.EventId, this.StateId, this.EmployeeId, this.CustomerId, this.ProductId);

            Informer.InformSuccess("Event successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.EventDate.ToString())
        );
    }
}
