using Microsoft.EntityFrameworkCore.Migrations;

namespace BLL.Migrations
{
    public partial class HasCard_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasCard",
                table: "Students",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCard",
                table: "Students");
        }
    }
}
