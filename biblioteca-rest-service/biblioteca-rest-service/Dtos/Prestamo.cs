using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biblioteca_rest_service.Dtos
{
    public class Prestamo
    {
        public int id_prestamo { get; set; }
        public System.DateTime dt_fecha_prestamo { get; set; }
        public string nu_dni { get; set; }
        public string tx_cod_bibl { get; set; }
        public System.DateTime dt_fecha_vencimiento { get; set; }
        public Nullable<int> nu_estado { get; set; }
        public Nullable<System.DateTime> dt_fecha_devolucion { get; set; }

        public virtual Catalogo t_catalogo { get; set; }
        public virtual Lector t_lector { get; set; }
    }
}