using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Venda
{
    public int IdVenda { get; set; }

    public int? IdCliente { get; set; }

    public DateTime? Data { get; set; }

    public string? Descricao { get; set; }

    public int? IdFuncionario { get; set; }

    public decimal? Valor { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Funcionario? IdFuncionarioNavigation { get; set; }

    public virtual ICollection<Produtosvendido> Produtosvendidos { get; set; } = new List<Produtosvendido>();
}
