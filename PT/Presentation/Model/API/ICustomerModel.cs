using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface ICustomerModel : IUserModel
    {
        int CustomerId { get; set; }
        decimal Balance { get; set; }
    }
}
