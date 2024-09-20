using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Contasreceber
{
    public int IdContaReceber { get; set; }

    public int? IdCliente { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? DataVencimento { get; set; }

    public string? Status { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
