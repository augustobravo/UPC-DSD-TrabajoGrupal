using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFBiblioteca.Dominio;

namespace WCFBiblioteca.Persistencia
{
    public class LibroDAO
    {
        private string cadenaConexion = @"Data Source=AUGUSTO-PC\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

        public Libro Crear(Libro libroACrear)
        {
            Libro libroCreado = null;
            string sql = "INSERT INTO t_libro VALUES (@codlibro, @titulo, @paginas, @editorial, @autor, @fechapublicacion, @fecharegistro, @estado)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codlibro", libroACrear.CodigoLibro));
                    comando.Parameters.Add(new SqlParameter("@titulo", libroACrear.Titulo));
                    comando.Parameters.Add(new SqlParameter("@paginas", libroACrear.Paginas));
                    comando.Parameters.Add(new SqlParameter("@editorial", libroACrear.Editorial));
                    comando.Parameters.Add(new SqlParameter("@autor", libroACrear.Autor));
                    comando.Parameters.Add(new SqlParameter("@fechapublicacion", libroACrear.FechaPublicacion));
                    comando.Parameters.Add(new SqlParameter("@fecharegistro", libroACrear.FechaRegistro));
                    comando.Parameters.Add(new SqlParameter("@estado", libroACrear.Estado));
                    comando.ExecuteNonQuery();
                }
            }
            libroCreado = ObtenerPorCodigo(libroACrear.CodigoLibro);
            return libroCreado;
        }

        public Libro ObtenerPorCodigo(string codigoLibro)
        {
            Libro libroEncontrado = null;
            string sql = "SELECT * FROM t_libro WHERE codlibro = @codlibro";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codlibro", codigoLibro));
                    using(SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if(resultado.Read())
                        {
                            libroEncontrado = new Libro()
                            {
                                CodigoLibro = (string)resultado["codlibro"],
                                Titulo = (string)resultado["titulo"],
                                Paginas = (int)resultado["paginas"],
                                Editorial = (string)resultado["editorial"],
                                Autor = (string)resultado["autor"],
                                FechaPublicacion = (DateTime)resultado["fechapublicacion"],
                                Estado = (int)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return libroEncontrado;

        }

        public Libro ObtenerPorTitulo(string titulo)
        {
            Libro libroEncontrado = null;
            string sql = "SELECT * FROM t_libro WHERE titulo = @titulo";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@titulo", titulo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            libroEncontrado = new Libro()
                            {
                                CodigoLibro = (string)resultado["codlibro"],
                                Titulo = (string)resultado["titulo"],
                                Paginas = (int)resultado["paginas"],
                                Editorial = (string)resultado["editorial"],
                                Autor = (string)resultado["autor"],
                                FechaPublicacion = (DateTime)resultado["fechapublicacion"],
                                Estado = (int)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return libroEncontrado;

        }

        public Libro ObtenerPorAutor(string autor)
        {
            Libro libroEncontrado = null;
            string sql = "SELECT * FROM t_libro WHERE autor = @autor";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@autor", autor));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            libroEncontrado = new Libro()
                            {
                                CodigoLibro = (string)resultado["codlibro"],
                                Titulo = (string)resultado["titulo"],
                                Paginas = (int)resultado["paginas"],
                                Editorial = (string)resultado["editorial"],
                                Autor = (string)resultado["autor"],
                                FechaPublicacion = (DateTime)resultado["fechapublicacion"],
                                Estado = (int)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return libroEncontrado;

        }

        public Libro Modificar(Libro libroAModificar)
        {
            Libro libroModificado = null;
            string sql = "UPDATE t_libro SET titulo = @titulo, paginas = @paginas, editorial = @editorial, autor = @autor, fechapublicacion = @fechapublicacion WHERE codlibro = @codlibro";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@titulo", libroAModificar.Titulo));
                    comando.Parameters.Add(new SqlParameter("@paginas", libroAModificar.Paginas));
                    comando.Parameters.Add(new SqlParameter("@editorial", libroAModificar.Editorial));
                    comando.Parameters.Add(new SqlParameter("@autor", libroAModificar.Autor));
                    comando.Parameters.Add(new SqlParameter("@fechapublicacion", libroAModificar.FechaPublicacion));
                    comando.Parameters.Add(new SqlParameter("@codlibro", libroAModificar.CodigoLibro));
                    comando.ExecuteNonQuery();
                }
            }
            libroModificado = ObtenerPorCodigo(libroAModificar.CodigoLibro);
            return libroModificado;
        }

        public void Eliminar(string codigoLibro)
        {
            string sql = "UPDATE t_libro SET estado = 0 WHERE codlibro = @codlibro";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codlibro", codigoLibro));
                    comando.ExecuteNonQuery();
                }
            }

        }

        public List<Libro> Listar()
        {
            List<Libro> librosEncontrados = new List<Libro>();
            Libro libroEncontrado = null;
            string sql = "SELECT * from t_libro";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            libroEncontrado = new Libro()
                            {
                                CodigoLibro = (string)resultado["codlibro"],
                                Titulo = (string)resultado["titulo"],
                                Paginas = (int)resultado["paginas"],
                                Editorial = (string)resultado["editorial"],
                                Autor = (string)resultado["autor"],
                                FechaPublicacion = (DateTime)resultado["fechapublicacion"],
                                Estado = (int)resultado["estado"]
                            };
                            librosEncontrados.Add(libroEncontrado);
                        }
                    }
                }
            }

            return librosEncontrados;
        }


    }
}