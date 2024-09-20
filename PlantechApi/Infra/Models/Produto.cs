﻿using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public decimal? Preco { get; set; }

    public virtual ICollection<Colheitum> Colheita { get; set; } = new List<Colheitum>();

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<Movimentacao> Movimentacaos { get; set; } = new List<Movimentacao>();

    public virtual ICollection<Produtosvendido> Produtosvendidos { get; set; } = new List<Produtosvendido>();
}
