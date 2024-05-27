using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface ICustomerDTO : IUserDTO
    {
        int CustomerId { get; set; }
        decimal Balance { get; set; }
    }
}
