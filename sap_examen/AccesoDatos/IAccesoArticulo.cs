using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccesoDatos
{
    interface IAccesoArticulo
    {
        Task<List<Articulo>> GetArticulos();

        Task<Articulo> GetArticuloId(int Id);
    }
}