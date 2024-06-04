using System;
using System.Collections.Generic;

namespace Core;

public partial class TbPagamento
{
    public int IdPagamento { get; set; }

    public int TbConsultaIdCosulta { get; set; }

    public string TipoPagamento { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual TbConsultum TbConsultaIdCosultaNavigation { get; set; } = null!;
}
