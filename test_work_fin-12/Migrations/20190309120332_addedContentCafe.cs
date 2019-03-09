using Microsoft.EntityFrameworkCore.Migrations;

namespace test_work_fin_12.Migrations
{
    public partial class addedContentCafe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafeis_AspNetUsers_UserId",
                table: "Cafeis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafeis",
                table: "Cafeis");

            migrationBuilder.RenameTable(
                name: "Cafeis",
                newName: "Cafes");

            migrationBuilder.RenameIndex(
                name: "IX_Cafeis_UserId",
                table: "Cafes",
                newName: "IX_Cafes_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Cafes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafes",
                table: "Cafes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_AspNetUsers_UserId",
                table: "Cafes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_AspNetUsers_UserId",
                table: "Cafes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafes",
                table: "Cafes");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Cafes");

            migrationBuilder.RenameTable(
                name: "Cafes",
                newName: "Cafeis");

            migrationBuilder.RenameIndex(
                name: "IX_Cafes_UserId",
                table: "Cafeis",
                newName: "IX_Cafeis_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafeis",
                table: "Cafeis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafeis_AspNetUsers_UserId",
                table: "Cafeis",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
