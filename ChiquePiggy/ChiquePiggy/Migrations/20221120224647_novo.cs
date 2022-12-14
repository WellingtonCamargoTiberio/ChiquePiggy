using Microsoft.EntityFrameworkCore.Migrations;

namespace ChiquePiggy.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Historico",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Historico",
                table: "Historico",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Historico",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Historico");
        }
    }
}
