using Microsoft.EntityFrameworkCore.Migrations;

namespace Cybernews.DAL.Migrations
{
    public partial class ChangedKeywordsAddedArticlesSimilarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Keywords",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Articles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArticlesSimilarities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(nullable: false),
                    ArticleId_1 = table.Column<int>(nullable: false),
                    ArticleId_2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesSimilarities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlesSimilarities_Articles_ArticleId_1",
                        column: x => x.ArticleId_1,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticlesSimilarities_Articles_ArticleId_2",
                        column: x => x.ArticleId_2,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Url",
                table: "Articles",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesSimilarities_ArticleId_1_ArticleId_2",
                table: "ArticlesSimilarities",
                columns: new[] { "ArticleId_1", "ArticleId_2" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesSimilarities_ArticleId_2_ArticleId_1",
                table: "ArticlesSimilarities",
                columns: new[] { "ArticleId_2", "ArticleId_1" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlesSimilarities");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Url",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Keywords");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
