using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BokBibliotek.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Returdatum",
                table: "Boklån",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "DATEADD(MONTH, 1, GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Returdatum",
                table: "Boklån",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "DATEADD(MONTH, 1, GETDATE())",
                oldClrType: typeof(DateTime));
        }
    }
}
