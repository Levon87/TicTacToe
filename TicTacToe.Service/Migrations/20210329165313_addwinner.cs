using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacToe.Service.Migrations
{
    public partial class addwinner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "GameResults",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "GameResults");
        }
    }
}
