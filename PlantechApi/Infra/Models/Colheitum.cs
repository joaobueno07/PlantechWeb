using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Colheitum
{
    public int IdColheita { get; set; }

    public int? IdFuncionario { get; set; }

    public DateTime? Data { get; set; }

    public string? Descricao { get; set; }

    public int? IdProduto { get; set; }

    public int? Quantidade { get; set; }

    public virtual Funcionario? IdFuncionarioNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
