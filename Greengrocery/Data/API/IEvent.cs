using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    internal interface IEvent
    {
        int event_id { get; }
        int employee_id { get; }
        int product_id { get; }

        int supplier_id { get; }

        int customer_id { get; }

        int state_id { get; }

    }
}
