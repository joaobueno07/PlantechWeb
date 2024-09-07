using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class PagamentosConta
{
    public string PkPagamento { get; set; } = null!;

    public double Valor { get; set; }

    public DateTime DataVencimento { get; set; }

    public string FuncionariosPkFuncionario { get; set; } = null!;

    public int FuncionariosCargosPkCargos { get; set; }

    public virtual ICollection<OrdemCompra> OrdemCompras { get; set; } = new List<OrdemCompra>();
}
