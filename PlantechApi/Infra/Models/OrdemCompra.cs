using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class OrdemCompra
{
    public int PkCompra { get; set; }

    public string Status { get; set; } = null!;

    public string FuncionariosPkFuncionario { get; set; } = null!;

    public int FuncionariosCargosPkCargos { get; set; }

    public string FornecedorPkFornecedor { get; set; } = null!;

    public string PagamentosContasPkPagamento { get; set; } = null!;

    public string PagamentosContasFuncionariosPkFuncionario { get; set; } = null!;

    public int PagamentosContasFuncionariosCargosPkCargos { get; set; }

    public virtual Fornecedor FornecedorPkFornecedorNavigation { get; set; } = null!;

    public virtual PagamentosConta PagamentosConta { get; set; } = null!;
}
