//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace multiservis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servicio()
        {
            this.detalle_servicio = new HashSet<detalle_servicio>();
        }
    
        public int id { get; set; }
        public int area { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    
        public virtual area area1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_servicio> detalle_servicio { get; set; }
    }
}
