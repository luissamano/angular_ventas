using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccesoDatos
{
    interface IAccesoVentas
    {
        Task<List<Venta>> GetVentasAnsync();
        Task<List<DetalleVenta>> GetDetalleVenta(int Id);
    }
}
