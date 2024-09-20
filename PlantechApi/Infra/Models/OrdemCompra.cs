﻿using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Ordemcompra
{
    public int IdOrdemCompra { get; set; }

    public int? IdFornecedor { get; set; }

    public DateTime? Data { get; set; }

    public string? Descricao { get; set; }

    public decimal? Valor { get; set; }

    public string? Status { get; set; }

    public virtual Fornecedore? IdFornecedorNavigation { get; set; }
}
