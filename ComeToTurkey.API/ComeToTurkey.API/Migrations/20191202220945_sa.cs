using Microsoft.EntityFrameworkCore.Migrations;

namespace ComeToTurkey.API.Migrations
{
    public partial class sa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Cities_CityId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Cities_CityId",
                table: "Blogs",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Cities_CityId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Cities_CityId",
                table: "Blogs",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
