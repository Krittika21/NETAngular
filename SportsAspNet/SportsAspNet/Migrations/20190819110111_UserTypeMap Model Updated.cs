using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAspNet.Migrations
{
    public partial class UserTypeMapModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTestMap_TestDetails_TestId",
                table: "UserTestMap");

            migrationBuilder.DropIndex(
                name: "IX_UserTestMap_TestId",
                table: "UserTestMap");

            migrationBuilder.AddColumn<int>(
                name: "TestDetailsListID",
                table: "UserTestMap",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTestMap_TestDetailsListID",
                table: "UserTestMap",
                column: "TestDetailsListID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTestMap_TestDetails_TestDetailsListID",
                table: "UserTestMap",
                column: "TestDetailsListID",
                principalTable: "TestDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTestMap_TestDetails_TestDetailsListID",
                table: "UserTestMap");

            migrationBuilder.DropIndex(
                name: "IX_UserTestMap_TestDetailsListID",
                table: "UserTestMap");

            migrationBuilder.DropColumn(
                name: "TestDetailsListID",
                table: "UserTestMap");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestMap_TestId",
                table: "UserTestMap",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTestMap_TestDetails_TestId",
                table: "UserTestMap",
                column: "TestId",
                principalTable: "TestDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
