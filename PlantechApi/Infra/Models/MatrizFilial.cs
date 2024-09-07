using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class MatrizFilial
{
    public string PkEmpresa { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public int? Numero { get; set; }

    public DateTime DataIni { get; set; }
}
