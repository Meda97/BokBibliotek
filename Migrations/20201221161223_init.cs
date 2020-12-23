using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BokBibliotek.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bok",
                columns: table => new
                {
                    BokId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<int>(nullable: false),
                    Boktitel = table.Column<string>(nullable: false),
                    Betyg = table.Column<string>(nullable: true),
                    Utgivningsår = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bok", x => x.BokId);
                });

            migrationBuilder.CreateTable(
                name: "Författare",
                columns: table => new
                {
                    FörfattareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Författarenamn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Författare", x => x.FörfattareId);
                });

            migrationBuilder.CreateTable(
                name: "Låntagare",
                columns: table => new
                {
                    LåntagareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(nullable: false),
                    Efternamn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Låntagare", x => x.LåntagareId);
                });

            migrationBuilder.CreateTable(
                name: "BokFörfattare",
                columns: table => new
                {
                    BokId = table.Column<int>(nullable: false),
                    FörfattareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BokFörfattare", x => new { x.BokId, x.FörfattareId });
                    table.ForeignKey(
                        name: "FK_BokFörfattare_Bok_BokId",
                        column: x => x.BokId,
                        principalTable: "Bok",
                        principalColumn: "BokId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BokFörfattare_Författare_FörfattareId",
                        column: x => x.FörfattareId,
                        principalTable: "Författare",
                        principalColumn: "FörfattareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boklån",
                columns: table => new
                {
                    BoklånId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LåntagareId = table.Column<int>(nullable: false),
                    BokId = table.Column<int>(nullable: false),
                    Utlånad = table.Column<bool>(nullable: false),
                    Lånedatum = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Returdatum = table.Column<DateTime>(nullable: false, defaultValueSql: "DATEADD(MONTH, 1, GETDATE())")   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boklån", x => x.BoklånId);
                    table.ForeignKey(
                        name: "FK_Boklån_Bok_BokId",
                        column: x => x.BokId,
                        principalTable: "Bok",
                        principalColumn: "BokId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boklån_Låntagare_LåntagareId",
                        column: x => x.LåntagareId,
                        principalTable: "Låntagare",
                        principalColumn: "LåntagareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BokFörfattare_FörfattareId",
                table: "BokFörfattare",
                column: "FörfattareId");

            migrationBuilder.CreateIndex(
                name: "IX_Boklån_BokId",
                table: "Boklån",
                column: "BokId");

            migrationBuilder.CreateIndex(
                name: "IX_Boklån_LåntagareId",
                table: "Boklån",
                column: "LåntagareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BokFörfattare");

            migrationBuilder.DropTable(
                name: "Boklån");

            migrationBuilder.DropTable(
                name: "Författare");

            migrationBuilder.DropTable(
                name: "Bok");

            migrationBuilder.DropTable(
                name: "Låntagare");
        }
    }
}
