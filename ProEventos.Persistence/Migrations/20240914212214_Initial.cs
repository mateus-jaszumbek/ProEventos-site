using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbeventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataEvento = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: true),
                    Tema = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    QtdPessoas = table.Column<int>(type: "int", nullable: false),
                    ImagemURL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbeventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbpalestrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiniCurriculo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImagemURL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpalestrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblotes_tbeventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "tbeventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbpalestrantesEventos",
                columns: table => new
                {
                    PalestranteId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpalestrantesEventos", x => new { x.EventoId, x.PalestranteId });
                    table.ForeignKey(
                        name: "FK_tbpalestrantesEventos_tbeventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "tbeventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbpalestrantesEventos_tbpalestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "tbpalestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbredesSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    PalestranteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbredesSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbredesSociais_tbeventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "tbeventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbredesSociais_tbpalestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "tbpalestrantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblotes_EventoId",
                table: "tblotes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbpalestrantesEventos_PalestranteId",
                table: "tbpalestrantesEventos",
                column: "PalestranteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbredesSociais_EventoId",
                table: "tbredesSociais",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbredesSociais_PalestranteId",
                table: "tbredesSociais",
                column: "PalestranteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblotes");

            migrationBuilder.DropTable(
                name: "tbpalestrantesEventos");

            migrationBuilder.DropTable(
                name: "tbredesSociais");

            migrationBuilder.DropTable(
                name: "tbeventos");

            migrationBuilder.DropTable(
                name: "tbpalestrantes");
        }
    }
}
