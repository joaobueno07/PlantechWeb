using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime? DataNascimento { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Colheitum> Colheita { get; set; } = new List<Colheitum>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Funcionariocargo> Funcionariocargos { get; set; } = new List<Funcionariocargo>();

    public virtual ICollection<Plantio> Plantios { get; set; } = new List<Plantio>();

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
