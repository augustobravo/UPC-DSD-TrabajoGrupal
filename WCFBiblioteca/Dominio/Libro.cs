using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFBiblioteca.Dominio
{
    [DataContract]
    public class Libro
    {
        [DataMember]
        public string CodigoLibro { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public int Paginas { get; set; }

        [DataMember]
        public string Editorial { get; set; }

        [DataMember]
        public string Autor { get; set; }

        [DataMember]
        public DateTime FechaPublicacion { get; set; }

        [DataMember(IsRequired = false)]
        public int Estado { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

    }
}