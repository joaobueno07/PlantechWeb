using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Produto
{
    public int PkProdutos { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public double PrecoVenda { get; set; }

    public int QuantidadeEstoque { get; set; }

    public int InsumoConsumo { get; set; }

    public double PrecoCompra { get; set; }

    public virtual ICollection<ItemConsumo> ItemConsumos { get; set; } = new List<ItemConsumo>();

    public virtual ICollection<ItemProduzido> ItemProduzidos { get; set; } = new List<ItemProduzido>();

    public virtual ICollection<ItensVendum> ItensVenda { get; set; } = new List<ItensVendum>();
}
