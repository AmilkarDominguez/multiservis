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
    
    public partial class detalle_reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public detalle_reserva()
        {
            this.control = new HashSet<control>();
            this.ficha_tecnica = new HashSet<ficha_tecnica>();
        }
    
        public int id { get; set; }
        public Nullable<int> reserva { get; set; }
        public Nullable<int> detalle_servicio { get; set; }
        public Nullable<int> tecnico { get; set; }
        public Nullable<int> usuario { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string progreso { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<control> control { get; set; }
        public virtual reserva reserva1 { get; set; }
        public virtual detalle_servicio detalle_servicio1 { get; set; }
        public virtual tecnico tecnico1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ficha_tecnica> ficha_tecnica { get; set; }
    }
}
