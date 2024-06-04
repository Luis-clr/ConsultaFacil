using System;
using System.Collections.Generic;

namespace Core;

public partial class TbPaciente
{
    public int IdPaciente { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string? Telefone { get; set; }

    public DateTime DataNascimento { get; set; }

    public string? Obs { get; set; }

    public virtual ICollection<TbConsultum> TbConsulta { get; set; } = new List<TbConsultum>();

    public virtual ICollection<TbEndereco> TbEnderecos { get; set; } = new List<TbEndereco>();
}
