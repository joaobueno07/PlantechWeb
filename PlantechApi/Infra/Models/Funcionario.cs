using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Funcionario
{
    public string PkFuncionario { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public DateTime DataAdm { get; set; }

    public DateTime DataDem { get; set; }

    public int ProducaoPkProducao { get; set; }

    public virtual Producao ProducaoPkProducaoNavigation { get; set; } = null!;
}
