using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Niveisacesso
{
    public int IdNivelAcesso { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Funcionariocargo> Funcionariocargos { get; set; } = new List<Funcionariocargo>();
}
