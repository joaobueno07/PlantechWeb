using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class ItensVendum
{
    public int PkItem { get; set; }

    public int Quantidade { get; set; }

    public double ValorUnitario { get; set; }

    public int ProdutosPkProdutos { get; set; }

    public virtual Produto ProdutosPkProdutosNavigation { get; set; } = null!;
}
