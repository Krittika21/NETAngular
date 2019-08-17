using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAspNet.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_TestTypeMap_TestTypesID",
                table: "TestDetails");

            migrationBuilder.DropIndex(
                name: "IX_TestDetails_TestTypesID",
                table: "TestDetails");

            migrationBuilder.DropColumn(
                name: "TestTypesID",
                table: "TestDetails");

            migrationBuilder.CreateIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap",
                column: "TestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestTypeMap_TestDetails_TestId",
                table: "TestTypeMap",
                column: "TestId",
                principalTable: "TestDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTypeMap_TestDetails_TestId",
                table: "TestTypeMap");

            migrationBuilder.DropIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap");

            migrationBuilder.AddColumn<int>(
                name: "TestTypesID",
                table: "TestDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestDetails_TestTypesID",
                table: "TestDetails",
                column: "TestTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDetails_TestTypeMap_TestTypesID",
                table: "TestDetails",
                column: "TestTypesID",
                principalTable: "TestTypeMap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
