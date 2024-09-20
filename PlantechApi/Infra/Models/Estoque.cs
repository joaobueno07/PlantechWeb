using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Estoque
{
    public int IdEstoque { get; set; }

    public int? IdInsumo { get; set; }

    public string? TipoItem { get; set; }

    public int? Quantidade { get; set; }

    public DateTime? DataEntrada { get; set; }

    public int? IdProduto { get; set; }

    public DateTime? DataSaida { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
