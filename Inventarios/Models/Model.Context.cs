﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventarios.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Localizaciones> Localizaciones { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<Personals> Personals { get; set; }
        public DbSet<TercerasPersonas> TercerasPersonas { get; set; }
        public DbSet<TipoArticulos> TipoArticulos { get; set; }
        public DbSet<TipoCompania> TipoCompania { get; set; }
        public DbSet<TipoContrato> TipoContrato { get; set; }
        public DbSet<Relacion> RelacionSet { get; set; }
    }
}
