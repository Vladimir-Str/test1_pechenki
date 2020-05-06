using Microsoft.EntityFrameworkCore.Migrations;

namespace test1_pechenki.Migrations
{
    public partial class emailpasswordaded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                nullable: false, defaultValue: "mail@mail.ru");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                nullable: false, defaultValue: "123456");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }
    }
}
