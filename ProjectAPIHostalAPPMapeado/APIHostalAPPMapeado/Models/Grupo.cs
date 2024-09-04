using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class Grupo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<GruposPermiso> GruposPermisos { get; set; } = new List<GruposPermiso>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
