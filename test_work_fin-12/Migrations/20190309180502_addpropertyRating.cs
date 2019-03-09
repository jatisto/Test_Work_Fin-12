using Microsoft.EntityFrameworkCore.Migrations;

namespace test_work_fin_12.Migrations
{
    public partial class addpropertyRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Cafes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Cafes");
        }
    }
}
