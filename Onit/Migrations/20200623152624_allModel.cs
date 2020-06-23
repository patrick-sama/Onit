using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onit.Migrations
{
    public partial class allModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codice = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carelli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricola = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carelli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codice = table.Column<string>(nullable: false),
                    Descrizione = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locazioni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codice = table.Column<string>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locazioni_Aree_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Aree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentiDeiCarelli",
                columns: table => new
                {
                    CarelloId = table.Column<int>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentiDeiCarelli", x => new { x.CarelloId, x.ComponenteId });
                    table.ForeignKey(
                        name: "FK_ComponentiDeiCarelli_Carelli_CarelloId",
                        column: x => x.CarelloId,
                        principalTable: "Carelli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentiDeiCarelli_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arrivi",
                columns: table => new
                {
                    CarelloId = table.Column<int>(nullable: false),
                    LocazioneId = table.Column<int>(nullable: false),
                    Descrizione = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivi", x => new { x.CarelloId, x.LocazioneId });
                    table.ForeignKey(
                        name: "FK_Arrivi_Carelli_CarelloId",
                        column: x => x.CarelloId,
                        principalTable: "Carelli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arrivi_Locazioni_LocazioneId",
                        column: x => x.LocazioneId,
                        principalTable: "Locazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrivi_LocazioneId",
                table: "Arrivi",
                column: "LocazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentiDeiCarelli_ComponenteId",
                table: "ComponentiDeiCarelli",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locazioni_AreaId",
                table: "Locazioni",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrivi");

            migrationBuilder.DropTable(
                name: "ComponentiDeiCarelli");

            migrationBuilder.DropTable(
                name: "Locazioni");

            migrationBuilder.DropTable(
                name: "Carelli");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Aree");
        }
    }
}
