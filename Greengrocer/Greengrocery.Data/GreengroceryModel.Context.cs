﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Greengrocery.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GreengroceryEntities : DbContext
    {
        public GreengroceryEntities()
            : base("name=GreengroceryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public void Detach(productsGrocery e)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<customersGrocery> customersGrocery { get; set; }
        public virtual DbSet<employeesGrocery> employeesGrocery { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<productsGrocery> productsGrocery { get; set; }
        public virtual DbSet<suppliersGrocery> suppliersGrocery { get; set; }
    }
}
