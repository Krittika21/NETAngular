using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAspNet.Migrations
{
    public partial class UpdatedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "User",
                newName: "userType");

            migrationBuilder.AlterColumn<string>(
                name: "userType",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userType",
                table: "User",
                newName: "UserType");

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
