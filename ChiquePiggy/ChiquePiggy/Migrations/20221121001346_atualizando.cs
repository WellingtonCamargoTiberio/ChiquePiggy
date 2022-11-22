using Microsoft.EntityFrameworkCore.Migrations;

namespace ChiquePiggy.Migrations
{
    public partial class atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResgatePremio",
                table: "Transacao",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResgatePremio",
                table: "Transacao");
        }
    }
}
