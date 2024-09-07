using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class RelatorioCompra
{
    public int PkRelatorio { get; set; }

    public DateTime Data { get; set; }

    public double TotalCompras { get; set; }

    public string ProdutosLista { get; set; } = null!;

    public string QuantidadeProdutos { get; set; } = null!;

    public string FornecedorPkFornecedor { get; set; } = null!;

    public string FuncionariosPkFuncionario { get; set; } = null!;

    public int FuncionariosCargosPkCargos { get; set; }

    public int FuncionariosProducaoPkProducao { get; set; }

    public virtual Fornecedor FornecedorPkFornecedorNavigation { get; set; } = null!;
}
