﻿using Greengrocery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Greengrocery.Data;
using System.Data.Entity;

namespace Greengrocery.DataService
{
    [ServiceContract]
    public class GreengroceryService
    {
        [OperationContract]
        public IEnumerable<productsGrocery> GetProducts()
        {
            using (var context = new GreengroceryEntities())
            {
                var result = context.productsGrocery.ToList();
                result.ForEach(e => context.Detach(e));
                return result;
            }
        }


        [OperationContract]
        public IEnumerable<orders> GetOrders(int productIdFilter)
        {
            using (var context = new GreengroceryEntities())
            {
                var result = context.orders.Include("Products").Where(c => c.product_id == productIdFilter).ToList();
                result.ForEach(e => context.Detach(e));
                return result;
            }
        }

        [OperationContract]

        public void SaveCustomer(customersGrocery customer)
        {
            using (var context = new GreengroceryEntities())
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
