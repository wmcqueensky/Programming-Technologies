using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class ProductDetailViewModel : IViewModel, IProductDetailViewModel
{
    public ICommand UpdateProduct { get; set; }

    private readonly IProductModelOperation _modelOperation;


    private int _id;

    public int ProductId
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(ProductId));
        }
    }

    private string _productName;

    public string Name
    {
        get => _productName;
        set
        {
            _productName = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public ProductDetailViewModel(IProductModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IProductModelOperation.CreateModelOperation();
    }

    public ProductDetailViewModel(int id, string name, IProductModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.ProductId = id;
        this.Name = name;

        this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IProductModelOperation.CreateModelOperation();

    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateProduct(this.ProductId, this.Name);

            Informer.InformSuccess("Product successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Name)
        );
    }
}
