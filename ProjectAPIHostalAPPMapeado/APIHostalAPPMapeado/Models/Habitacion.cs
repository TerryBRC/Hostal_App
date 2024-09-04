using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class Habitacion
{
    public long Id { get; set; }

    public string Numero { get; set; } = null!;

    public int CapacidadMaxima { get; set; }

    public decimal PrecioPorNoche { get; set; }

    public bool Disponible { get; set; }

    public long TipoHabitacionId { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual TipoHabitacion TipoHabitacion { get; set; } = null!;
}
