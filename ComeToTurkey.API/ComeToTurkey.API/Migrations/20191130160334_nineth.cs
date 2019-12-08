using Microsoft.EntityFrameworkCore.Migrations;

namespace ComeToTurkey.API.Migrations
{
    public partial class nineth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "Id");
        }
    }
}
