using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class CatalogMasterViewModel : IViewModel, ICatalogMasterViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }
    public ICommand SwitchToEmployeeMasterPage { get; set; }
    public ICommand SwitchToCustomerMasterPage { get; set; }

    public ICommand CreateCatalog { get; set; }

    public ICommand RemoveCatalog { get; set; }

    private readonly ICatalogModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<ICatalogDetailViewModel> _catalogs;

    public ObservableCollection<ICatalogDetailViewModel> Catalogs
    {
        get => _catalogs;
        set
        {
            _catalogs = value;
            OnPropertyChanged(nameof(Catalogs));
        }
    }

    private decimal _price;

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    private bool _isCatalogSelected;

    public bool IsCatalogSelected
    {
        get => _isCatalogSelected;
        set
        {
            this.IsCatalogDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isCatalogSelected = value;
            OnPropertyChanged(nameof(IsCatalogSelected));
        }
    }

    private Visibility _isCatalogDetailVisible;

    public Visibility IsCatalogDetailVisible
    {
        get => _isCatalogDetailVisible;
        set
        {
            _isCatalogDetailVisible = value;
            OnPropertyChanged(nameof(IsCatalogDetailVisible));
        }
    }

    private ICatalogDetailViewModel _selectedDetailViewModel;

    public ICatalogDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsCatalogSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public CatalogMasterViewModel(ICatalogModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");
        this.SwitchToCustomerMasterPage = new SwitchViewCommand("CustomerMasterView");
        this.SwitchToEmployeeMasterPage = new SwitchViewCommand("EmployeeMasterView");

        this.CreateCatalog = new OnClickCommand(e => this.StoreCatalog(), c => this.CanStoreCatalog());
        this.RemoveCatalog = new OnClickCommand(e => this.DeleteCatalog());

        this.Catalogs = new ObservableCollection<ICatalogDetailViewModel>();

        this._modelOperation = model ?? ICatalogModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.IsCatalogSelected = false;

        Task.Run(this.LoadCatalogs);
    }

    private bool CanStoreCatalog()
    {
        return Price > 0;
    }

    private void StoreCatalog()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetCatalogsCount() + 1;

            await this._modelOperation.AddCatalog(lastId, this.Price);

            this._informer.InformSuccess("Catalog successfully created!");

            this.LoadCatalogs();
        });
    }

    private void DeleteCatalog()
    {
        Task.Run(async () =>
        {
            try
            {
                await this._modelOperation.DeleteCatalog(this.SelectedDetailViewModel.CatalogId);

                this._informer.InformSuccess("Catalog successfully deleted!");

                this.LoadCatalogs();
            }
            catch (Exception e)
            {
                this._informer.InformError("Error while deleting Catalog! Remember to remove all associated events!");
            }
        });
    }

    private async void LoadCatalogs()
    {
        Dictionary<int, ICatalogModel> catalogs = await this._modelOperation.GetAllCatalogs();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._catalogs.Clear();

            foreach (ICatalogModel c in catalogs.Values)
            {
                this._catalogs.Add(new CatalogDetailViewModel(c.CatalogId, c.Price));
            }
        });

        OnPropertyChanged(nameof(Catalogs));
    }
}
