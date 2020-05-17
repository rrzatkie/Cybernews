using Microsoft.EntityFrameworkCore.Migrations;

namespace Cybernews.DAL.Migrations
{
    public partial class ChangedKeywordsandArticleKeyword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Keywords");

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "ArticleKeywords",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ArticleKeywords");

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Keywords",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
