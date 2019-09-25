using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biblioteca_rest_service.Dtos
{
    public class Catalogo
    {
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
    }
}