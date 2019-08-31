using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// pruebas 4
namespace WCFBibliotecaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CrearLibroOK()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            LibrosWS.Libro libroCreado = proxy.CrearLibro(new LibrosWS.Libro()
              //Cambio de prueba
            {
                CodigoLibro = "L0006",
                Titulo = "Titulo6",
                Autor = "Autor4",
                Editorial = "Editorial4",
                Paginas = 100,
                FechaPublicacion = new DateTime(2009,10,20),
                FechaRegistro = DateTime.Now ,
                Estado = 1               
            });

            Assert.AreEqual("L0006", libroCreado.CodigoLibro);
            Assert.AreEqual("Titulo6", libroCreado.Titulo);
            Assert.AreEqual("Autor4", libroCreado.Autor);
            Assert.AreEqual("Editorial4", libroCreado.Editorial);
            Assert.AreEqual(100, libroCreado.Paginas);
            Assert.AreEqual(new DateTime(2009, 10, 20), libroCreado.FechaPublicacion);
            Assert.AreEqual(1, libroCreado.Estado);

        }

        [TestMethod]
        public void Test1ModificarLibroOK()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            LibrosWS.Libro libroCreado = proxy.ModificarLibro(new LibrosWS.Libro()
            {
                CodigoLibro = "L0004",
                Titulo = "Titulo4.1",
                Autor = "Autor4.1",
                Editorial = "Editorial4.1",
                Paginas = 100,
                FechaPublicacion = new DateTime(2009, 10, 20)
            });

            Assert.AreEqual("L0004", libroCreado.CodigoLibro);
            Assert.AreEqual("Titulo4.1", libroCreado.Titulo);
            Assert.AreEqual("Autor4.1", libroCreado.Autor);
            Assert.AreEqual("Editorial4.1", libroCreado.Editorial);
            Assert.AreEqual(100, libroCreado.Paginas);
            Assert.AreEqual(new DateTime(2009, 10, 20), libroCreado.FechaPublicacion);
            Assert.AreEqual(1, libroCreado.Estado);

        }

        [TestMethod]
        public void Test1ObtenerLibroOK()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            LibrosWS.Libro libroCreado = proxy.ObtenerLibro("L0004");

            Assert.AreEqual("L0004", libroCreado.CodigoLibro);            
        }

        [TestMethod]
        public void Test1EliminarLibroOK()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            proxy.EliminarLibro("L0003");
            LibrosWS.Libro libroCreado = proxy.ObtenerLibro("L0003");

            Assert.AreEqual("L0003", libroCreado.CodigoLibro);
            Assert.AreEqual(0, libroCreado.Estado);

        }

        [TestMethod]
        public void Test2CrearLibroRepetido()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            try
            {
                LibrosWS.Libro libroCreado = proxy.CrearLibro(new LibrosWS.Libro()
                {
                    CodigoLibro = "L0004",
                    Titulo = "Titulo4",
                    Autor = "Autor4",
                    Editorial = "Editorial4",
                    Paginas = 100,
                    FechaPublicacion = new DateTime(2009, 10, 20),
                    FechaRegistro = DateTime.Now,
                    Estado = 1
                });
            }
            catch (FaultException<LibrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar crear el libro", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El código del libro ya existe");
            }
        }

        [TestMethod]
        public void Test2ModificarLibroAnulado()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            try
            {
                LibrosWS.Libro libroModificado = proxy.ModificarLibro(new LibrosWS.Libro()
                {
                    CodigoLibro = "L0003",
                    Titulo = "Titulo3",
                    Autor = "Autor3",
                    Editorial = "Editorial3",
                    Paginas = 100,
                    FechaPublicacion = new DateTime(2009, 10, 20),
                    FechaRegistro = DateTime.Now,
                    Estado = 1
                });
            }
            catch (FaultException<LibrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar modificar el libro", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "103");
                Assert.AreEqual(error.Detail.Descripcion, "El libro se encuentra anulado");
            }
        }

        [TestMethod]
        public void Test1ObtenerLibroPorTituloOK()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            LibrosWS.Libro libroCreado = proxy.ObtenerLibroPorTitulo("LIBRO1");

            Assert.AreEqual("LIBRO1", libroCreado.Titulo);
        }

        [TestMethod]
        public void Test1ObtenerLibroPorAutorOK()
        {
            LibrosWS.LibrosClient proxy = new LibrosWS.LibrosClient();
            LibrosWS.Libro libroCreado = proxy.ObtenerLibroPorAutor("AUTOR1");

            Assert.AreEqual("AUTOR1", libroCreado.Autor);
        }
    }
}
