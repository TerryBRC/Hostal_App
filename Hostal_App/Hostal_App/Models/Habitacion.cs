namespace Hostal_App.Models
{
    public class Habitacion
    {
        public long Id { get; set; }
        public string Numero { get; set; }
        public int CapacidadMaxima { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public bool Disponible { get; set; }
        public long TipoHabitacionId { get; set; }
    }

}
