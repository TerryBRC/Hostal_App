using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class GruposPermiso
{
    public long Id { get; set; }

    public int GrupoId { get; set; }

    public int PermisoId { get; set; }

    public virtual Grupo Grupo { get; set; } = null!;

    public virtual Permiso Permiso { get; set; } = null!;
}
