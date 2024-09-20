using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int? IdFornecedor { get; set; }

    public DateTime? Data { get; set; }

    public string? Descricao { get; set; }

    public int? IdFuncionario { get; set; }

    public decimal? Valor { get; set; }

    public virtual Fornecedore? IdFornecedorNavigation { get; set; }

    public virtual Funcionario? IdFuncionarioNavigation { get; set; }
}
