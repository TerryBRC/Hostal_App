using System;

namespace Hostal_App.Models
{
    public class Factura
    {
        public long Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }
        public string DetalleServicios { get; set; }
        public long ReservaId { get; set; }
    }
}
