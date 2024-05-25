using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    internal interface IState
    {
        
        int state_id { get; set; }

        int catalog_id { get; set; }


    }
}
