using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    interface IAccesoArticulos
    {
        Task<List<Articulo>> GetArticulos();
        Task<Articulo> GetArticuloId(int Id);
    }
}
