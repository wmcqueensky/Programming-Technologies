using Presentation.Model.API;
using Presentation.ViewModel;
using PresentationTests.FakeItems;
using PresentationTests.Mocks;

namespace PresentationTests;

internal class FixedGenerator : IGenerator
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    public void GenerateEmployeeModels(IEmployeeMasterViewModel viewModel)
    {
        IEmployeeModelOperation operation = new MockEmployeeCRUD();

        viewModel.Employees.Add(IEmployeeDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer));
        viewModel.Employees.Add(IEmployeeDetailViewModel.CreateViewModel(2, "Jane", "Doe", operation, _informer));
    }

    public void GenerateCustomerModels(ICustomerMasterViewModel viewModel)
    {
        ICustomerModelOperation operation = new MockCustomerCRUD();

        viewModel.Customers.Add(ICustomerDetailViewModel.CreateViewModel(1, "Johny", "Doey", 100, operation, _informer));
        viewModel.Customers.Add(ICustomerDetailViewModel.CreateViewModel(2, "Janey", "Doey", 200, operation, _informer));
    }

    public void GenerateCatalogModels(ICatalogMasterViewModel viewModel)
    {
        ICatalogModelOperation operation = new MockCatalogCRUD();

        viewModel.Catalogs.Add(ICatalogDetailViewModel.CreateViewModel(1, 12, operation, _informer));
        viewModel.Catalogs.Add(ICatalogDetailViewModel.CreateViewModel(2, 14, operation, _informer));
    }

    public void GenerateProductModels(IProductMasterViewModel viewModel)
    {
        IProductModelOperation operation = new MockProductCRUD();

        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(1, "Onion", operation, _informer));
        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(2, "Tomato", operation, _informer));

    }

    public void GenerateStateModels(IStateMasterViewModel viewModel)
    {
        IStateModelOperation operation = new MockStateCRUD();

        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(1, 1, 1, operation, _informer));
        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(2, 2, 2, operation, _informer));
    }

    public void GenerateEventModels(IEventMasterViewModel viewModel)
    {

        IEventModelOperation operation = new MockEventCRUD();
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(1, 1, 1, 1, 1, operation, _informer));
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(2, 2, 2, 2, 2, operation, _informer));


    }
}