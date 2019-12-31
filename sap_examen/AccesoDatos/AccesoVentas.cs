using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AccesoVentas : IAccesoVentas
    {
        string connectionString = StringConexion.ServerName;

        public async Task<List<Venta>> GetVentasAnsync()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spVentas", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Venta venta = new Venta
                            {
                                VentaId = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Fecha_hora = reader.GetDateTime(2),
                                Total = reader.GetDecimal(3),
                                Estatus = Convert.ToBoolean(reader.GetInt32(4))

                            };
                            ventas.Add(venta);
                        }
                    }
                }
                connection.Close();
            }
            return ventas;
        }

        public async Task<List<DetalleVenta>> GetDetalleVenta(int Id)
        {
            List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDetalleVenta", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = Id;
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            DetalleVenta detalle = new DetalleVenta 
                            {
                                VentaId = reader.GetInt32(0),
                                Articulo = reader.GetInt32(1),
                                Cantidad = reader.GetInt32(2),
                                Precio = reader.GetDecimal(3),
                                Fecha_hora = reader.GetDateTime(4),
                                Total = reader.GetDecimal(5),
                                Estatus = Convert.ToBoolean(reader.GetInt32(6))
                            };
                            detalleVentas.Add(detalle);
                        }
                    }

                }
                connection.Close();
            }
            return detalleVentas;
        }
    }
}
