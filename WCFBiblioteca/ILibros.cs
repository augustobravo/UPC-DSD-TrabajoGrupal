using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFBiblioteca.Dominio;
using WCFBiblioteca.Errores;

namespace WCFBiblioteca
{
    [ServiceContract]
    public interface ILibros
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Libro CrearLibro(Libro libroACrear);
   
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Libro ObtenerLibro(string codigoLibro);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Libro ModificarLibro(Libro libroAModificar);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        void EliminarLibro(string codigoLibro);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<Libro> ListarLibros();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Libro ObtenerLibroPorTitulo(string titulo);


        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Libro ObtenerLibroPorAutor(string autor);

    }
}
