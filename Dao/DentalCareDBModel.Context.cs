﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dao
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DentalCareDBEntities : DbContext
    {
        public DentalCareDBEntities()
            : base("name=DentalCareDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AtencionCabecera> AtencionCabecera { get; set; }
        public virtual DbSet<AtencionPosicion> AtencionPosicion { get; set; }
        public virtual DbSet<Consumible> Consumible { get; set; }
        public virtual DbSet<CtaCorriente> CtaCorriente { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<EstadoTurno> EstadoTurno { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<ObraSocial> ObraSocial { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoTratamiento> TipoTratamiento { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<UsuarioEspecialidad> UsuarioEspecialidad { get; set; }
    }
}
