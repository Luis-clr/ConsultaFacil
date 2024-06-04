using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class ConsultaFacilContext : DbContext
{
    public ConsultaFacilContext()
    {
    }

    public ConsultaFacilContext(DbContextOptions<ConsultaFacilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbConsultum> TbConsulta { get; set; }

    public virtual DbSet<TbEndereco> TbEnderecos { get; set; }

    public virtual DbSet<TbMedico> TbMedicos { get; set; }

    public virtual DbSet<TbPaciente> TbPacientes { get; set; }

    public virtual DbSet<TbPagamento> TbPagamentos { get; set; }

    public virtual DbSet<TbTipoConsultum> TbTipoConsulta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbConsultum>(entity =>
        {
            entity.HasKey(e => e.IdCosulta).HasName("PRIMARY");

            entity.ToTable("tb_consulta");

            entity.HasIndex(e => new { e.TbPacienteIdPaciente, e.TbPacienteCpf }, "fk_Tb_Consulta_Tb_Paciente1_idx");

            entity.HasIndex(e => e.TbTipoConsultaIdTipoConsulta, "fk_Tb_Consulta_Tb_Tipo_consulta1_idx");

            entity.HasIndex(e => e.TbMedicoIdMedico, "fk_Tb_Consulta_Tb_medico1_idx");

            entity.Property(e => e.IdCosulta).HasColumnName("id_Cosulta");
            entity.Property(e => e.DataHoraCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Data_hora_cadastro");
            entity.Property(e => e.DataHoraFinalizada)
                .HasColumnType("datetime")
                .HasColumnName("Data_hora_finalizada");
            entity.Property(e => e.DataHoraPrevista)
                .HasColumnType("datetime")
                .HasColumnName("Data_hora_prevista");
            entity.Property(e => e.DataHoraRealizada)
                .HasColumnType("datetime")
                .HasColumnName("Data_hora_realizada");
            entity.Property(e => e.TbCosultacol)
                .HasMaxLength(45)
                .HasColumnName("Tb_Cosultacol");
            entity.Property(e => e.TbMedicoIdMedico).HasColumnName("Tb_medico_id_medico");
            entity.Property(e => e.TbPacienteCpf)
                .HasMaxLength(11)
                .HasColumnName("Tb_Paciente_Cpf");
            entity.Property(e => e.TbPacienteIdPaciente).HasColumnName("Tb_Paciente_idPaciente");
            entity.Property(e => e.TbTipoConsultaIdTipoConsulta).HasColumnName("Tb_Tipo_consulta_id_Tipo_consulta");
            entity.Property(e => e.Valor).HasPrecision(10);

            entity.HasOne(d => d.TbMedicoIdMedicoNavigation).WithMany(p => p.TbConsulta)
                .HasForeignKey(d => d.TbMedicoIdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tb_Consulta_Tb_medico1");

            entity.HasOne(d => d.TbTipoConsultaIdTipoConsultaNavigation).WithMany(p => p.TbConsulta)
                .HasForeignKey(d => d.TbTipoConsultaIdTipoConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tb_Consulta_Tb_Tipo_consulta1");

            entity.HasOne(d => d.TbPaciente).WithMany(p => p.TbConsulta)
                .HasForeignKey(d => new { d.TbPacienteIdPaciente, d.TbPacienteCpf })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tb_Consulta_Tb_Paciente1");
        });

        modelBuilder.Entity<TbEndereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PRIMARY");

            entity.ToTable("tb_endereco");

            entity.HasIndex(e => new { e.TbPacienteIdPaciente, e.TbPacienteCpf }, "fk_Tb_Endereco_Tb_Paciente1_idx");

            entity.HasIndex(e => e.TbMedicoIdMedico, "fk_Tb_Endereco_Tb_medico1_idx");

            entity.Property(e => e.IdEndereco).HasColumnName("id_Endereco");
            entity.Property(e => e.Cep).HasMaxLength(8);
            entity.Property(e => e.Cidade).HasMaxLength(45);
            entity.Property(e => e.Complemento).HasMaxLength(45);
            entity.Property(e => e.Numero).HasMaxLength(10);
            entity.Property(e => e.Rua).HasMaxLength(45);
            entity.Property(e => e.TbMedicoIdMedico).HasColumnName("Tb_medico_id_medico");
            entity.Property(e => e.TbPacienteCpf)
                .HasMaxLength(11)
                .HasColumnName("Tb_Paciente_Cpf");
            entity.Property(e => e.TbPacienteIdPaciente).HasColumnName("Tb_Paciente_id_Paciente");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");

            entity.HasOne(d => d.TbMedicoIdMedicoNavigation).WithMany(p => p.TbEnderecos)
                .HasForeignKey(d => d.TbMedicoIdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tb_Endereco_Tb_medico1");

            entity.HasOne(d => d.TbPaciente).WithMany(p => p.TbEnderecos)
                .HasForeignKey(d => new { d.TbPacienteIdPaciente, d.TbPacienteCpf })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tb_Endereco_Tb_Paciente1");
        });

        modelBuilder.Entity<TbMedico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PRIMARY");

            entity.ToTable("tb_medico");

            entity.HasIndex(e => e.Crm, "CRM_UNIQUE").IsUnique();

            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.Crm)
                .HasMaxLength(6)
                .HasColumnName("CRM");
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.Status).HasColumnType("enum('Ativo','Inativo','Em periodo de ferias')");
        });

        modelBuilder.Entity<TbPaciente>(entity =>
        {
            entity.HasKey(e => new { e.IdPaciente, e.Cpf }).HasName("PRIMARY");

            entity.ToTable("tb_paciente");

            entity.HasIndex(e => e.Cpf, "Cpf_UNIQUE").IsUnique();

            entity.Property(e => e.IdPaciente)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_Paciente");
            entity.Property(e => e.Cpf).HasMaxLength(11);
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("Data_nascimento");
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.Obs).HasMaxLength(45);
            entity.Property(e => e.Rg)
                .HasMaxLength(8)
                .HasColumnName("RG");
            entity.Property(e => e.Telefone).HasMaxLength(11);
        });

        modelBuilder.Entity<TbPagamento>(entity =>
        {
            entity.HasKey(e => e.IdPagamento).HasName("PRIMARY");

            entity.ToTable("tb_pagamento");

            entity.HasIndex(e => e.TbConsultaIdCosulta, "fk_Tb_Pagamento_Tb_Consulta_idx");

            entity.Property(e => e.IdPagamento).HasColumnName("id_Pagamento");
            entity.Property(e => e.Status).HasColumnType("enum('Aguardando pagamento','Pagamento realizado')");
            entity.Property(e => e.TbConsultaIdCosulta).HasColumnName("Tb_Consulta_id_Cosulta");
            entity.Property(e => e.TipoPagamento)
                .HasMaxLength(45)
                .HasColumnName("Tipo_pagamento");

            entity.HasOne(d => d.TbConsultaIdCosultaNavigation).WithMany(p => p.TbPagamentos)
                .HasForeignKey(d => d.TbConsultaIdCosulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tb_Pagamento_Tb_Consulta");
        });

        modelBuilder.Entity<TbTipoConsultum>(entity =>
        {
            entity.HasKey(e => e.IdTipoConsulta).HasName("PRIMARY");

            entity.ToTable("tb_tipo_consulta");

            entity.Property(e => e.IdTipoConsulta).HasColumnName("id_Tipo_consulta");
            entity.Property(e => e.Nome).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
