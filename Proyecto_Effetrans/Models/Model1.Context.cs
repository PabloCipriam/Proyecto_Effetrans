﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Effetrans.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_EffetransEntities3 : DbContext
    {
        public BD_EffetransEntities3()
            : base("name=BD_EffetransEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bloqueo> Bloqueo { get; set; }
        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Carga> Carga { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Confirmacion_Envio> Confirmacion_Envio { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Tipo_Carga> Tipo_Carga { get; set; }
        public virtual DbSet<Tipo_Pago> Tipo_Pago { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public virtual DbSet<Tipo_Vehiculo> Tipo_Vehiculo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
    }
}
