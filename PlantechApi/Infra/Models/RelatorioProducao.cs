using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class RelatorioProducao
{
    public int PkRelatorio { get; set; }

    public DateTime DataRelatorio { get; set; }

    public string Conteudo { get; set; } = null!;

    public int ProducaoPkProducao { get; set; }

    public virtual Producao ProducaoPkProducaoNavigation { get; set; } = null!;
}
