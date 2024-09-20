using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Permisso
{
    public int IdPermissao { get; set; }

    public string NomePermissao { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Funco> IdFuncaos { get; set; } = new List<Funco>();
}
