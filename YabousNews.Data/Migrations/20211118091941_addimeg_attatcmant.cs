using Microsoft.EntityFrameworkCore.Migrations;

namespace YabousNews.Data.Migrations
{
    public partial class addimeg_attatcmant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Attachment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Attachment");
        }
    }
}
