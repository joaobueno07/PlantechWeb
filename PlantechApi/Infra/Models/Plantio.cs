using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Plantio
{
    public int IdPlantio { get; set; }

    public int? IdFuncionario { get; set; }

    public DateTime? Data { get; set; }

    public string? Descricao { get; set; }

    public int? Quantidade { get; set; }

    public virtual ICollection<Culturasperdida> Culturasperdida { get; set; } = new List<Culturasperdida>();

    public virtual Funcionario? IdFuncionarioNavigation { get; set; }
}
