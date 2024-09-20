﻿using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Cliente
{
    public int Cnpj { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Contasreceber> Contasrecebers { get; set; } = new List<Contasreceber>();

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
