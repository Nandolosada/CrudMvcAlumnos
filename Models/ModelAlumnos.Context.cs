﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDMvcAspAlumnos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlumnosContext : DbContext
    {
        public AlumnosContext()
            : base("name=AlumnosContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alumno> alumno { get; set; }
        public virtual DbSet<ciudad> ciudad { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
