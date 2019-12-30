using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Articulo
    {
        public int ArticuloId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public bool Estatus { get; set; }
    }
}
