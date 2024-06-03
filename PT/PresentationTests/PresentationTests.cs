using Presentation.Model.API;
using Presentation.ViewModel;
using PresentationTests.FakeItems;
using PresentationTests.Mocks;

namespace PresentationTests;

[TestClass]
public class PresentationTests
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    [TestMethod]
    public void EmployeeMasterViewModelTests()
    {
        IEmployeeModelOperation operation = new  MockEmployeeCRUD();

        IEmployeeMasterViewModel viewModel = IEmployeeMasterViewModel.CreateViewModel(operation, _informer);
        viewModel.Name = "John";
        viewModel.Surname = "Doe";

        Assert.IsNotNull(viewModel.CreateEmployee);
        Assert.IsNotNull(viewModel.RemoveEmployee);

        Assert.IsTrue(viewModel.CreateEmployee.CanExecute(null));

        Assert.IsTrue(viewModel.RemoveEmployee.CanExecute(null));
    }

    [TestMethod]
    public void EmployeeDetailViewModelTests()
    {
        IEmployeeModelOperation operation = new MockEmployeeCRUD();

        IEmployeeDetailViewModel detail = IEmployeeDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer);

        Assert.AreEqual(1, detail.EmployeeId);
        Assert.AreEqual("John", detail.Name);
        Assert.AreEqual("Doe", detail.Surname);

        Assert.IsTrue(detail.UpdateEmployee.CanExecute(null));
    }

    [TestMethod]
    public void CustomerMasterViewModelTests()
    {
        ICustomerModelOperation operation = new MockCustomerCRUD();

        ICustomerMasterViewModel viewModel = ICustomerMasterViewModel.CreateViewModel(operation, _informer);
        viewModel.Name = "John";
        viewModel.Surname = "Doe";
        viewModel.Balance = 100;

        Assert.IsNotNull(viewModel.CreateCustomer);
        Assert.IsNotNull(viewModel.RemoveCustomer);

        Assert.IsTrue(viewModel.CreateCustomer.CanExecute(null));

        Assert.IsTrue(viewModel.RemoveCustomer.CanExecute(null));
    }

    [TestMethod]
    public void CustomerDetailViewModelTests()
    {
        ICustomerModelOperation operation = new MockCustomerCRUD();

        ICustomerDetailViewModel detail = ICustomerDetailViewModel.CreateViewModel(1, "John", "Doe", 100, operation, _informer);

        Assert.AreEqual(1, detail.CustomerId);
        Assert.AreEqual("John", detail.Name);
        Assert.AreEqual("Doe", detail.Surname);
        Assert.AreEqual(100, detail.Balance);

        Assert.IsTrue(detail.UpdateCustomer.CanExecute(null));
    }

    [TestMethod]
    public void CatalogMasterViewModelTests()
    {
        ICatalogModelOperation operation = new MockCatalogCRUD();

        ICatalogMasterViewModel viewModel = ICatalogMasterViewModel.CreateViewModel(operation, _informer);

        Assert.IsNotNull(viewModel.CreateCatalog);
        Assert.IsNotNull(viewModel.RemoveCatalog);
    }


    [TestMethod]
    public void CatalogDetailViewModelTests()
    {
        ICatalogModelOperation operation = new MockCatalogCRUD();

        ICatalogDetailViewModel detail = ICatalogDetailViewModel.CreateViewModel(1, 12, operation, _informer);

        Assert.AreEqual(1, detail.CatalogId);
        Assert.AreEqual(12, detail.Price);

        Assert.IsTrue(detail.UpdateCatalog.CanExecute(null));
    }


    [TestMethod]
    public void ProductMasterViewModelTests()
    {

        IProductModelOperation operation = new MockProductCRUD();

        IProductMasterViewModel master = IProductMasterViewModel.CreateViewModel(operation, _informer);

        master.Name = "Onion";
       

        Assert.IsNotNull(master.CreateProduct);
        Assert.IsNotNull(master.RemoveProduct);

        Assert.IsTrue(master.CreateProduct.CanExecute(null));

        Assert.IsTrue(master.CreateProduct.CanExecute(null));

        Assert.IsTrue(master.RemoveProduct.CanExecute(null));
    }

    [TestMethod]
    public void ProductDetailViewModelTests()
    {

        IProductModelOperation operation = new MockProductCRUD();

        IProductDetailViewModel detail = IProductDetailViewModel.CreateViewModel(1, "Onion", operation, _informer);

        Assert.AreEqual(1, detail.ProductId);
        Assert.AreEqual("Onion", detail.Name);

        Assert.IsTrue(detail.UpdateProduct.CanExecute(null));
    }

    [TestMethod]
    public void StateMasterViewModelTests()
    {

        IStateModelOperation operation = new MockStateCRUD();

        IStateMasterViewModel master = IStateMasterViewModel.CreateViewModel(operation, _informer);

        master.StateId = 1;
        master.CatalogId = 1;
        master.Quantity = 1;

        Assert.IsNotNull(master.CreateState);
        Assert.IsNotNull(master.RemoveState);

        Assert.IsTrue(master.CreateState.CanExecute(null));

    }

    [TestMethod]
    public void StateDetailViewModelTests()
    {
        IStateModelOperation operation = new MockStateCRUD();

        IStateDetailViewModel detail = IStateDetailViewModel.CreateViewModel(1, 1, 1, operation, _informer);

        Assert.AreEqual(1, detail.StateId);
        Assert.AreEqual(1, detail.CatalogId);
        Assert.AreEqual(1, detail.Quantity);

        Assert.IsTrue(detail.UpdateState.CanExecute(null));
    }

    [TestMethod]
    public void EventMasterViewModelTests()
    {
        IEventModelOperation operation = new MockEventCRUD();

        IEventMasterViewModel master = IEventMasterViewModel.CreateViewModel(operation, _informer);

        master.StateId = 1;
        master.EmployeeId = 1;
        master.CustomerId = 1;
        master.ProductId = 1;
    }

    [TestMethod]
    public void EventDetailViewModelTests()
    {

        IEventModelOperation operation = new MockEventCRUD();

        IEventDetailViewModel detail = IEventDetailViewModel.CreateViewModel(1, 1, 1, 1, 1, operation, _informer);

        Assert.AreEqual(1, detail.EventId);
        Assert.AreEqual(1, detail.StateId);
        Assert.AreEqual(1, detail.EmployeeId);
        Assert.AreEqual(1, detail.CustomerId);

        Assert.IsTrue(detail.UpdateEvent.CanExecute(null));
    }

    [TestMethod]
    public void DataFixedGenerationMethodTests()
    {
        IGenerator fixedGenerator = new FixedGenerator();

        IEmployeeModelOperation employeeOperation = new MockEmployeeCRUD();
        IEmployeeMasterViewModel employeeViewModel = IEmployeeMasterViewModel.CreateViewModel(employeeOperation, _informer);

        ICustomerModelOperation customerOperation = new MockCustomerCRUD();
        ICustomerMasterViewModel customerViewModel = ICustomerMasterViewModel.CreateViewModel(customerOperation, _informer);

        ICatalogModelOperation catalogOperation = new MockCatalogCRUD();
        ICatalogMasterViewModel catalogViewModel = ICatalogMasterViewModel.CreateViewModel(catalogOperation, _informer);

        IProductModelOperation productOperation = new MockProductCRUD();
        IProductMasterViewModel productViewModel = IProductMasterViewModel.CreateViewModel(productOperation, _informer);

        IStateModelOperation stateOperation = new MockStateCRUD();
        IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation, _informer);

        IEventModelOperation eventOperation = new MockEventCRUD();
        IEventMasterViewModel eventViewModel = IEventMasterViewModel.CreateViewModel(eventOperation, _informer);

        fixedGenerator.GenerateEmployeeModels(employeeViewModel);
        fixedGenerator.GenerateCustomerModels(customerViewModel);
        fixedGenerator.GenerateCatalogModels(catalogViewModel);
        fixedGenerator.GenerateProductModels(productViewModel);
        fixedGenerator.GenerateStateModels(stateViewModel);
        fixedGenerator.GenerateEventModels(eventViewModel);

        Assert.AreEqual(2, employeeViewModel.Employees.Count);
        Assert.AreEqual(2, customerViewModel.Customers.Count);
        Assert.AreEqual(2, catalogViewModel.Catalogs.Count);
        Assert.AreEqual(2, productViewModel.Products.Count);
        Assert.AreEqual(2, stateViewModel.States.Count);
        Assert.AreEqual(2, eventViewModel.Events.Count);
    }


    [TestMethod]
    public void DataRandomGenerationMethodTests()
    {
        IGenerator randomGenerator = new RandomGenerator();

        IEmployeeModelOperation employeeOperation = new MockEmployeeCRUD();
        IEmployeeMasterViewModel employeeViewModel = IEmployeeMasterViewModel.CreateViewModel(employeeOperation, _informer);

        ICustomerModelOperation customerOperation = new MockCustomerCRUD();
        ICustomerMasterViewModel customerViewModel = ICustomerMasterViewModel.CreateViewModel(customerOperation, _informer);

        ICatalogModelOperation catalogOperation = new MockCatalogCRUD();
        ICatalogMasterViewModel catalogViewModel = ICatalogMasterViewModel.CreateViewModel(catalogOperation, _informer);

        IProductModelOperation productOperation = new MockProductCRUD();
        IProductMasterViewModel productViewModel = IProductMasterViewModel.CreateViewModel(productOperation, _informer);

        IStateModelOperation stateOperation = new MockStateCRUD();
        IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation, _informer);

        IEventModelOperation eventOperation = new MockEventCRUD();
        IEventMasterViewModel eventViewModel = IEventMasterViewModel.CreateViewModel(eventOperation, _informer);

        randomGenerator.GenerateEmployeeModels(employeeViewModel);
        randomGenerator.GenerateCustomerModels(customerViewModel);
        randomGenerator.GenerateCatalogModels(catalogViewModel);
        randomGenerator.GenerateProductModels(productViewModel);
        randomGenerator.GenerateStateModels(stateViewModel);
        randomGenerator.GenerateEventModels(eventViewModel);

        Assert.AreEqual(10, employeeViewModel.Employees.Count);
        Assert.AreEqual(10, customerViewModel.Customers.Count);
        Assert.AreEqual(10, catalogViewModel.Catalogs.Count);
        Assert.AreEqual(10, productViewModel.Products.Count);
        Assert.AreEqual(10, stateViewModel.States.Count);
        Assert.AreEqual(10, eventViewModel.Events.Count);
    }



}