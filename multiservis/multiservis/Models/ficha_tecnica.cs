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
    
    public partial class ficha_tecnica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ficha_tecnica()
        {
            this.detalle_ficha_herramienta = new HashSet<detalle_ficha_herramienta>();
            this.detalle_ficha_material = new HashSet<detalle_ficha_material>();
        }
    
        public int id { get; set; }
        public Nullable<int> detalle_reserva { get; set; }
        public Nullable<int> usuario_almacen { get; set; }
        public Nullable<int> nro_ficha { get; set; }
        public string descripcion_problema { get; set; }
        public Nullable<int> hora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_ficha_herramienta> detalle_ficha_herramienta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_ficha_material> detalle_ficha_material { get; set; }
        public virtual detalle_reserva detalle_reserva1 { get; set; }
    }
}
