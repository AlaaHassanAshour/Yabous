using Microsoft.EntityFrameworkCore.Migrations;

namespace YabousNews.Data.Migrations
{
    public partial class about : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubMenu",
                table: "About",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubMenu",
                table: "About");
        }
    }
}
