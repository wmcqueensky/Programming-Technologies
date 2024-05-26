using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string Name { get; set; }
        double Price { get; set; }

        string Type { get; set; }

    }
}
