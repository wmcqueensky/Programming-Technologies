﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface ICatalogDTO
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
