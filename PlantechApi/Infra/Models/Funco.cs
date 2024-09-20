using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Funco
{
    public int IdFuncao { get; set; }

    public string NomeFuncao { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Cargo> IdCargos { get; set; } = new List<Cargo>();

    public virtual ICollection<Permisso> IdPermissaos { get; set; } = new List<Permisso>();
}
