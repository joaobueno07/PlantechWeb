using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class ItemProduzido
{
    public int PkItem { get; set; }

    public int Quantidade { get; set; }

    public double Valor { get; set; }

    public DateTime? DataValidade { get; set; }

    public int ProducaoPkProducao { get; set; }

    public int ProducaoItensReceitaPkItens { get; set; }

    public int ProdutosPkProdutos { get; set; }

    public virtual Produto ProdutosPkProdutosNavigation { get; set; } = null!;
}
