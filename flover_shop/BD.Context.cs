﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace flover_shop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BaseDana : DbContext
    {
        public BaseDana()
            : base("name=BaseDana")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<Floor_gender> Floor_gender { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Сlients> Сlients { get; set; }
    }
}
