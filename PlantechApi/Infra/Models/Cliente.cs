using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Cliente
{
    public int PkCliente { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string? Contato { get; set; }

    public string Email { get; set; } = null!;

    public int Status { get; set; }

    public string FuncionariosPkFuncionario { get; set; } = null!;

    public int FuncionariosCargosPkCargos { get; set; }

    public int FuncionariosProducaoPkProducao { get; set; }
}
