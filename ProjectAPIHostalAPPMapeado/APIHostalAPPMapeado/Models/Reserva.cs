using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class Reserva
{
    public long Id { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public int NumeroHuespedes { get; set; }

    public string? Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaModificacion { get; set; }

    public long ClienteId { get; set; }

    public long HabitacionId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Habitacion Habitacion { get; set; } = null!;
}
