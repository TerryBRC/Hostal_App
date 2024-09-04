using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class TipoHabitacion
{
    public long Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
