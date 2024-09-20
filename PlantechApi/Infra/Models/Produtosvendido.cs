using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Produtosvendido
{
    public int IdProdutoVendido { get; set; }

    public int? IdVenda { get; set; }

    public int? IdProduto { get; set; }

    public int? Quantidade { get; set; }

    public DateTime? DataVenda { get; set; }

    public decimal? ValorTotal { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }

    public virtual Venda? IdVendaNavigation { get; set; }
}
