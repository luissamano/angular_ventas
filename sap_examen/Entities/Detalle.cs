using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Detalle
    {
        public int DetalleId { get; set; }
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
