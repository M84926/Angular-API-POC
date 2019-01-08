using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularPOC.Data.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CityMaster_CityId1",
                table: "UserMaster");

            migrationBuilder.DropIndex(
                name: "IX_UserMaster_CityId1",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "UserMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserMaster",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_CityId",
                table: "UserMaster",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CityMaster_CityId",
                table: "UserMaster",
                column: "CityId",
                principalTable: "CityMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CityMaster_CityId",
                table: "UserMaster");

            migrationBuilder.DropIndex(
                name: "IX_UserMaster_CityId",
                table: "UserMaster");

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "UserMaster",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_CityId1",
                table: "UserMaster",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CityMaster_CityId1",
                table: "UserMaster",
                column: "CityId1",
                principalTable: "CityMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
