﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eCommerce.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBmodel : DbContext
    {
        public DBmodel()
            : base("name=DBmodel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<cartstatu> cartstatus { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<customer_reg> customer_reg { get; set; }
        public virtual DbSet<feedbake> feedbakes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<memberrole> memberroles { get; set; }
        public virtual DbSet<poll> polls { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<shippingdetail> shippingdetails { get; set; }
    }
}