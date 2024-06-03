﻿using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IStateMasterViewModel
{
    static IStateMasterViewModel CreateViewModel(IStateModelOperation operation, IErrorInformer informer)
    {
        return new StateMasterViewModel(operation, informer);
    }

    public ICommand CreateState { get; set; }

    public ICommand RemoveState { get; set; }

    public ObservableCollection<IStateDetailViewModel> States { get; set; }

    public int StateId { get; set; }

    public int CatalogId { get; set; }

    public int Quantity { get; set; }

    public bool IsStateSelected { get; set; }

    public Visibility IsStateDetailVisible { get; set; }

    public IStateDetailViewModel SelectedDetailViewModel { get; set; }
}
