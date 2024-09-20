using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Funcionariocargo
{
    public int IdFuncionario { get; set; }

    public string IdCargo { get; set; } = null!;

    public int IdNivelAcesso { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual Niveisacesso IdNivelAcessoNavigation { get; set; } = null!;
}
