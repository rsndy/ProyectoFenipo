﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFenipo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProyectoFenipoContainer : DbContext
    {
        public ProyectoFenipoContainer()
            : base("name=ProyectoFenipoContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Atleta> Atletas { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Competencia> Competencias { get; set; }
        public virtual DbSet<InscripcionEquipo> InscripcionEquipos { get; set; }
        public virtual DbSet<InscripcionAtletas> InscripcionAtletasSet { get; set; }
        public virtual DbSet<CategoriaPeso> CategoriaPesos { get; set; }
        public virtual DbSet<CategoriaEdad> CategoriaEdades { get; set; }
        public virtual DbSet<Intento> Intentos { get; set; }
    }
}
