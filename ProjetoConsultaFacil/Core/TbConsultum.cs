using System;
using System.Collections.Generic;

namespace Core;

public partial class TbConsultum
{
    public int IdCosulta { get; set; }

    public decimal Valor { get; set; }

    public string? TbCosultacol { get; set; }

    public int TbPacienteIdPaciente { get; set; }

    public string TbPacienteCpf { get; set; } = null!;

    public DateTime DataHoraCadastro { get; set; }

    public DateTime DataHoraPrevista { get; set; }

    public DateTime? DataHoraRealizada { get; set; }

    public DateTime? DataHoraFinalizada { get; set; }

    public int TbTipoConsultaIdTipoConsulta { get; set; }

    public int TbMedicoIdMedico { get; set; }

    public virtual TbMedico TbMedicoIdMedicoNavigation { get; set; } = null!;

    public virtual TbPaciente TbPaciente { get; set; } = null!;

    public virtual ICollection<TbPagamento> TbPagamentos { get; set; } = new List<TbPagamento>();

    public virtual TbTipoConsultum TbTipoConsultaIdTipoConsultaNavigation { get; set; } = null!;
}
