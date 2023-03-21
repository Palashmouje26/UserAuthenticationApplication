using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAuthenticationApplication.DomainModel.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_UserRegistration_UserRagistrationUserId",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_UserRagistrationUserId",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "UserRagistrationUserId",
                table: "Login");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Login",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserId",
                table: "Login",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_UserRegistration_UserId",
                table: "Login",
                column: "UserId",
                principalTable: "UserRegistration",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_UserRegistration_UserId",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_UserId",
                table: "Login");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Login",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserRagistrationUserId",
                table: "Login",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserRagistrationUserId",
                table: "Login",
                column: "UserRagistrationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_UserRegistration_UserRagistrationUserId",
                table: "Login",
                column: "UserRagistrationUserId",
                principalTable: "UserRegistration",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
