using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery.Data.API
{
    internal interface IUser
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
    }
}
