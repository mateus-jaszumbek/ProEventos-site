using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.Server.Migrations
{
    /// <inheritdoc />
    public partial class MinhaPrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbeventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataEvento = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Tema = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    QtdPessoas = table.Column<int>(type: "int", nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ImagemURL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbeventos", x => x.EventoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbeventos");
        }
    }
}
