using System;
using System.Collections.Generic;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.DatabaseContext;

public partial class CorteAutomaticoContext : DbContext
{
    public CorteAutomaticoContext()
    {
    }

    public CorteAutomaticoContext(DbContextOptions<CorteAutomaticoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteInstalacao> ClienteInstalacaos { get; set; }

    public virtual DbSet<ColaboradorFinanciadora> ColaboradorFinanciadoras { get; set; }

    public virtual DbSet<ColaboradorIntegrador> ColaboradorIntegradors { get; set; }

    public virtual DbSet<Comando> Comandos { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<DispositivoInstalacao> DispositivoInstalacaos { get; set; }

    public virtual DbSet<DispositivoMarca> DispositivoMarcas { get; set; }

    public virtual DbSet<DispositivoModelo> DispositivoModelos { get; set; }

    public virtual DbSet<Financiadora> Financiadoras { get; set; }

    public virtual DbSet<FinanciadoraPerfil> FinanciadoraPerfils { get; set; }

    public virtual DbSet<Financiamento> Financiamentos { get; set; }

    public virtual DbSet<Instalacao> Instalacaos { get; set; }

    public virtual DbSet<InstalacaoArquivo> InstalacaoArquivos { get; set; }

    public virtual DbSet<InstalacaoIntegrador> InstalacaoIntegradors { get; set; }

    public virtual DbSet<InstalacaoStatus> InstalacaoStatuses { get; set; }

    public virtual DbSet<Integrador> Integradors { get; set; }

    public virtual DbSet<IntegradorPerfil> IntegradorPerfils { get; set; }

    public virtual DbSet<LogPerfilUsuario> LogPerfilUsuarios { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<PerfilPermissao> PerfilPermissaos { get; set; }

    public virtual DbSet<Permissao> Permissaos { get; set; }

    public virtual DbSet<SolicitacaoIntervencao> SolicitacaoIntervencaos { get; set; }

    public virtual DbSet<SolicitacaoIntervencaoLog> SolicitacaoIntervencaoLogs { get; set; }

    public virtual DbSet<SolicitacaoIntervencaoStatus> SolicitacaoIntervencaoStatuses { get; set; }

    public virtual DbSet<SolicitacaoResetSenha> SolicitacaoResetSenhas { get; set; }

    public virtual DbSet<TipoArquivo> TipoArquivos { get; set; }

    public virtual DbSet<TipoComando> TipoComandos { get; set; }

    public virtual DbSet<TipoDispositivo> TipoDispositivos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoSolicitacaoIntervencao> TipoSolicitacaoIntervencaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioSenha> UsuarioSenhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        EnvironmentVar env = new("ASPNETCORE_ENVIRONMENT");
        EnvironmentVar connStr = env.ToString() == "TESTS" 
            ? new("TESTS_DATABASE_CONNECTION_STRING") 
            : new("DATABASE_CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connStr.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cliente_id");

            entity.HasOne(d => d.Financiadora).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cliente_financiadora");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cliente_tipo_documento");
        });

        modelBuilder.Entity<ClienteInstalacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cliente_instalacao_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ClienteInstalacaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cliente_instalacao_cliente");

