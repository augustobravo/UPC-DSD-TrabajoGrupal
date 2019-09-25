using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biblioteca_frontend.Models
{
    public class Lector
    {
        public int id_lector { get; set; }
        public string nu_dni { get; set; }
        public string tx_nombres { get; set; }
        public string tx_direccion { get; set; }
        public Nullable<System.DateTime> dt_fecha_nac { get; set; }
        public Nullable<int> nu_estado { get; set; }
        public string tx_email { get; set; }
        public string tx_contrasena { get; set; }
    }
}