using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kladionica.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaCode = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Sportovi",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportovi", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Tiketi",
                columns: table => new
                {
                    TikedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiketi", x => x.TikedId);
                });

            migrationBuilder.CreateTable(
                name: "Lige",
                columns: table => new
                {
                    LigaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pol = table.Column<string>(type: "nvarchar(1)", nullable: false, defaultValue: "M"),
                    LigaCode = table.Column<byte>(type: "tinyint", nullable: false),
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lige", x => x.LigaId);
                    table.ForeignKey(
                        name: "FK_Lige_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klubovi",
                columns: table => new
                {
                    KlubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(1)", nullable: false, defaultValue: "M"),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klubovi", x => x.KlubId);
                    table.ForeignKey(
                        name: "FK_Klubovi_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klubovi_Sportovi_SportId",
                        column: x => x.SportId,
                        principalTable: "Sportovi",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Singlovi",
                columns: table => new
                {
                    SinglId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferentnaKvota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kvota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dobitan = table.Column<bool>(type: "bit", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TiketId = table.Column<int>(type: "int", nullable: true),
                    ParId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singlovi", x => x.SinglId);
                    table.ForeignKey(
                        name: "FK_Singlovi_Tiketi_TiketId",
                        column: x => x.TiketId,
                        principalTable: "Tiketi",
                        principalColumn: "TikedId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parovi",
                columns: table => new
                {
                    ParId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LigaId = table.Column<int>(type: "int", nullable: false),
                    SinglId = table.Column<int>(type: "int", nullable: false),
                    KlubPrviId = table.Column<int>(type: "int", nullable: false),
                    KlubDrugiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parovi", x => x.ParId);
                    table.ForeignKey(
                        name: "FK_Parovi_Klubovi_KlubDrugiId",
                        column: x => x.KlubDrugiId,
                        principalTable: "Klubovi",
                        principalColumn: "KlubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parovi_Klubovi_KlubPrviId",
                        column: x => x.KlubPrviId,
                        principalTable: "Klubovi",
                        principalColumn: "KlubId");
                    table.ForeignKey(
                        name: "FK_Parovi_Lige_LigaId",
                        column: x => x.LigaId,
                        principalTable: "Lige",
                        principalColumn: "LigaId");
                    table.ForeignKey(
                        name: "FK_Parovi_Singlovi_SinglId",
                        column: x => x.SinglId,
                        principalTable: "Singlovi",
                        principalColumn: "SinglId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drzave_DrzavaCode",
                table: "Drzave",
                column: "DrzavaCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klubovi_DrzavaId",
                table: "Klubovi",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klubovi_SportId",
                table: "Klubovi",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Lige_DrzavaId",
                table: "Lige",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parovi_KlubDrugiId",
                table: "Parovi",
                column: "KlubDrugiId");

            migrationBuilder.CreateIndex(
                name: "IX_Parovi_KlubPrviId",
                table: "Parovi",
                column: "KlubPrviId");

            migrationBuilder.CreateIndex(
                name: "IX_Parovi_LigaId",
                table: "Parovi",
                column: "LigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parovi_SinglId",
                table: "Parovi",
                column: "SinglId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Singlovi_TiketId",
                table: "Singlovi",
                column: "TiketId");

            migrationBuilder.CreateIndex(
                name: "IX_Sportovi_SportCode",
                table: "Sportovi",
                column: "SportCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parovi");

            migrationBuilder.DropTable(
                name: "Klubovi");

            migrationBuilder.DropTable(
                name: "Lige");

            migrationBuilder.DropTable(
                name: "Singlovi");

            migrationBuilder.DropTable(
                name: "Sportovi");

            migrationBuilder.DropTable(
                name: "Drzave");

            migrationBuilder.DropTable(
                name: "Tiketi");
        }
    }
}
