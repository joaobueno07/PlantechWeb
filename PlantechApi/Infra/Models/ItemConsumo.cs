using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class ItemConsumo
{
    public int PkItem { get; set; }

    public int Quantidade { get; set; }

    public double Valor { get; set; }

    public int ItensReceitaPkItens { get; set; }

    public int ProdutosPkProdutos { get; set; }

    public virtual ItensReceitum ItensReceitaPkItensNavigation { get; set; } = null!;

    public virtual Produto ProdutosPkProdutosNavigation { get; set; } = null!;
}
