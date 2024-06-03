﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class SwitchViewCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private string _switchToViewModel;

    public SwitchViewCommand(string viewModel)
    {
        this._switchToViewModel = viewModel;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        UserControl userControl = parameter as UserControl;

        Window parentWindow = Window.GetWindow(userControl);

        if (parentWindow != null)
        {
            if (parentWindow.DataContext is MainWindowViewModel mainViewModel)
            {
                switch (this._switchToViewModel)
                {
                    case "EmployeeMasterView":
                        mainViewModel.SelectedViewModel = new EmployeeMasterViewModel(); break;
                    case "EventMasterView":
                        mainViewModel.SelectedViewModel = new EventMasterViewModel(); break;
                    case "StateMasterView":
                        mainViewModel.SelectedViewModel = new StateMasterViewModel(); break;
                    case "ProductMasterView":
                        mainViewModel.SelectedViewModel = new ProductMasterViewModel(); break;
                    case "CatalogMasterView":
                        mainViewModel.SelectedViewModel = new CatalogMasterViewModel(); break;
                    case "CustomerMasterView":
                        mainViewModel.SelectedViewModel = new CustomerMasterViewModel(); break;
                }
            }
        }
    }
}
