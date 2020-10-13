using Microsoft.EntityFrameworkCore.Migrations;

namespace BLL.Migrations
{
    public partial class Fix_FK_Take1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Students_CardId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CadId",
                table: "Cards",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "CadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_StudentId",
                table: "Cards",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Students_StudentId",
                table: "Cards",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Students_StudentId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_StudentId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CadId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Students_CardId",
                table: "Cards",
                column: "CardId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
