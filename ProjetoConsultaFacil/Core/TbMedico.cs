using System;
using System.Collections.Generic;

namespace Core;

public partial class TbMedico
{
    public int IdMedico { get; set; }

    public string Nome { get; set; } = null!;

    public string Crm { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<TbConsultum> TbConsulta { get; set; } = new List<TbConsultum>();

    public virtual ICollection<TbResidencium> TbResidencia { get; set; } = new List<TbResidencium>();
}
