using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class StateMasterViewModel : IViewModel, IStateMasterViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand SwitchToCustomerMasterPage { get; set; }

    public ICommand SwitchToCatalogMasterPage { get; set; }

    public ICommand SwitchToEmployeeMasterPage { get; set; }

    public ICommand CreateState { get; set; }

    public ICommand RemoveState { get; set; }

    private readonly IStateModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<IStateDetailViewModel> _states;

    public ObservableCollection<IStateDetailViewModel> States
    {
        get => _states;
        set
        {
            _states = value;
            OnPropertyChanged(nameof(States));
        }
    }

    private int _id;

    public int StateId
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(StateId));
        }
    }

    private int _productId;

    public int CatalogId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged(nameof(CatalogId));
        }
    }

    private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    private bool _isStateSelected;

    public bool IsStateSelected
    {
        get => _isStateSelected;
        set
        {
            this.IsStateDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isStateSelected = value;
            OnPropertyChanged(nameof(IsStateSelected));
        }
    }

    private Visibility _isStateDetailVisible;

    public Visibility IsStateDetailVisible
    {
        get => _isStateDetailVisible;
        set
        {
            _isStateDetailVisible = value;
            OnPropertyChanged(nameof(IsStateDetailVisible));
        }
    }

    private IStateDetailViewModel _selectedDetailViewModel;

    public IStateDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsStateSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public StateMasterViewModel(IStateModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");
        this.SwitchToEmployeeMasterPage = new SwitchViewCommand("EmployeeMasterView");
        this.SwitchToCatalogMasterPage = new SwitchViewCommand("CatalogMasterView");
        this.SwitchToCustomerMasterPage = new SwitchViewCommand("CustomerMasterView");

        this.CreateState = new OnClickCommand(e => this.StoreState(), c => this.CanStoreState());
        this.RemoveState = new OnClickCommand(e => this.DeleteState());

        this.States = new ObservableCollection<IStateDetailViewModel>();

        this._modelOperation = IStateModelOperation.CreateModelOperation();


        this.IsStateSelected = false;

        Task.Run(this.LoadStates);
    }

    private bool CanStoreState()
    {
        return !(
            string.IsNullOrWhiteSpace(this.CatalogId.ToString())
        );
    }

    private void StoreState()
    {
        Task.Run(async () =>
        {
            try
            {
                int lastId = await this._modelOperation.GetStatesCount() + 1;

                await this._modelOperation.AddState(lastId, this.CatalogId, this.Quantity);

                this.LoadStates();

                this._informer.InformSuccess("State successfully created!");
            }
            catch (Exception e)
            {
                this._informer.InformError(e.Message);
            }
        });
    }

    private void DeleteState()
    {
        Task.Run(async () =>
        {
            try
            {
                await this._modelOperation.DeleteState(this.SelectedDetailViewModel.StateId);

                this.LoadStates();

                this._informer.InformSuccess("State successfully deleted!");
            }
            catch (Exception e)
            {
                this._informer.InformError("Error while deleting state! Remember to remove all associated events!");
            }
        });
    }

    private async void LoadStates()
    {
        Dictionary<int, IStateModel> States = await this._modelOperation.GetAllStates();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._states.Clear();

            foreach (IStateModel s in States.Values)
            {
                this._states.Add(new StateDetailViewModel(s.StateId, s.CatalogId, s.Quantity));
            }
        });

        OnPropertyChanged(nameof(States));
    }
}
