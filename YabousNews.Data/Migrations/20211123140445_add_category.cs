using Microsoft.EntityFrameworkCore.Migrations;

namespace YabousNews.Data.Migrations
{
    public partial class add_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryAttatcmantId",
                table: "Attachment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryAttatcmant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttatcmant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CategoryAttatcmantId",
                table: "Attachment",
                column: "CategoryAttatcmantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CategoryAttatcmant_CategoryAttatcmantId",
                table: "Attachment",
                column: "CategoryAttatcmantId",
                principalTable: "CategoryAttatcmant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CategoryAttatcmant_CategoryAttatcmantId",
                table: "Attachment");

            migrationBuilder.DropTable(
                name: "CategoryAttatcmant");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_CategoryAttatcmantId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CategoryAttatcmantId",
                table: "Attachment");
        }
    }
}
