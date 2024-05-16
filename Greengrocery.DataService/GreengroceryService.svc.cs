using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Greengrocery.DataService
{
    [ServiceContract]
    public class GreengroceryService
    {
        [OperationContract]
        public IEnumerable<products> GetProducts()
        {
            using (var context = new GreengroceryEntities())
            {
                var result = context.productsGrocery.ToList();
                result.ForEach(e => context.Detach(e));
                return result;
            }
        }
    }
}
