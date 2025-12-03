using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace connectWeek.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONQUISTA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Criterio = table.Column<string>(type: "text", nullable: true),
                    PontosBonus = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONQUISTA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FUNCAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PathImagem = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    EmailVerificado = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONQUISTA_USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConquistaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConquistadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Visualizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONQUISTA_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONQUISTA_USUARIO_CONQUISTA_ConquistaId",
                        column: x => x.ConquistaId,
                        principalTable: "CONQUISTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONQUISTA_USUARIO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESAFIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    PathImagem = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantidadeQuestoes = table.Column<int>(type: "integer", nullable: false),
                    PercentualMinimo = table.Column<decimal>(type: "numeric", nullable: false),
                    TempoMaximoMin = table.Column<int>(type: "integer", nullable: false),
                    MaxTentativas = table.Column<int>(type: "integer", nullable: false),
                    MostrarResposta = table.Column<bool>(type: "boolean", nullable: false),
                    EmbaralharQuestoes = table.Column<bool>(type: "boolean", nullable: false),
                    Dificuldade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CriadoPor = table.Column<Guid>(type: "uuid", nullable: false),
                    Publicado = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESAFIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DESAFIO_USUARIO_CriadoPor",
                        column: x => x.CriadoPor,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EVENTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    PathImagem = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Local = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LinkTransmissao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CapacidadeMaxima = table.Column<int>(type: "integer", nullable: false),
                    InscricaoAberta = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uuid", nullable: false),
                    Publicado = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EVENTO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QUESTAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Enunciado = table.Column<string>(type: "text", nullable: false),
                    PathImagem = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TipoQuestao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Peso = table.Column<decimal>(type: "numeric", nullable: false),
                    Dificuldade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Explicacao = table.Column<string>(type: "text", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uuid", nullable: false),
                    Publicado = table.Column<bool>(type: "boolean", nullable: false),
                    VezesUtilizada = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUESTAO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_AUTENTICACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Provider = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ProviderSub = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_AUTENTICACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIO_AUTENTICACAO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_FUNCAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    FuncaoId = table.Column<int>(type: "integer", nullable: false),
                    AtribuidoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtribuidoPor = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_FUNCAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIO_FUNCAO_FUNCAO_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "FUNCAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_FUNCAO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESAFIO_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DesafioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESAFIO_CATEGORIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DESAFIO_CATEGORIA_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DESAFIO_CATEGORIA_DESAFIO_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "DESAFIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXECUCAO_DESAFIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    DesafioId = table.Column<Guid>(type: "uuid", nullable: false),
                    IniciadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinalizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pontuacao = table.Column<decimal>(type: "numeric", nullable: false),
                    Percentual = table.Column<decimal>(type: "numeric", nullable: false),
                    Aprovado = table.Column<bool>(type: "boolean", nullable: false),
                    Tentativa = table.Column<int>(type: "integer", nullable: false),
                    TempoGasto = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXECUCAO_DESAFIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXECUCAO_DESAFIO_DESAFIO_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "DESAFIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXECUCAO_DESAFIO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EVENTO_DESAFIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DesafioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    Obrigatorio = table.Column<bool>(type: "boolean", nullable: false),
                    Liberacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTO_DESAFIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EVENTO_DESAFIO_DESAFIO_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "DESAFIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTO_DESAFIO_EVENTO_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EVENTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALTERNATIVA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    PathImagem = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Correta = table.Column<bool>(type: "boolean", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALTERNATIVA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALTERNATIVA_QUESTAO_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "QUESTAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DESAFIO_QUESTAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DesafioId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESAFIO_QUESTAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DESAFIO_QUESTAO_DESAFIO_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "DESAFIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DESAFIO_QUESTAO_QUESTAO_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "QUESTAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QUESTAO_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTAO_CATEGORIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUESTAO_CATEGORIA_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QUESTAO_CATEGORIA_QUESTAO_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "QUESTAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESPOSTA_QUESTAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExecucaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlternativaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Correta = table.Column<bool>(type: "boolean", nullable: false),
                    Pontuacao = table.Column<decimal>(type: "numeric", nullable: false),
                    TempoResposta = table.Column<int>(type: "integer", nullable: false),
                    RespondidoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPOSTA_QUESTAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_QUESTAO_ALTERNATIVA_AlternativaId",
                        column: x => x.AlternativaId,
                        principalTable: "ALTERNATIVA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_QUESTAO_EXECUCAO_DESAFIO_ExecucaoId",
                        column: x => x.ExecucaoId,
                        principalTable: "EXECUCAO_DESAFIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_QUESTAO_QUESTAO_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "QUESTAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALTERNATIVA_QuestaoId",
                table: "ALTERNATIVA",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_Nome",
                table: "CATEGORIA",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONQUISTA_Nome",
                table: "CONQUISTA",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONQUISTA_USUARIO_ConquistaId",
                table: "CONQUISTA_USUARIO",
                column: "ConquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_CONQUISTA_USUARIO_UsuarioId",
                table: "CONQUISTA_USUARIO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_CriadoPor",
                table: "DESAFIO",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_CATEGORIA_CategoriaId",
                table: "DESAFIO_CATEGORIA",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_CATEGORIA_DesafioId",
                table: "DESAFIO_CATEGORIA",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_QUESTAO_DesafioId",
                table: "DESAFIO_QUESTAO",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_QUESTAO_QuestaoId",
                table: "DESAFIO_QUESTAO",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_UsuarioId",
                table: "EVENTO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_DESAFIO_DesafioId",
                table: "EVENTO_DESAFIO",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_DESAFIO_EventoId",
                table: "EVENTO_DESAFIO",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_EXECUCAO_DESAFIO_DesafioId",
                table: "EXECUCAO_DESAFIO",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_EXECUCAO_DESAFIO_UsuarioId",
                table: "EXECUCAO_DESAFIO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCAO_Nome",
                table: "FUNCAO",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QUESTAO_UsuarioId",
                table: "QUESTAO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTAO_CATEGORIA_CategoriaId",
                table: "QUESTAO_CATEGORIA",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTAO_CATEGORIA_QuestaoId",
                table: "QUESTAO_CATEGORIA",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_QUESTAO_AlternativaId",
                table: "RESPOSTA_QUESTAO",
                column: "AlternativaId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_QUESTAO_ExecucaoId",
                table: "RESPOSTA_QUESTAO",
                column: "ExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_QUESTAO_QuestaoId",
                table: "RESPOSTA_QUESTAO",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Email",
                table: "USUARIO",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Username",
                table: "USUARIO",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_AUTENTICACAO_ProviderSub",
                table: "USUARIO_AUTENTICACAO",
                column: "ProviderSub",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_AUTENTICACAO_UsuarioId",
                table: "USUARIO_AUTENTICACAO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_FUNCAO_FuncaoId",
                table: "USUARIO_FUNCAO",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_FUNCAO_UsuarioId",
                table: "USUARIO_FUNCAO",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONQUISTA_USUARIO");

            migrationBuilder.DropTable(
                name: "DESAFIO_CATEGORIA");

            migrationBuilder.DropTable(
                name: "DESAFIO_QUESTAO");

            migrationBuilder.DropTable(
                name: "EVENTO_DESAFIO");

            migrationBuilder.DropTable(
                name: "QUESTAO_CATEGORIA");

            migrationBuilder.DropTable(
                name: "RESPOSTA_QUESTAO");

            migrationBuilder.DropTable(
                name: "USUARIO_AUTENTICACAO");

            migrationBuilder.DropTable(
                name: "USUARIO_FUNCAO");

            migrationBuilder.DropTable(
                name: "CONQUISTA");

            migrationBuilder.DropTable(
                name: "EVENTO");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "ALTERNATIVA");

            migrationBuilder.DropTable(
                name: "EXECUCAO_DESAFIO");

            migrationBuilder.DropTable(
                name: "FUNCAO");

            migrationBuilder.DropTable(
                name: "QUESTAO");

            migrationBuilder.DropTable(
                name: "DESAFIO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
