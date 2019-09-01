using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFBiblioteca.Dominio;
using WCFBiblioteca.Errores;
using WCFBiblioteca.Persistencia;

namespace WCFBiblioteca
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Libros" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Libros.svc o Libros.svc.cs en el Explorador de soluciones e inicie la depuración.
    // NOTA: Metodos de CrearLibro, EliminarLibro, ModificarLibro, EliminarLibro, ObtenerLibro
    // NOTA : Se utilizara ObtenerPorTitulo para la busqueda del Articulo
    // Agregar Service devolucion de Libros
 public class Libros : ILibros
    {
        private LibroDAO libroDAO = new LibroDAO();


        public Libro CrearLibro(Libro libroACrear)
        {
            if (libroDAO.ObtenerPorCodigo(libroACrear.CodigoLibro) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El código del libro ya existe"
                    }, new FaultReason("Error al intentar crear el libro"));
            }

            if (libroDAO.ObtenerPorTitulo(libroACrear.Titulo) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "El titulo del libro ya existe"
                    }, new FaultReason("Error al intentar crear el libro"));
            }

            return libroDAO.Crear(libroACrear);
        }

        public void EliminarLibro(string codigoLibro)
        {
            libroDAO.Eliminar(codigoLibro);
        }

        public List<Libro> ListarLibros()
        {
            return libroDAO.Listar();
        }

        public Libro ModificarLibro(Libro libroAModificar)
        {
            Libro libroEncontrado = libroDAO.ObtenerPorCodigo(libroAModificar.CodigoLibro);

            if (libroEncontrado.Estado == 0)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "103",
                        Descripcion = "El libro se encuentra anulado"
                    }, new FaultReason("Error al intentar modificar el libro"));
            }

            if (libroEncontrado != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El código del libro ya existe"
                    }, new FaultReason("Error al intentar crear el libro"));
            }

            return libroDAO.Modificar(libroAModificar);
        }

        public Libro ObtenerLibro(string codigoLibro)
        {
            return libroDAO.ObtenerPorCodigo(codigoLibro);
        }

        public Libro ObtenerLibroPorTitulo(string titulo)
        {
            return libroDAO.ObtenerPorTitulo(titulo);
        }

        public Libro ObtenerLibroPorAutor(string autor)
        {
            return libroDAO.ObtenerPorAutor(autor);
        }

        public void cambio() { }
                
    }
}
