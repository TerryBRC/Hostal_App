using System;
using System.Collections.Generic;

namespace APIHostalAPPMapeado.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public int GrupoId { get; set; }

    public virtual Grupo Grupo { get; set; } = null!;
}
