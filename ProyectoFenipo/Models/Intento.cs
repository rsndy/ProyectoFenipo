//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Intento
    {
        public int Id { get; set; }
        public int InscripcionAtletasId { get; set; }
        public string Movimiento { get; set; }
        public string NumeroIntento { get; set; }
        public decimal KilosMovimiento { get; set; }
        public string Estatus { get; set; }
    
        public virtual InscripcionAtletas InscripcionAtletas { get; set; }
    }
}