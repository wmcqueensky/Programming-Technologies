using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface ICatalog
    {
        int CatalogId
        {
            get;
            set;
        }
        decimal Price
        {
            get;
            set;
        }

    }
}
