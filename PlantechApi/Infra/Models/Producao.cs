using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Producao
{
    public int PkProducao { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime Data { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<RelatorioProducao> RelatorioProducaos { get; set; } = new List<RelatorioProducao>();
}
