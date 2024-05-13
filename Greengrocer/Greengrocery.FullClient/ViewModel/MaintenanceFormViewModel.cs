using Greengrocery.UI.GreengroceryService;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.UI.ViewModel
{
    public class MaintenanceFormViewModel : INotifyPropertyChanged
    {
        private GreengroceryServiceClient serviceClient = new GreengroceryServiceClient();
        public MaintenanceFormViewModel()
        {
            this.RefreshProducts();
        }

        private void RefreshProducts()
        {
            this.serviceClient.GetProductsCompleted += (s, e) =>
            {
                this.products = e.Result;
            }
            this.serviceClient.GetProductsAsync();
        }

        private IEnumerable<productsGrocery> products;
        public IEnumerable<productsGrocery> Products;
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
                this.OnPropertyChanged("Products")
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private event PropertyChangedEventHandler PropertyChanged;
    }
}
