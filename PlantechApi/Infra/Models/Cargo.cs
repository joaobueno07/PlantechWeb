using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Cargo
{
    public string IdCargo { get; set; } = null!;

    public string NomeCargo { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Funcionariocargo> Funcionariocargos { get; set; } = new List<Funcionariocargo>();

    public virtual ICollection<Funco> IdFuncaos { get; set; } = new List<Funco>();
}
