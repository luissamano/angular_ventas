using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Venta>> GetVentas()
        {
            var context = new AccesoVentas();
            
            return await context.GetVentasAnsync();            
        }

        [HttpGet("detalle")]
        public async Task<List<DetalleVenta>> GetVentaDetalle([FromBody] Venta venta)
        {
            var context = new AccesoVentas();
            
            return await context.GetDetalleVenta(Id: venta.VentaId);            
        }
    }
}