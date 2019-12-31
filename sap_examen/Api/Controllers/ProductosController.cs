using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccesoDatos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {   
        [HttpGet]
        public async Task<List<Articulo>> GetArticulosAsync()
        {       
            using (var context = new AccesoArticulos())
            {
                return await context.GetArticulos();
            }
        }

        [HttpGet("id")]
        public async Task<Articulo> GetArticuloIdAsync([FromBody] Articulo articulo)
        {
           using (var context = new AccesoArticulos())
            {
                return await context.GetArticuloId(articulo.ArticuloId);
            }
        }
    }
}