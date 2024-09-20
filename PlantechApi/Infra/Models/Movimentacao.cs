using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Movimentacao
{
    public int IdMovimentacao { get; set; }

    public int? IdInsumo { get; set; }

    public string? TipoItem { get; set; }

    public string? TipoMovimentacao { get; set; }

    public int? Quantidade { get; set; }

    public int? IdProduto { get; set; }

    public DateTime? Data { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
