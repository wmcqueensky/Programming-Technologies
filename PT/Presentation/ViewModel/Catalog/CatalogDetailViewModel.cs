using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class CatalogDetailViewModel : IViewModel, ICatalogDetailViewModel
{
    public ICommand UpdateCatalog { get; set; }

    private readonly ICatalogModelOperation _modelOperation;


    private int _catalogId;

    public int CatalogId
    {
        get => _catalogId;
        set
        {
            _catalogId = value;
            OnPropertyChanged(nameof(CatalogId));
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

    public CatalogDetailViewModel(ICatalogModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateCatalog = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? ICatalogModelOperation.CreateModelOperation();

    }

    public CatalogDetailViewModel(int id, decimal price, ICatalogModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.CatalogId = id;
        this.Price = price;

        this.UpdateCatalog = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? ICatalogModelOperation.CreateModelOperation();

    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateCatalog(this.CatalogId, this.Price);

            Informer.InformSuccess("Catalog successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return Price > 0;
    }
}
