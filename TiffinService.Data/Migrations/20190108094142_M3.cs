using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularPOC.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CityMaster_CityId",
                table: "UserMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserMaster",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CityMaster_CityId",
                table: "UserMaster",
                column: "CityId",
                principalTable: "CityMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CityMaster_CityId",
                table: "UserMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserMaster",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CityMaster_CityId",
                table: "UserMaster",
                column: "CityId",
                principalTable: "CityMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
