using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAuthenticationApplication.DomainModel.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    UserRagistrationUserId = table.Column<int>(nullable: true),
                    LoginHistory = table.Column<DateTime>(nullable: false),
                    IsValidate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Login_UserRegistration_UserRagistrationUserId",
                        column: x => x.UserRagistrationUserId,
                        principalTable: "UserRegistration",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserRagistrationUserId",
                table: "Login",
                column: "UserRagistrationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
