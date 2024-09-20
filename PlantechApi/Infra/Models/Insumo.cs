using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Insumo
{
    public int IdInsumo { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public int? Quantidade { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<Movimentacao> Movimentacaos { get; set; } = new List<Movimentacao>();
}
