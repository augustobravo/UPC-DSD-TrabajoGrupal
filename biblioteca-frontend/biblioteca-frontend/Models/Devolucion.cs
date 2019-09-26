using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RestDevolucion.Dominio
{
    [DataContract]
    public class Devolucion
    {
        [DataMember]
        public int IdDevolucion { get; set; }
        [DataMember]
        public int IdArticulo { get; set; }
        [DataMember]
        public int IdLector { get; set; }
        [DataMember]
        public String NombreTitulo { get; set; }
        [DataMember]
        public String NombreLector { get; set; }
        [DataMember]
        public DateTime Fechainicio { get; set; }
        [DataMember]
        public DateTime Fechafin { get; set; }
        [DataMember]
        public int Tiempoatraso { get; set; }
        [DataMember]
        public int Mora { get; set; }
        [DataMember]
        public int Monto { get; set; }
    }
}
