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
    
    public partial class Competencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competencia()
        {
            this.InscripcionEquipo = new HashSet<InscripcionEquipo>();
            this.InscripcionAtletas = new HashSet<InscripcionAtletas>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public System.DateTime Fecha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InscripcionEquipo> InscripcionEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InscripcionAtletas> InscripcionAtletas { get; set; }
    }
}
