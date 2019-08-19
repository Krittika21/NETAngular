using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAspNet.Migrations
{
    public partial class ModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap");

            migrationBuilder.CreateIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap");

            migrationBuilder.CreateIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap",
                column: "TestId",
                unique: true);
        }
    }
}
