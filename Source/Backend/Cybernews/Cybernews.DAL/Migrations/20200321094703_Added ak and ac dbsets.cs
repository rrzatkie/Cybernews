using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cybernews.DAL.Migrations
{
    public partial class Addedakandacdbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Articles_ArticleId",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Categories_CategoryId",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleKeyword_Articles_ArticleId",
                table: "ArticleKeyword");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleKeyword_Keywords_KeywordId",
                table: "ArticleKeyword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleKeyword",
                table: "ArticleKeyword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory");

            migrationBuilder.RenameTable(
                name: "ArticleKeyword",
                newName: "ArticleKeywords");

            migrationBuilder.RenameTable(
                name: "ArticleCategory",
                newName: "ArticleCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleKeyword_KeywordId",
                table: "ArticleKeywords",
                newName: "IX_ArticleKeywords_KeywordId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_CategoryId",
                table: "ArticleCategories",
                newName: "IX_ArticleCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleKeywords",
                table: "ArticleKeywords",
                columns: new[] { "ArticleId", "KeywordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories",
                columns: new[] { "ArticleId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 17, 6, 28, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 12, 16, 43, 53, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 11, 10, 4, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 2, 0, 54, 23, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 18, 15, 34, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 26, 5, 31, 51, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 17, 3, 47, 25, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 18, 13, 35, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 26, 6, 31, 26, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 6, 29, 7, 33, 41, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 9, 8, 19, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 22, 8, 2, 39, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 15, 16, 6, 5, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 28, 0, 58, 27, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 14, 1, 48, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 4, 3, 53, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 16, 16, 22, 32, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 3, 0, 7, 48, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 28, 6, 23, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 14, 13, 29, 30, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 3, 2, 47, 52, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 6, 13, 41, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 16, 8, 2, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 15, 21, 12, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 10, 4, 40, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 1, 1, 35, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 6, 30, 10, 21, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 3, 0, 40, 51, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 31, 20, 33, 41, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 12, 18, 5, 19, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 2, 19, 4, 20, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 12, 19, 58, 20, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 6, 14, 52, 27, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 10, 21, 10, 28, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 15, 8, 59, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 2, 9, 44, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 9, 17, 16, 46, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 6, 29, 21, 51, 24, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 16, 21, 0, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 1, 3, 16, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 26, 23, 6, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 10, 17, 48, 26, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 23, 10, 11, 14, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 7, 21, 41, 52, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 2, 5, 8, 48, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 12, 2, 17, 17, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 6, 5, 35, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 21, 18, 28, 22, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 5, 3, 10, 31, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 8, 22, 54, 29, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 6, 9, 52, 52, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 12, 10, 18, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 21, 14, 12, 35, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 17, 16, 1, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 18, 10, 38, 15, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 20, 7, 44, 45, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 7, 11, 5, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 17, 23, 37, 13, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 7, 15, 45, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 9, 0, 45, 27, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 24, 8, 44, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 14, 23, 58, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 2, 19, 36, 7, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 23, 12, 1, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 21, 6, 41, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 6, 30, 14, 57, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 20, 6, 6, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 6, 8, 7, 24, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 24, 2, 30, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 6, 18, 48, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 2, 11, 32, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 25, 6, 12, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 20, 20, 35, 32, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 26, 13, 52, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 20, 22, 18, 14, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 21, 10, 25, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 3, 9, 8, 19, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 4, 1, 49, 51, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 19, 23, 16, 53, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 8, 20, 8, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 31, 6, 43, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 4, 9, 38, 42, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 19, 2, 21, 45, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 27, 18, 22, 47, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 7, 0, 55, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 9, 10, 52, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 22, 1, 7, 2, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 28, 8, 43, 46, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 10, 5, 17, 15, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 6, 18, 48, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 17, 3, 51, 51, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 19, 4, 12, 24, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 17, 16, 24, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 7, 9, 7, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 13, 23, 50, 19, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 16, 9, 31, 37, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 12, 16, 40, 10, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 14, 17, 40, 49, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 1, 6, 28, 16, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 8, 18, 25, 40, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 18, 18, 10, 28, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 30, 4, 34, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 23, 3, 9, 10, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 30, 15, 5, 51, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 26, 2, 51, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 6, 28, 0, 15, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 31, 10, 51, 19, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 7, 1, 34, 15, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 18, 14, 39, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 29, 22, 33, 22, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 15, 13, 18, 52, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 20, 18, 33, 1, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 17, 16, 2, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 18, 19, 14, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 18, 13, 49, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 9, 20, 54, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 6, 30, 19, 30, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 11, 21, 49, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 23, 9, 5, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 18, 0, 16, 24, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 15, 14, 47, 45, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 16, 0, 36, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 15, 11, 16, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 6, 20, 45, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 14, 18, 57, 5, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 5, 7, 22, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 14, 23, 50, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 27, 17, 47, 46, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 2, 7, 8, 5, 7, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 21, 15, 26, 40, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 16, 12, 14, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 20, 18, 56, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 5, 12, 18, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 7, 2, 0, 35, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 9, 15, 16, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 13, 13, 17, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 19, 14, 54, 15, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 25, 12, 49, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 6, 21, 26, 21, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 9, 23, 11, 4, 2, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 8, 15, 28, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 17, 14, 59, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 5, 10, 28, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 1, 18, 14, 12, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 10, 4, 1, 3, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 11, 9, 22, 29, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 10, 16, 1, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2020, 3, 12, 5, 39, 38, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 8, 15, 12, 33, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 21, 9, 47, 3, 185, DateTimeKind.Utc).AddTicks(4214), new DateTime(2019, 12, 7, 11, 16, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleKeywords_Articles_ArticleId",
                table: "ArticleKeywords",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleKeywords_Keywords_KeywordId",
                table: "ArticleKeywords",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryId",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleKeywords_Articles_ArticleId",
                table: "ArticleKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleKeywords_Keywords_KeywordId",
                table: "ArticleKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleKeywords",
                table: "ArticleKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "ArticleKeywords",
                newName: "ArticleKeyword");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "ArticleCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleKeywords_KeywordId",
                table: "ArticleKeyword",
                newName: "IX_ArticleKeyword_KeywordId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleKeyword",
                table: "ArticleKeyword",
                columns: new[] { "ArticleId", "KeywordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory",
                columns: new[] { "ArticleId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 16, 12, 56, 29, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 12, 3, 29, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 10, 20, 55, 14, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 2, 0, 36, 12, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 18, 12, 6, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 25, 13, 19, 22, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 17, 0, 25, 14, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 18, 12, 10, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 25, 20, 25, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 6, 29, 7, 26, 22, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 9, 5, 27, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 21, 18, 9, 23, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 15, 2, 39, 25, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 27, 12, 46, 7, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 13, 16, 31, 38, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 3, 17, 16, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 16, 2, 51, 49, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 2, 13, 35, 20, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 27, 14, 2, 32, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 14, 6, 14, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 2, 10, 11, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 6, 4, 54, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 15, 18, 32, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 15, 17, 55, 51, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 10, 1, 46, 32, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 31, 13, 7, 19, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 6, 30, 10, 9, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 2, 10, 0, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 31, 18, 16, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 12, 17, 4, 24, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 2, 12, 36, 5, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 12, 8, 46, 40, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 6, 14, 16, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 10, 8, 2, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 14, 17, 29, 49, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 1, 17, 11, 28, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 9, 2, 10, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 6, 29, 21, 41, 42, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 16, 11, 32, 11, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 31, 22, 54, 37, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 26, 15, 1, 29, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 10, 4, 41, 25, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 23, 2, 20, 40, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 7, 6, 42, 29, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 2, 0, 42, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 11, 9, 5, 30, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 6, 2, 56, 32, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 21, 10, 44, 25, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 4, 22, 32, 38, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 8, 20, 5, 1, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 6, 3, 10, 12, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 12, 1, 8, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 21, 4, 25, 39, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 17, 10, 33, 12, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 18, 1, 3, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 20, 0, 6, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 7, 2, 15, 26, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 17, 12, 5, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 7, 8, 58, 16, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 8, 13, 48, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 24, 4, 53, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 14, 8, 30, 37, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 2, 19, 14, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 23, 8, 14, 5, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 20, 16, 52, 53, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 6, 30, 14, 44, 37, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 19, 22, 29, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 6, 3, 24, 42, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 23, 12, 30, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 6, 10, 0, 17, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 2, 9, 8, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 24, 18, 10, 54, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 20, 16, 58, 35, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 26, 1, 45, 38, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 20, 10, 34, 15, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 21, 2, 42, 31, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 2, 18, 26, 59, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 3, 17, 12, 48, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 19, 19, 43, 29, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 8, 17, 19, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 31, 4, 28, 20, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 4, 9, 11, 5, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 18, 16, 44, 47, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 27, 16, 21, 58, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 6, 22, 13, 22, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 9, 5, 57, 48, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 21, 23, 29, 1, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 28, 0, 33, 31, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 9, 14, 8, 38, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 6, 18, 11, 48, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 17, 2, 33, 20, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 18, 12, 28, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 17, 2, 49, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 7, 4, 20, 42, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 13, 22, 44, 27, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 16, 6, 12, 28, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 12, 9, 32, 25, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 14, 0, 18, 29, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 1, 6, 13, 9, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 8, 15, 36, 58, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 18, 12, 38, 13, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 29, 18, 13, 40, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 23, 1, 26, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 30, 4, 42, 52, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 26, 0, 57, 39, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 6, 28, 0, 13, 27, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 31, 6, 32, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 6, 12, 41, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 17, 22, 57, 6, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 29, 12, 13, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 15, 12, 6, 46, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 20, 2, 42, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 17, 14, 42, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 18, 11, 42, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 18, 4, 15, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 9, 18, 1, 27, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 6, 30, 19, 17, 39, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 11, 16, 45, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 22, 17, 4, 48, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 17, 18, 47, 8, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 15, 1, 21, 17, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 15, 11, 8, 50, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 15, 3, 57, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 6, 16, 0, 17, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 14, 1, 34, 33, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 4, 22, 40, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 14, 10, 26, 13, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 27, 3, 32, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 2, 6, 17, 8, 1, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 21, 9, 42, 55, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 16, 8, 54, 32, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 20, 5, 9, 49, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 5, 9, 42, 28, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 7, 2, 0, 16, 57, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 9, 10, 20, 17, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 12, 23, 59, 21, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 19, 9, 18, 34, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 25, 4, 50, 46, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 6, 12, 38, 4, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 9, 23, 5, 13, 1, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 8, 6, 33, 42, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 17, 7, 32, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 4, 23, 45, 56, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 1, 18, 0, 34, 30, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 10, 3, 18, 30, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 11, 9, 13, 29, 17, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 10, 13, 5, 40, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2020, 3, 11, 12, 27, 16, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 8, 15, 9, 17, 26, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "DateAdded", "DateCreated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 58, 6, 838, DateTimeKind.Utc).AddTicks(891), new DateTime(2019, 12, 7, 0, 26, 38, 0, DateTimeKind.Utc) });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Articles_ArticleId",
                table: "ArticleCategory",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Categories_CategoryId",
                table: "ArticleCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleKeyword_Articles_ArticleId",
                table: "ArticleKeyword",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleKeyword_Keywords_KeywordId",
                table: "ArticleKeyword",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
