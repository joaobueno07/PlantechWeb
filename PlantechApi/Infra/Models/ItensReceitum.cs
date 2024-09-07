using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class ItensReceitum
{
    public int PkItens { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<ItemConsumo> ItemConsumos { get; set; } = new List<ItemConsumo>();
}
