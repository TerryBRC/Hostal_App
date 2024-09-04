using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<GruposPermiso> GruposPermisos { get; set; } = new List<GruposPermiso>();
}
