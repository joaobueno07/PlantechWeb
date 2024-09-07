using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Fornecedor
{
    public string PkFornecedor { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string? Email { get; set; }

    public int Status { get; set; }

    public virtual ICollection<OrdemCompra> OrdemCompras { get; set; } = new List<OrdemCompra>();

    public virtual ICollection<RelatorioCompra> RelatorioCompras { get; set; } = new List<RelatorioCompra>();
}
