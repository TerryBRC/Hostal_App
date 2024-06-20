using System;

namespace Hostal_App.Models
{
    public class Reserva
    {
        public long Id { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroHuespedes { get; set; }
        public long EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public long ClienteId { get; set; }
        public long HabitacionId { get; set; }
    }
}
