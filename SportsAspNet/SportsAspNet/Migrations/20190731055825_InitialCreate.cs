using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAspNet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TestTypeMap",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestTypeId = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypeMap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestTypeMap_TestDetails_TestId",
                        column: x => x.TestId,
                        principalTable: "TestDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestTypeMap_TestType_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTestMap",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CTDistance = table.Column<double>(nullable: true),
                    STTime = table.Column<double>(nullable: true),
                    FitnessRating = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestMap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTestMap_TestDetails_TestId",
                        column: x => x.TestId,
                        principalTable: "TestDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestMap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestTypeMap_TestId",
                table: "TestTypeMap",
                column: "TestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestTypeMap_TestTypeId",
                table: "TestTypeMap",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestMap_TestId",
                table: "UserTestMap",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestMap_UserId",
                table: "UserTestMap",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTypeMap");

            migrationBuilder.DropTable(
                name: "UserTestMap");

            migrationBuilder.DropTable(
                name: "TestType");

            migrationBuilder.DropTable(
                name: "TestDetails");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
