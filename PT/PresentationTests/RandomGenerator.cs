﻿using Presentation.Model.API;
using Presentation.ViewModel;
using PresentationTests.FakeItems;
using PresentationTests.Mocks;

namespace PresentationTests;

internal class RandomGenerator : IGenerator
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    public void GenerateEmployeeModels(IEmployeeMasterViewModel viewModel)
    {
        IEmployeeModelOperation operation = new MockEmployeeCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Employees.Add(IEmployeeDetailViewModel.CreateViewModel(i, RandomString(5), RandomString(5), operation, _informer));
        }
    }

    public void GenerateCustomerModels(ICustomerMasterViewModel viewModel)
    {
        ICustomerModelOperation operation = new MockCustomerCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Customers.Add(ICustomerDetailViewModel.CreateViewModel(i, RandomString(5), RandomString(5), RandomNumber<int>(3), operation, _informer));
        }
    }

    public void GenerateCatalogModels(ICatalogMasterViewModel viewModel)
    {
        ICatalogModelOperation operation = new MockCatalogCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Catalogs.Add(ICatalogDetailViewModel.CreateViewModel(i, RandomNumber<int>(2), operation, _informer));
        }
    }

    public void GenerateProductModels(IProductMasterViewModel viewModel)
    {
        IProductModelOperation operation = new MockProductCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(i, RandomString(5), operation, _informer));
        }
    }

    public void GenerateStateModels(IStateMasterViewModel viewModel)
    {
        IStateModelOperation operation = new MockStateCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.States.Add(IStateDetailViewModel.CreateViewModel(i, RandomNumber<int>(1), RandomNumber<int>(1), operation, _informer));
        }
    }

    public void GenerateEventModels(IEventMasterViewModel viewModel)
    {
        IEventModelOperation operation = new MockEventCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(i, RandomNumber<int>(1), RandomNumber<int>(1), RandomNumber<int>(1), RandomNumber<int>(1), operation, _informer));
        }
    }

    private string RandomString(int length)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var randomText = new char[length];

        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            randomText[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomText);
    }

    private T RandomNumber<T>(int length) where T : struct, IComparable
    {
        if (length <= 0)
            throw new ArgumentException("Number of digits must be positive.");

        Random random = new Random();

        T maxNumber = (T)Convert.ChangeType(Math.Pow(10, length), typeof(T));

        T randomNumber = (T)Convert.ChangeType(
            random.Next(
                Convert.ToInt32(Math.Pow(10, length - 1)),
                Convert.ToInt32(maxNumber)
            ), typeof(T)
        );

        return randomNumber;
    }
}
