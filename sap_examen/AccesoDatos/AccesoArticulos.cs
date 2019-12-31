using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoArticulos : IAccesoArticulos, IDisposable
    {
        string connectionString = StringConexion.ServerName;

        public async Task<List<Articulo>> GetArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetArticulos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Articulo articulo = new Articulo
                            {
                                ArticuloId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Stock = reader.GetInt32(3),
                                Precio = reader.GetDecimal(4),
                                Estatus = Convert.ToBoolean(reader.GetBoolean(5))
                            };
                            articulos.Add(articulo);
                            articulo = null;
                        }
                    }
                }
                connection.Close();
            }
            return articulos;
        }

        public async Task<Articulo> GetArticuloId(int Id)
        {
            Articulo articulo = new Articulo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetArticuloId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ArticuloId", SqlDbType.Int).Value = Id;

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            articulo = new Articulo
                            {
                                ArticuloId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Stock = reader.GetInt32(3),
                                Precio = reader.GetDecimal(4),
                                Estatus = Convert.ToBoolean(reader.GetBoolean(5))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return articulo;
        }

        void IDisposable.Dispose() { }
        public void Dispose(){}
    }
}
