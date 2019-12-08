using Microsoft.EntityFrameworkCore.Migrations;

namespace ComeToTurkey.API.Migrations
{
    public partial class destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_Cities_CityId",
                table: "Destination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.RenameIndex(
                name: "IX_Destination_CityId",
                table: "Destinations",
                newName: "IX_Destinations_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_CityId",
                table: "Destination",
                newName: "IX_Destination_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_Cities_CityId",
                table: "Destination",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
