//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace biblioteca_rest_service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_catalogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_catalogo()
        {
            this.t_prestamo = new HashSet<t_prestamo>();
        }
    
        public int id_articulo { get; set; }
        public string tx_cod_bibl { get; set; }
        public string tx_descripcion { get; set; }
        public Nullable<int> nu_estado { get; set; }
        public string tx_ubicacion1 { get; set; }
        public string tx_ubicacion2 { get; set; }
        public string tx_cod_barras { get; set; }
        public string tx_imagen_url { get; set; }
        public string tx_autor { get; set; }
        public string tx_descripcion2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_prestamo> t_prestamo { get; set; }
    }
}