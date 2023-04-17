using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CorteAutomatico.Core.Migrations
{
    /// <inheritdoc />
    public partial class _202304112024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "financiadora",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome_fantasia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    razao_social = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financiadora_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instalacao_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_instalacao_status_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "integrador",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome_fantasia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    razao_social = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_integrador_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "log_perfil_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    perfil_id = table.Column<int>(type: "integer", nullable: false),
                    usuario_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_log_perfil_usuario_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_perfil_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissao_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "solicitacao_intervencao_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_solicitacao_intervencao_status_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "solicitacao_reset_senha",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    expira_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_solicitacao_reset_senha_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_arquivo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_arquivo_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_comando",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_comando_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_dispositivo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_dispositivo_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_documento_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_solicitacao_intervencao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_solicitacao_intervencao_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instalacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco_uf_estado = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_referencia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_numero = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_cep = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    obs = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    instalacao_status_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_instalacao_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_instalacao_instalacao_status",
                        column: x => x.instalacao_status_id,
                        principalTable: "instalacao_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "financiadora_perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    perfil_id = table.Column<int>(type: "integer", nullable: false),
                    financiadora_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financiadora_perfil_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_financiadora_perfil_financiadora",
                        column: x => x.financiadora_id,
                        principalTable: "financiadora",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_financiadora_perfil_perfil",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "integrador_perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    perfil_id = table.Column<int>(type: "integer", nullable: false),
                    integrador_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_integrador_perfil_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_integrador_perfil_integrador",
                        column: x => x.integrador_id,
                        principalTable: "integrador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_integrador_perfil_perfil",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    perfil_id = table.Column<int>(type: "integer", nullable: false),
                    cpf = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email_confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    email_confirmacao_token = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email_confirmacao_expira_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_usuario_perfil",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "perfil_permissao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    perfil_id = table.Column<int>(type: "integer", nullable: false),
                    permissao_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_perfil_permissao_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_perfil_permissao_perfil",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_perfil_permissao_permissao",
                        column: x => x.permissao_id,
                        principalTable: "permissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dispositivo_marca",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipo_dispositivo_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositivo_marca_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_dispositivo_marca_tipo_dispositivo",
                        column: x => x.tipo_dispositivo_id,
                        principalTable: "tipo_dispositivo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    financiadora_id = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    razao_social = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    nome_fantasia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    numero_documento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipo_documento_id = table.Column<int>(type: "integer", nullable: false),
                    data_nascimento = table.Column<DateOnly>(type: "date", nullable: true),
                    nome_mae = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telefone_1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telefone_2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    endereco_uf_estado = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco_cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco_logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco_complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco_referencia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco_numero = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    obs = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    endereco_cep = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cliente_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_cliente_financiadora",
                        column: x => x.financiadora_id,
                        principalTable: "financiadora",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cliente_tipo_documento",
                        column: x => x.tipo_documento_id,
                        principalTable: "tipo_documento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "financiamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    financiadora_id = table.Column<int>(type: "integer", nullable: false),
                    instalacao_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(12,3)", precision: 12, scale: 3, nullable: false),
                    moeda = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    data_encerramento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financiamento_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_financiamento_financiadora",
                        column: x => x.financiadora_id,
                        principalTable: "financiadora",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_financiamento_instalacao",
                        column: x => x.instalacao_id,
                        principalTable: "instalacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instalacao_arquivo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    instalacao_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_arquivo_id = table.Column<int>(type: "integer", nullable: false),
                    path_file = table.Column<string>(type: "text", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_instalacao_arquivo_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_instalacao_arquivo_instalacao",
                        column: x => x.instalacao_id,
                        principalTable: "instalacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_instalacao_arquivo_tipo_arquivo",
                        column: x => x.tipo_arquivo_id,
                        principalTable: "tipo_arquivo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instalacao_integrador",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    integrador_id = table.Column<int>(type: "integer", nullable: false),
                    instalacao_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_instalacao_integrador_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_instalacao_integrador_instalacao",
                        column: x => x.instalacao_id,
                        principalTable: "instalacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_instalacao_integrador_integrador",
                        column: x => x.integrador_id,
                        principalTable: "integrador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "colaborador_financiadora",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<int>(type: "integer", nullable: false),
                    financiadora_id = table.Column<int>(type: "integer", nullable: false),
                    email_corporativo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    matricula = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_colaborador_financiadora_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_colaborador_financiadora_financiadora",
                        column: x => x.financiadora_id,
                        principalTable: "financiadora",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_colaborador_financiadora_usuario",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "colaborador_integrador",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<int>(type: "integer", nullable: false),
                    integrador_id = table.Column<int>(type: "integer", nullable: false),
                    email_corporativo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    matricula = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_colaborador_integrador_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_colaborador_integrador_integradorforeign",
                        column: x => x.integrador_id,
                        principalTable: "integrador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_colaborador_integrador_usuario",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario_senha",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<int>(type: "integer", nullable: false),
                    senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    data_expiracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario_senha_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_usuario_senha_usuario",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dispositivo_modelo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dispositivo_marca_id = table.Column<int>(type: "integer", nullable: false),
                    compativel = table.Column<bool>(type: "boolean", nullable: false),
                    quantidade_fases = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositivo_modelo_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_dispositivo_modelo_dispositivo_marca",
                        column: x => x.dispositivo_marca_id,
                        principalTable: "dispositivo_marca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cliente_instalacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<int>(type: "integer", nullable: false),
                    instalacao_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cliente_instalacao_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_cliente_instalacao_cliente",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cliente_instalacao_instalacao",
                        column: x => x.instalacao_id,
                        principalTable: "instalacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "solicitacao_intervencao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    financiamento_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_solicitacao_intervencao_id = table.Column<int>(type: "integer", nullable: false),
                    solicitacao_intervencao_status_id = table.Column<int>(type: "integer", nullable: false),
                    motivo_solicitacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    data_agendamento_intervencao = table.Column<DateOnly>(type: "date", nullable: false),
                    hora_agendamento_intervencao = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_solicitacao_intervencao_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_solicitacao_intervencao_financiamento",
                        column: x => x.financiamento_id,
                        principalTable: "financiamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_solicitacao_intervencao_solicitacao_intervencao_status",
                        column: x => x.solicitacao_intervencao_status_id,
                        principalTable: "solicitacao_intervencao_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_solicitacao_intervencao_tipo_solicitacao_intervencao",
                        column: x => x.tipo_solicitacao_intervencao_id,
                        principalTable: "tipo_solicitacao_intervencao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dispositivo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    serial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero_sms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    validado = table.Column<bool>(type: "boolean", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    dispositivo_modelo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositivo_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_dispositivo_dispositivo_modelo",
                        column: x => x.dispositivo_modelo_id,
                        principalTable: "dispositivo_modelo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "solicitacao_intervencao_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    solicitacao_intervencao_id = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    obs = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status_anterior = table.Column<int>(type: "integer", nullable: true),
                    status_corrente = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_solicitacao_intervencao_log_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_solicitacao_intervencao_log_solicitacao_intervencao",
                        column: x => x.solicitacao_intervencao_id,
                        principalTable: "solicitacao_intervencao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_solicitacao_intervencao_log_status_anterior",
                        column: x => x.status_anterior,
                        principalTable: "solicitacao_intervencao_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_solicitacao_intervencao_log_status_status_corrente",
                        column: x => x.status_corrente,
                        principalTable: "solicitacao_intervencao_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comando",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    dispositivo_id = table.Column<int>(type: "integer", nullable: false),
                    numero_destinatario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    msg = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    situacao_envio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    situacao_mensagem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    id_mensagem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    codigo_erro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    data_agendamento_envio = table.Column<DateOnly>(type: "date", nullable: true),
                    hora_agendamento_envio = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    numero_resposta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    id_resposta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    texto_resposta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtd_creditos_consumidos = table.Column<int>(type: "integer", nullable: true),
                    operadora = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    tipo_comando_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comando_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_comando_dispositivo",
                        column: x => x.dispositivo_id,
                        principalTable: "dispositivo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comando_tipo_comando",
                        column: x => x.tipo_comando_id,
                        principalTable: "tipo_comando",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dispositivo_instalacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    dispositivo_id = table.Column<int>(type: "integer", nullable: false),
                    instalacao_id = table.Column<int>(type: "integer", nullable: false),
                    criado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modificado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositivo_instalacao_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_dispositivo_instalacao_dispositivo",
                        column: x => x.dispositivo_id,
                        principalTable: "dispositivo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_dispositivo_instalacao_instalacao",
                        column: x => x.instalacao_id,
                        principalTable: "instalacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_financiadora_id",
                table: "cliente",
                column: "financiadora_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_tipo_documento_id",
                table: "cliente",
                column: "tipo_documento_id");

            migrationBuilder.CreateIndex(
                name: "uk_cliente_uuid",
                table: "cliente",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_instalacao_cliente_id",
                table: "cliente_instalacao",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_instalacao_instalacao_id",
                table: "cliente_instalacao",
                column: "instalacao_id");

            migrationBuilder.CreateIndex(
                name: "uk_cliente_instalacao_uuid",
                table: "cliente_instalacao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_financiadora_financiadora_id",
                table: "colaborador_financiadora",
                column: "financiadora_id");

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_financiadora_usuario_id",
                table: "colaborador_financiadora",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uk_colaborador_financiadora_uuid",
                table: "colaborador_financiadora",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_integrador_integrador_id",
                table: "colaborador_integrador",
                column: "integrador_id");

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_integrador_usuario_id",
                table: "colaborador_integrador",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uk_colaborador_integrador_uuid",
                table: "colaborador_integrador",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comando_dispositivo_id",
                table: "comando",
                column: "dispositivo_id");

            migrationBuilder.CreateIndex(
                name: "IX_comando_tipo_comando_id",
                table: "comando",
                column: "tipo_comando_id");

            migrationBuilder.CreateIndex(
                name: "uk_comando_uuid",
                table: "comando",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_dispositivo_modelo_id",
                table: "dispositivo",
                column: "dispositivo_modelo_id");

            migrationBuilder.CreateIndex(
                name: "uk_dispositivo_uuid",
                table: "dispositivo",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_instalacao_dispositivo_id",
                table: "dispositivo_instalacao",
                column: "dispositivo_id");

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_instalacao_instalacao_id",
                table: "dispositivo_instalacao",
                column: "instalacao_id");

            migrationBuilder.CreateIndex(
                name: "uk_dispositivo_instalacao_uuid",
                table: "dispositivo_instalacao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_marca_tipo_dispositivo_id",
                table: "dispositivo_marca",
                column: "tipo_dispositivo_id");

            migrationBuilder.CreateIndex(
                name: "uk_dispositivo_marca_uuid",
                table: "dispositivo_marca",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_modelo_dispositivo_marca_id",
                table: "dispositivo_modelo",
                column: "dispositivo_marca_id");

            migrationBuilder.CreateIndex(
                name: "uk_dispositivo_modelo_uuid",
                table: "dispositivo_modelo",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_financiadora_uuid",
                table: "financiadora",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_financiadora_perfil_financiadora_id",
                table: "financiadora_perfil",
                column: "financiadora_id");

            migrationBuilder.CreateIndex(
                name: "IX_financiadora_perfil_perfil_id",
                table: "financiadora_perfil",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "uk_financiadora_perfil_uuid",
                table: "financiadora_perfil",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_financiamento_financiadora_id",
                table: "financiamento",
                column: "financiadora_id");

            migrationBuilder.CreateIndex(
                name: "IX_financiamento_instalacao_id",
                table: "financiamento",
                column: "instalacao_id");

            migrationBuilder.CreateIndex(
                name: "uk_financiamento_uuid",
                table: "financiamento",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_instalacao_instalacao_status_id",
                table: "instalacao",
                column: "instalacao_status_id");

            migrationBuilder.CreateIndex(
                name: "uk_instalacao_uuid",
                table: "instalacao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_instalacao_arquivo_instalacao_id",
                table: "instalacao_arquivo",
                column: "instalacao_id");

            migrationBuilder.CreateIndex(
                name: "IX_instalacao_arquivo_tipo_arquivo_id",
                table: "instalacao_arquivo",
                column: "tipo_arquivo_id");

            migrationBuilder.CreateIndex(
                name: "uk_instalacao_arquivo_uuid",
                table: "instalacao_arquivo",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_instalacao_integrador_instalacao_id",
                table: "instalacao_integrador",
                column: "instalacao_id");

            migrationBuilder.CreateIndex(
                name: "IX_instalacao_integrador_integrador_id",
                table: "instalacao_integrador",
                column: "integrador_id");

            migrationBuilder.CreateIndex(
                name: "uk_instalacao_integrador_uuid",
                table: "instalacao_integrador",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_instalacao_status_uuid",
                table: "instalacao_status",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_integrador_uuid",
                table: "integrador",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_integrador_perfil_integrador_id",
                table: "integrador_perfil",
                column: "integrador_id");

            migrationBuilder.CreateIndex(
                name: "IX_integrador_perfil_perfil_id",
                table: "integrador_perfil",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "uk_integrador_perfil_uuid",
                table: "integrador_perfil",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_log_perfil_usuario_uuid",
                table: "log_perfil_usuario",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_perfil_uuid",
                table: "perfil",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perfil_permissao_perfil_id",
                table: "perfil_permissao",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "IX_perfil_permissao_permissao_id",
                table: "perfil_permissao",
                column: "permissao_id");

            migrationBuilder.CreateIndex(
                name: "uk_perfil_permissao_uuid",
                table: "perfil_permissao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_permissao_uuid",
                table: "permissao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_solicitacao_intervencao_financiamento_id",
                table: "solicitacao_intervencao",
                column: "financiamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacao_intervencao_solicitacao_intervencao_status_id",
                table: "solicitacao_intervencao",
                column: "solicitacao_intervencao_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacao_intervencao_tipo_solicitacao_intervencao_id",
                table: "solicitacao_intervencao",
                column: "tipo_solicitacao_intervencao_id");

            migrationBuilder.CreateIndex(
                name: "uk_solicitacao_intervencao_uuid",
                table: "solicitacao_intervencao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_solicitacao_intervencao_log_solicitacao_intervencao_id",
                table: "solicitacao_intervencao_log",
                column: "solicitacao_intervencao_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacao_intervencao_log_status_anterior",
                table: "solicitacao_intervencao_log",
                column: "status_anterior");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacao_intervencao_log_status_corrente",
                table: "solicitacao_intervencao_log",
                column: "status_corrente");

            migrationBuilder.CreateIndex(
                name: "uk_solicitacao_intervencao_log_uuid",
                table: "solicitacao_intervencao_log",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_solicitacao_intervencao_status_uuid",
                table: "solicitacao_intervencao_status",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_solicitacao_reset_senha_uuid",
                table: "solicitacao_reset_senha",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_tipo_arquivo_uuid",
                table: "tipo_arquivo",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_tipo_comando_uuid",
                table: "tipo_comando",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_tipo_dispositivo_uuid",
                table: "tipo_dispositivo",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_tipo_documento_uuid",
                table: "tipo_documento",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_tipo_solicitacao_intervencao_uuid",
                table: "tipo_solicitacao_intervencao",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_id",
                table: "usuario",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "uk_usuario_uuid",
                table: "usuario",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_senha_usuario_id",
                table: "usuario_senha",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uk_usuario_senha_uuid",
                table: "usuario_senha",
                column: "uuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente_instalacao");

            migrationBuilder.DropTable(
                name: "colaborador_financiadora");

            migrationBuilder.DropTable(
                name: "colaborador_integrador");

            migrationBuilder.DropTable(
                name: "comando");

            migrationBuilder.DropTable(
                name: "dispositivo_instalacao");

            migrationBuilder.DropTable(
                name: "financiadora_perfil");

            migrationBuilder.DropTable(
                name: "instalacao_arquivo");

            migrationBuilder.DropTable(
                name: "instalacao_integrador");

            migrationBuilder.DropTable(
                name: "integrador_perfil");

            migrationBuilder.DropTable(
                name: "log_perfil_usuario");

            migrationBuilder.DropTable(
                name: "perfil_permissao");

            migrationBuilder.DropTable(
                name: "solicitacao_intervencao_log");

            migrationBuilder.DropTable(
                name: "solicitacao_reset_senha");

            migrationBuilder.DropTable(
                name: "usuario_senha");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "tipo_comando");

            migrationBuilder.DropTable(
                name: "dispositivo");

            migrationBuilder.DropTable(
                name: "tipo_arquivo");

            migrationBuilder.DropTable(
                name: "integrador");

            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "solicitacao_intervencao");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "dispositivo_modelo");

            migrationBuilder.DropTable(
                name: "financiamento");

            migrationBuilder.DropTable(
                name: "solicitacao_intervencao_status");

            migrationBuilder.DropTable(
                name: "tipo_solicitacao_intervencao");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "dispositivo_marca");

            migrationBuilder.DropTable(
                name: "financiadora");

            migrationBuilder.DropTable(
                name: "instalacao");

            migrationBuilder.DropTable(
                name: "tipo_dispositivo");

            migrationBuilder.DropTable(
                name: "instalacao_status");
        }
    }
}
