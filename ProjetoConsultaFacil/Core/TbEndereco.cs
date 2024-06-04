using System;
using System.Collections.Generic;

namespace Core;

public partial class TbEndereco
{
    public int IdEndereco { get; set; }

    public int TbPacienteIdPaciente { get; set; }

    public string TbPacienteCpf { get; set; } = null!;

    public int TbMedicoIdMedico { get; set; }

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Complemento { get; set; }

    public string Cep { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public virtual TbMedico TbMedicoIdMedicoNavigation { get; set; } = null!;

    public virtual TbPaciente TbPaciente { get; set; } = null!;
}
