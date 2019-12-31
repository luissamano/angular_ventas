using System;

namespace Entities
{
    public class DetalleVenta
    {
        public int VentaId { get; set; }
	    public int Articulo { get; set; }
	    public int Cantidad { get; set; }
	    public decimal Precio { get; set; }
	    public DateTime Fecha_hora { get; set; }
	    public decimal Total { get; set; }
	    public Boolean Estatus { get; set; }
    }    
}