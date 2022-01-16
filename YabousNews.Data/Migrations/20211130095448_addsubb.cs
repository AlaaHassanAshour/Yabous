using Microsoft.EntityFrameworkCore.Migrations;

namespace YabousNews.Data.Migrations
{
    public partial class addsubb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleSubId",
                table: "About",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_About_TitleSubId",
                table: "About",
                column: "TitleSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_About_TitleSub_TitleSubId",
                table: "About",
                column: "TitleSubId",
                principalTable: "TitleSub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_About_TitleSub_TitleSubId",
                table: "About");

            migrationBuilder.DropIndex(
                name: "IX_About_TitleSubId",
                table: "About");

            migrationBuilder.DropColumn(
                name: "TitleSubId",
                table: "About");
        }
    }
}
