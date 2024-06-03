using Presentation.ViewModel;

namespace PresentationTests;

public interface IGenerator
{
    void GenerateEmployeeModels(IEmployeeMasterViewModel viewModel);

    void GenerateCustomerModels(ICustomerMasterViewModel viewModel);

    void GenerateCatalogModels(ICatalogMasterViewModel viewModel);

    void GenerateProductModels(IProductMasterViewModel viewModel);

    void GenerateStateModels(IStateMasterViewModel viewModel);

    void GenerateEventModels(IEventMasterViewModel viewModel);
}