using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Fornecedore
{
    public int Cnpj { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Ordemcompra> Ordemcompras { get; set; } = new List<Ordemcompra>();
}
