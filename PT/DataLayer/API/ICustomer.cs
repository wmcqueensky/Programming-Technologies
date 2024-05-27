using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface ICustomer : IUser
    {
        int CustomerId { get; set; }
        decimal Balance { get; set; }
    }
}
