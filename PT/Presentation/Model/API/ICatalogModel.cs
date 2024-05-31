using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface ICatalogModel
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
