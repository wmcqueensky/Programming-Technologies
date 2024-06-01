using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class StateDetailViewModel : IViewModel, IStateDetailViewModel
{
    public ICommand UpdateState { get; set; }

    private readonly IStateModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

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

    public StateDetailViewModel(IStateModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IStateModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    public StateDetailViewModel(int id, int productId, int quantity, IStateModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.StateId = id;
        this.CatalogId = productId;
        this.Quantity = quantity;

        this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IStateModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateState(this.StateId, this.CatalogId, this.Quantity);

            this._informer.InformSuccess("State successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Quantity.ToString())
        );
    }
}
