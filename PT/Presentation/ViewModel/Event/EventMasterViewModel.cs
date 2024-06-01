using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class EventMasterViewModel : IViewModel, IEventMasterViewModel
{
    public ICommand SwitchToEmployeeMasterPage { get; set; }

    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToCatalogMasterPage { get; set; }

    public ICommand SwitchToCustomerMasterPage { get; set; }

    public ICommand PlacedEvent { get; set; }

    public ICommand PayedEvent { get; set; }

    public ICommand RemoveEvent { get; set; }

    private readonly IEventModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<IEventDetailViewModel> _events;

    public ObservableCollection<IEventDetailViewModel> Events
    {
        get => _events;
        set
        {
            _events = value;
            OnPropertyChanged(nameof(Events));
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

    private bool _isEventSelected;

    public bool IsEventSelected
    {
        get => _isEventSelected;
        set
        {
            this.IsEventDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isEventSelected = value;
            OnPropertyChanged(nameof(IsEventSelected));
        }
    }

    private Visibility _isEventDetailVisible;

    public Visibility IsEventDetailVisible
    {
        get => _isEventDetailVisible;
        set
        {
            _isEventDetailVisible = value;
            OnPropertyChanged(nameof(IsEventDetailVisible));
        }
    }

    private IEventDetailViewModel _selectedDetailViewModel;

    public IEventDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsEventSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public EventMasterViewModel(IEventModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToEmployeeMasterPage = new SwitchViewCommand("UserMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToCatalogMasterPage = new SwitchViewCommand("CatalogMasterView");
        this.SwitchToCustomerMasterPage = new SwitchViewCommand("CustomerMasterView");

        this.PlacedEvent = new OnClickCommand(e => this.StorePlaceEvent(), c => this.CanPlaceEvent());
        this.PayedEvent = new OnClickCommand(e => this.StorePayEvent(), c => this.CanPayEvent());
        this.RemoveEvent = new OnClickCommand(e => this.DeleteEvent());

        this.Events = new ObservableCollection<IEventDetailViewModel>();

        this._modelOperation = IEventModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.IsEventSelected = false;

        Task.Run(this.LoadEvents);
    }

    private bool CanPlaceEvent()
    {
        return !(
            string.IsNullOrWhiteSpace(this.StateId.ToString()) ||
            string.IsNullOrWhiteSpace(this.EmployeeId.ToString())
        );
    }

    private bool CanPayEvent()
    {
        return !(
            string.IsNullOrWhiteSpace(this.StateId.ToString()) ||
            string.IsNullOrWhiteSpace(this.EmployeeId.ToString())
        );
    }

    private void StorePlaceEvent()
    {
        Task.Run(async () =>
        {
            try
            {
                int lastId = await this._modelOperation.GetEventsCount() + 1;

                await this._modelOperation.AddEvent(lastId, this.StateId, this.EmployeeId, this.CustomerId, this.ProductId);

                this.LoadEvents();

                this._informer.InformSuccess("Event successfully created!");
            }
            catch (Exception e)
            {
                this._informer.InformError(e.Message);
            }
        });
    }

    private void StorePayEvent()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetEventsCount() + 1;

            await this._modelOperation.AddEvent(lastId, this.StateId, this.EmployeeId, this.CustomerId, this.ProductId);

            this.LoadEvents();

            this._informer.InformSuccess("Event successfully created!");
        });
    }

    private void DeleteEvent()
    {
        Task.Run(async () =>
        {
            await this._modelOperation.DeleteEvent(this.SelectedDetailViewModel.EventId);

            this.LoadEvents();

            this._informer.InformSuccess("Event successfully deleted!");
        });
    }

    private async void LoadEvents()
    {
        Dictionary<int, IEventModel> Events = (await this._modelOperation.GetAllEvents());

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._events.Clear();

            foreach (IEventModel e in Events.Values)
            {
                this._events.Add(new EventDetailViewModel(e.EventId, e.StateId, e.EmployeeId, e.CustomerId, e.ProductId));
            }
        });

        OnPropertyChanged(nameof(Events));
    }
}
