using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string Identificacion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
