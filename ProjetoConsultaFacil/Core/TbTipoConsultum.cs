using System;
using System.Collections.Generic;

namespace Core;

public partial class TbTipoConsultum
{
    public int IdTipoConsulta { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<TbConsultum> TbConsulta { get; set; } = new List<TbConsultum>();
}