            entity.HasOne(d => d.Instalacao).WithMany(p => p.ClienteInstalacaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cliente_instalacao_instalacao");
        });

        modelBuilder.Entity<ColaboradorFinanciadora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_colaborador_financiadora_id");

            entity.HasOne(d => d.Financiadora).WithMany(p => p.ColaboradorFinanciadoras)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_colaborador_financiadora_financiadora");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ColaboradorFinanciadoras)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_colaborador_financiadora_usuario");
        });

        modelBuilder.Entity<ColaboradorIntegrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_colaborador_integrador_id");

            entity.HasOne(d => d.Integrador).WithMany(p => p.ColaboradorIntegradors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_colaborador_integrador_integradorforeign");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ColaboradorIntegradors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_colaborador_integrador_usuario");
        });

        modelBuilder.Entity<Comando>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_comando_id");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Comandos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comando_dispositivo");

            entity.HasOne(d => d.TipoComando).WithMany(p => p.Comandos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comando_tipo_comando");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_dispositivo_id");

            entity.HasOne(d => d.DispositivoModelo).WithMany(p => p.Dispositivos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dispositivo_dispositivo_modelo");
        });

        modelBuilder.Entity<DispositivoInstalacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_dispositivo_instalacao_id");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.DispositivoInstalacaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dispositivo_instalacao_dispositivo");

            entity.HasOne(d => d.Instalacao).WithMany(p => p.DispositivoInstalacaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dispositivo_instalacao_instalacao");
        });

        modelBuilder.Entity<DispositivoMarca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_dispositivo_marca_id");

            entity.HasOne(d => d.TipoDispositivo).WithMany(p => p.DispositivoMarcas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dispositivo_marca_tipo_dispositivo");
        });

        modelBuilder.Entity<DispositivoModelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_dispositivo_modelo_id");

            entity.HasOne(d => d.DispositivoMarca).WithMany(p => p.DispositivoModelos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dispositivo_modelo_dispositivo_marca");
        });

        modelBuilder.Entity<Financiadora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_financiadora_id");
        });

        modelBuilder.Entity<FinanciadoraPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_financiadora_perfil_id");

            entity.HasOne(d => d.Financiadora).WithMany(p => p.FinanciadoraPerfils)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_financiadora_perfil_financiadora");

            entity.HasOne(d => d.Perfil).WithMany(p => p.FinanciadoraPerfils)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_financiadora_perfil_perfil");
        });

        modelBuilder.Entity<Financiamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_financiamento_id");

            entity.HasOne(d => d.Financiadora).WithMany(p => p.Financiamentos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_financiamento_financiadora");

            entity.HasOne(d => d.Instalacao).WithMany(p => p.Financiamentos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_financiamento_instalacao");
        });

        modelBuilder.Entity<Instalacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_instalacao_id");

            entity.HasOne(d => d.InstalacaoStatus).WithMany(p => p.Instalacaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_instalacao_instalacao_status");
        });

        modelBuilder.Entity<InstalacaoArquivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_instalacao_arquivo_id");

            entity.HasOne(d => d.Instalacao).WithMany(p => p.InstalacaoArquivos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_instalacao_arquivo_instalacao");

            entity.HasOne(d => d.TipoArquivo).WithMany(p => p.InstalacaoArquivos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_instalacao_arquivo_tipo_arquivo");
        });

        modelBuilder.Entity<InstalacaoIntegrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_instalacao_integrador_id");

            entity.HasOne(d => d.Instalacao).WithMany(p => p.InstalacaoIntegradors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_instalacao_integrador_instalacao");

            entity.HasOne(d => d.Integrador).WithMany(p => p.InstalacaoIntegradors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_instalacao_integrador_integrador");
        });

        modelBuilder.Entity<InstalacaoStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_instalacao_status_id");
        });

        modelBuilder.Entity<Integrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_integrador_id");
        });

        modelBuilder.Entity<IntegradorPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_integrador_perfil_id");

            entity.HasOne(d => d.Integrador).WithMany(p => p.IntegradorPerfils)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_integrador_perfil_integrador");

            entity.HasOne(d => d.Perfil).WithMany(p => p.IntegradorPerfils)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_integrador_perfil_perfil");
        });

        modelBuilder.Entity<LogPerfilUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_log_perfil_usuario_id");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_perfil_id");
        });

        modelBuilder.Entity<PerfilPermissao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_perfil_permissao_id");

            entity.HasOne(d => d.Perfil).WithMany(p => p.PerfilPermissaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_perfil_permissao_perfil");

            entity.HasOne(d => d.Permissao).WithMany(p => p.PerfilPermissaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_perfil_permissao_permissao");
        });

        modelBuilder.Entity<Permissao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_permissao_id");
        });

        modelBuilder.Entity<SolicitacaoIntervencao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_solicitacao_intervencao_id");

            entity.HasOne(d => d.Financiamento).WithMany(p => p.SolicitacaoIntervencaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_solicitacao_intervencao_financiamento");

            entity.HasOne(d => d.SolicitacaoIntervencaoStatus).WithMany(p => p.SolicitacaoIntervencaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_solicitacao_intervencao_solicitacao_intervencao_status");

            entity.HasOne(d => d.TipoSolicitacaoIntervencao).WithMany(p => p.SolicitacaoIntervencaos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_solicitacao_intervencao_tipo_solicitacao_intervencao");
        });

        modelBuilder.Entity<SolicitacaoIntervencaoLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_solicitacao_intervencao_log_id");

            entity.HasOne(d => d.SolicitacaoIntervencao).WithMany(p => p.SolicitacaoIntervencaoLogs)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_solicitacao_intervencao_log_solicitacao_intervencao");

            entity.HasOne(d => d.StatusAnteriorNavigation).WithMany(p => p.SolicitacaoIntervencaoLogStatusAnteriorNavigations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_solicitacao_intervencao_log_status_anterior");

            entity.HasOne(d => d.StatusCorrenteNavigation).WithMany(p => p.SolicitacaoIntervencaoLogStatusCorrenteNavigations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_solicitacao_intervencao_log_status_status_corrente");
        });

        modelBuilder.Entity<SolicitacaoIntervencaoStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_solicitacao_intervencao_status_id");
        });

        modelBuilder.Entity<SolicitacaoResetSenha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_solicitacao_reset_senha_id");
        });

        modelBuilder.Entity<TipoArquivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tipo_arquivo_id");
        });

        modelBuilder.Entity<TipoComando>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tipo_comando_id");
        });

        modelBuilder.Entity<TipoDispositivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tipo_dispositivo_id");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tipo_documento_id");
        });

        modelBuilder.Entity<TipoSolicitacaoIntervencao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tipo_solicitacao_intervencao_id");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_usuario_id");

            entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_usuario_perfil");
        });

        modelBuilder.Entity<UsuarioSenha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_usuario_senha_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioSenhas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_usuario_senha_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
