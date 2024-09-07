using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class RecebeConta
{
    public int PkConta { get; set; }

    public double Valor { get; set; }

    public DateTime DataVencimento { get; set; }

    public int ClientePkCliente { get; set; }

    public string FuncionariosPkFuncionario { get; set; } = null!;

    public int FuncionariosCargosPkCargos { get; set; }

    public int FuncionariosProducaoPkProducao { get; set; }
}
