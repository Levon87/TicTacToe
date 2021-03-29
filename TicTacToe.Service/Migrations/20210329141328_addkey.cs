using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacToe.Service.Migrations
{
    public partial class addkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GameResults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameResults",
                table: "GameResults",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameResults",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GameResults");
        }
    }
}
