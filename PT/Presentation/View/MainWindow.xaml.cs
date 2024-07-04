﻿using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            IViewModel.Informer = new PopupErrorInformer();
            InitializeComponent();
            
            
        }
    }
}
