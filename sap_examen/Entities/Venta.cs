using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_hora { get; set; }
        public decimal Total { get; set; }
        public int Estatus { get; set; }
    }
}
