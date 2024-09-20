using System;
using System.Collections.Generic;

namespace Infra.Models;

public partial class Culturasperdida
{
    public int IdCulturaPerdida { get; set; }

    public int? IdPlantio { get; set; }

    public string? Descricao { get; set; }

    public int? Quantidade { get; set; }

    public DateTime? Data { get; set; }

    public virtual Plantio? IdPlantioNavigation { get; set; }
}
