using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cybernews.DAL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Articles",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "DateAdded", "DateCreated", "ImageUrl", "NoOfLikes", "Slug", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 16, 12, 43, 15, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/1/900/500.jpg", 907, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas1", "Random title Lorem ipsum aaAA BBbb asdasdas(1)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas1" },
                    { 97, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 12, 9, 27, 3, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/97/900/500.jpg", 697, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas97", "Random title Lorem ipsum aaAA BBbb asdasdas(97)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas97" },
                    { 98, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 14, 0, 5, 23, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/98/900/500.jpg", 369, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas98", "Random title Lorem ipsum aaAA BBbb asdasdas(98)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas98" },
                    { 99, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 1, 6, 12, 58, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/99/900/500.jpg", 332, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas99", "Random title Lorem ipsum aaAA BBbb asdasdas(99)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas99" },
                    { 100, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 8, 15, 34, 50, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/100/900/500.jpg", 867, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(100)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 101, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 18, 12, 34, 3, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/101/900/500.jpg", 728, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(101)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 102, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 29, 18, 5, 52, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/102/900/500.jpg", 396, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(102)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 103, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 23, 1, 25, 33, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/103/900/500.jpg", 609, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(103)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 104, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 30, 4, 35, 3, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/104/900/500.jpg", 311, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(104)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 105, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 26, 0, 56, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/105/900/500.jpg", 307, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(105)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 106, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 6, 28, 0, 13, 26, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/106/900/500.jpg", 29, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(106)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 107, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 31, 6, 28, 51, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/107/900/500.jpg", 562, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(107)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 108, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 6, 12, 32, 12, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/108/900/500.jpg", 645, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(108)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 109, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 17, 22, 45, 15, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/109/900/500.jpg", 622, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(109)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 110, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 29, 12, 5, 20, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/110/900/500.jpg", 202, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(110)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 111, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 15, 12, 5, 51, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/111/900/500.jpg", 250, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(111)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 96, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 16, 6, 9, 58, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/96/900/500.jpg", 508, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas96", "Random title Lorem ipsum aaAA BBbb asdasdas(96)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas96" },
                    { 112, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 20, 2, 30, 21, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/112/900/500.jpg", 738, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(112)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 95, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 13, 22, 43, 37, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/95/900/500.jpg", 412, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas95", "Random title Lorem ipsum aaAA BBbb asdasdas(95)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas95" },
                    { 93, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 17, 2, 39, 36, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/93/900/500.jpg", 337, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas93", "Random title Lorem ipsum aaAA BBbb asdasdas(93)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas93" },
                    { 78, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 3, 17, 6, 18, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/78/900/500.jpg", 851, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas78", "Random title Lorem ipsum aaAA BBbb asdasdas(78)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas78" },
                    { 79, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 19, 19, 40, 48, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/79/900/500.jpg", 277, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas79", "Random title Lorem ipsum aaAA BBbb asdasdas(79)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas79" },
                    { 80, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 8, 17, 17, 49, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/80/900/500.jpg", 795, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas80", "Random title Lorem ipsum aaAA BBbb asdasdas(80)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas80" },
                    { 81, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 31, 4, 26, 39, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/81/900/500.jpg", 764, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas81", "Random title Lorem ipsum aaAA BBbb asdasdas(81)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas81" },
                    { 82, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 4, 9, 10, 45, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/82/900/500.jpg", 342, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas82", "Random title Lorem ipsum aaAA BBbb asdasdas(82)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas82" },
                    { 83, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 18, 16, 37, 31, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/83/900/500.jpg", 335, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas83", "Random title Lorem ipsum aaAA BBbb asdasdas(83)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas83" },
                    { 84, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 27, 16, 20, 27, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/84/900/500.jpg", 951, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas84", "Random title Lorem ipsum aaAA BBbb asdasdas(84)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas84" },
                    { 85, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 6, 22, 11, 20, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/85/900/500.jpg", 261, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas85", "Random title Lorem ipsum aaAA BBbb asdasdas(85)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas85" },
                    { 86, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 9, 5, 54, 5, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/86/900/500.jpg", 823, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas86", "Random title Lorem ipsum aaAA BBbb asdasdas(86)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas86" },
                    { 87, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 21, 23, 27, 48, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/87/900/500.jpg", 512, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas87", "Random title Lorem ipsum aaAA BBbb asdasdas(87)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas87" },
                    { 88, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 28, 0, 27, 21, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/88/900/500.jpg", 176, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas88", "Random title Lorem ipsum aaAA BBbb asdasdas(88)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas88" },
                    { 89, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 9, 13, 57, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/89/900/500.jpg", 170, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas89", "Random title Lorem ipsum aaAA BBbb asdasdas(89)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas89" },
                    { 90, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 6, 18, 11, 20, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/90/900/500.jpg", 596, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas90", "Random title Lorem ipsum aaAA BBbb asdasdas(90)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas90" },
                    { 91, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 17, 2, 32, 21, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/91/900/500.jpg", 480, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas91", "Random title Lorem ipsum aaAA BBbb asdasdas(91)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas91" },
                    { 92, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 18, 12, 16, 12, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/92/900/500.jpg", 403, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas92", "Random title Lorem ipsum aaAA BBbb asdasdas(92)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas92" },
                    { 94, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 7, 4, 17, 6, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/94/900/500.jpg", 862, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas94", "Random title Lorem ipsum aaAA BBbb asdasdas(94)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas94" },
                    { 77, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 2, 18, 15, 55, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/77/900/500.jpg", 565, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas77", "Random title Lorem ipsum aaAA BBbb asdasdas(77)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas77" },
                    { 113, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 17, 14, 41, 17, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/113/900/500.jpg", 767, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(113)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 115, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 18, 4, 7, 50, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/115/900/500.jpg", 89, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(115)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 136, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 12, 23, 49, 19, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/136/900/500.jpg", 394, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(136)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 137, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 19, 9, 14, 21, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/137/900/500.jpg", 427, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(137)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 138, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 25, 4, 44, 45, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/138/900/500.jpg", 110, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(138)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 139, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 6, 12, 31, 26, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/139/900/500.jpg", 135, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(139)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 140, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 23, 5, 8, 37, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/140/900/500.jpg", 918, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(140)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 141, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 8, 6, 26, 59, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/141/900/500.jpg", 584, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(141)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 142, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 17, 7, 26, 40, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/142/900/500.jpg", 208, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(142)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 143, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 4, 23, 37, 52, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/143/900/500.jpg", 769, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(143)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 144, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 18, 0, 24, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/144/900/500.jpg", 57, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(144)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 145, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 3, 18, 25, 39, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/145/900/500.jpg", 224, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(145)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 146, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 9, 13, 22, 30, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/146/900/500.jpg", 56, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(146)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 147, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 10, 13, 3, 27, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/147/900/500.jpg", 979, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(147)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 148, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 11, 12, 14, 18, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/148/900/500.jpg", 565, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(148)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 149, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 15, 9, 14, 59, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/149/900/500.jpg", 738, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(149)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 150, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 7, 0, 18, 28, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/150/900/500.jpg", 926, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas15", "Random title Lorem ipsum aaAA BBbb asdasdas(150)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas15" },
                    { 135, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 9, 10, 16, 34, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/135/900/500.jpg", 377, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(135)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 114, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 18, 11, 36, 23, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/114/900/500.jpg", 393, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(114)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 134, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 2, 0, 16, 44, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/134/900/500.jpg", 74, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(134)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 132, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 20, 4, 59, 25, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/132/900/500.jpg", 17, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(132)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 116, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 9, 17, 59, 17, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/116/900/500.jpg", 517, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(116)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 117, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 6, 30, 19, 17, 29, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/117/900/500.jpg", 167, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(117)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 118, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 11, 16, 41, 10, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/118/900/500.jpg", 344, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(118)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 119, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 22, 16, 52, 43, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/119/900/500.jpg", 486, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(119)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 120, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 17, 18, 43, 0, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/120/900/500.jpg", 152, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(120)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 121, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 15, 1, 11, 9, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/121/900/500.jpg", 956, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(121)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 122, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 15, 10, 58, 41, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/122/900/500.jpg", 754, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(122)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 123, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 15, 3, 52, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/123/900/500.jpg", 156, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(123)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 124, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 6, 15, 56, 42, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/124/900/500.jpg", 838, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(124)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 125, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 14, 1, 21, 27, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/125/900/500.jpg", 329, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(125)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 126, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 4, 22, 34, 24, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/126/900/500.jpg", 392, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(126)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 127, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 14, 10, 16, 7, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/127/900/500.jpg", 955, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(127)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 128, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 27, 3, 22, 12, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/128/900/500.jpg", 60, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(128)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 129, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 6, 16, 56, 44, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/129/900/500.jpg", 842, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(129)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 131, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 16, 8, 52, 2, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/131/900/500.jpg", 188, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(131)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 133, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 5, 9, 40, 31, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/133/900/500.jpg", 484, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(133)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 76, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 21, 2, 36, 42, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/76/900/500.jpg", 674, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas76", "Random title Lorem ipsum aaAA BBbb asdasdas(76)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas76" },
                    { 130, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 21, 9, 38, 36, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/130/900/500.jpg", 328, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(130)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 74, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 26, 1, 36, 30, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/74/900/500.jpg", 732, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas74", "Random title Lorem ipsum aaAA BBbb asdasdas(74)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas74" },
                    { 21, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 2, 9, 59, 23, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/21/900/500.jpg", 888, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas21", "Random title Lorem ipsum aaAA BBbb asdasdas(21)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas21" },
                    { 22, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 6, 4, 47, 29, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/22/900/500.jpg", 192, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas22", "Random title Lorem ipsum aaAA BBbb asdasdas(22)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas22" },
                    { 23, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 15, 18, 22, 48, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/23/900/500.jpg", 113, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas23", "Random title Lorem ipsum aaAA BBbb asdasdas(23)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas23" },
                    { 24, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 15, 17, 53, 22, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/24/900/500.jpg", 384, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas24", "Random title Lorem ipsum aaAA BBbb asdasdas(24)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas24" },
                    { 25, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 10, 1, 44, 20, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/25/900/500.jpg", 478, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas25", "Random title Lorem ipsum aaAA BBbb asdasdas(25)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas25" },
                    { 26, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 31, 12, 57, 55, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/26/900/500.jpg", 154, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas26", "Random title Lorem ipsum aaAA BBbb asdasdas(26)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas26" },
                    { 27, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 6, 30, 10, 9, 41, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/27/900/500.jpg", 546, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas27", "Random title Lorem ipsum aaAA BBbb asdasdas(27)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas27" },
                    { 28, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 2, 9, 49, 52, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/28/900/500.jpg", 960, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas28", "Random title Lorem ipsum aaAA BBbb asdasdas(28)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas28" },
                    { 29, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 31, 18, 14, 49, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/29/900/500.jpg", 741, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas29", "Random title Lorem ipsum aaAA BBbb asdasdas(29)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas29" },
                    { 30, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 12, 17, 3, 38, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/30/900/500.jpg", 100, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas30", "Random title Lorem ipsum aaAA BBbb asdasdas(30)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas30" },
                    { 31, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 2, 12, 31, 12, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/31/900/500.jpg", 117, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas31", "Random title Lorem ipsum aaAA BBbb asdasdas(31)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas31" },
                    { 32, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 12, 8, 38, 14, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/32/900/500.jpg", 54, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas32", "Random title Lorem ipsum aaAA BBbb asdasdas(32)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas32" },
                    { 33, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 6, 14, 15, 33, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/33/900/500.jpg", 57, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas33", "Random title Lorem ipsum aaAA BBbb asdasdas(33)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas33" },
                    { 34, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 10, 7, 53, 0, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/34/900/500.jpg", 116, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas34", "Random title Lorem ipsum aaAA BBbb asdasdas(34)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas34" },
                    { 35, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 14, 17, 18, 9, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/35/900/500.jpg", 985, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas35", "Random title Lorem ipsum aaAA BBbb asdasdas(35)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas35" },
                    { 20, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 14, 6, 8, 50, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/20/900/500.jpg", 797, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas20", "Random title Lorem ipsum aaAA BBbb asdasdas(20)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas20" },
                    { 36, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 1, 16, 58, 59, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/36/900/500.jpg", 361, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas36", "Random title Lorem ipsum aaAA BBbb asdasdas(36)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas36" },
                    { 19, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 27, 13, 50, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/19/900/500.jpg", 205, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas19", "Random title Lorem ipsum aaAA BBbb asdasdas(19)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas19" },
                    { 17, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 16, 2, 41, 38, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/17/900/500.jpg", 72, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas17", "Random title Lorem ipsum aaAA BBbb asdasdas(17)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas17" },
                    { 75, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 20, 10, 25, 24, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/75/900/500.jpg", 371, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas75", "Random title Lorem ipsum aaAA BBbb asdasdas(75)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas75" },
                    { 2, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 12, 3, 19, 5, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/2/900/500.jpg", 811, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas2", "Random title Lorem ipsum aaAA BBbb asdasdas(2)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas2" },
                    { 3, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 10, 20, 45, 19, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/3/900/500.jpg", 48, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas3", "Random title Lorem ipsum aaAA BBbb asdasdas(3)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas3" },
                    { 4, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 2, 0, 35, 59, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/4/900/500.jpg", 149, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas4", "Random title Lorem ipsum aaAA BBbb asdasdas(4)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas4" },
                    { 5, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 18, 12, 3, 34, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/5/900/500.jpg", 630, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas5", "Random title Lorem ipsum aaAA BBbb asdasdas(5)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas5" },
                    { 6, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 25, 13, 7, 9, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/6/900/500.jpg", 495, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas6", "Random title Lorem ipsum aaAA BBbb asdasdas(6)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas6" },
                    { 7, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 17, 0, 22, 42, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/7/900/500.jpg", 460, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas7", "Random title Lorem ipsum aaAA BBbb asdasdas(7)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas7" },
                    { 8, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 18, 12, 9, 53, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/8/900/500.jpg", 846, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas8", "Random title Lorem ipsum aaAA BBbb asdasdas(8)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas8" },
                    { 10, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 6, 29, 7, 26, 17, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/10/900/500.jpg", 940, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas10", "Random title Lorem ipsum aaAA BBbb asdasdas(10)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas10" },
                    { 11, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 9, 5, 25, 50, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/11/900/500.jpg", 24, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas11", "Random title Lorem ipsum aaAA BBbb asdasdas(11)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas11" },
                    { 12, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 21, 17, 58, 55, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/12/900/500.jpg", 2, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas12", "Random title Lorem ipsum aaAA BBbb asdasdas(12)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas12" },
                    { 13, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 15, 2, 29, 16, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/13/900/500.jpg", 637, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas13", "Random title Lorem ipsum aaAA BBbb asdasdas(13)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas13" },
                    { 14, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 27, 12, 36, 54, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/14/900/500.jpg", 899, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas14", "Random title Lorem ipsum aaAA BBbb asdasdas(14)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas14" },
                    { 15, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 13, 16, 24, 38, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/15/900/500.jpg", 140, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas15", "Random title Lorem ipsum aaAA BBbb asdasdas(15)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas15" },
                    { 16, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 3, 17, 8, 54, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/16/900/500.jpg", 852, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas16", "Random title Lorem ipsum aaAA BBbb asdasdas(16)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas16" },
                    { 18, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 2, 13, 27, 24, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/18/900/500.jpg", 93, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas18", "Random title Lorem ipsum aaAA BBbb asdasdas(18)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas18" },
                    { 37, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 9, 1, 58, 45, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/37/900/500.jpg", 209, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas37", "Random title Lorem ipsum aaAA BBbb asdasdas(37)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas37" },
                    { 9, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 25, 20, 18, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/9/900/500.jpg", 255, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas9", "Random title Lorem ipsum aaAA BBbb asdasdas(9)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas9" },
                    { 39, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 16, 11, 25, 3, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/39/900/500.jpg", 586, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas39", "Random title Lorem ipsum aaAA BBbb asdasdas(39)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas39" },
                    { 59, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 7, 8, 53, 9, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/59/900/500.jpg", 585, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas59", "Random title Lorem ipsum aaAA BBbb asdasdas(59)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas59" },
                    { 60, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 8, 13, 40, 41, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/60/900/500.jpg", 592, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas60", "Random title Lorem ipsum aaAA BBbb asdasdas(60)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas60" },
                    { 61, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 24, 4, 50, 14, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/61/900/500.jpg", 524, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas61", "Random title Lorem ipsum aaAA BBbb asdasdas(61)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas61" },
                    { 62, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 14, 8, 18, 57, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/62/900/500.jpg", 237, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas62", "Random title Lorem ipsum aaAA BBbb asdasdas(62)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas62" },
                    { 63, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 7, 2, 19, 14, 34, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/63/900/500.jpg", 753, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas63", "Random title Lorem ipsum aaAA BBbb asdasdas(63)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas63" },
                    { 64, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 23, 8, 11, 14, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/64/900/500.jpg", 541, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas64", "Random title Lorem ipsum aaAA BBbb asdasdas(64)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas64" },
                    { 65, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 20, 16, 42, 27, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/65/900/500.jpg", 194, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas65", "Random title Lorem ipsum aaAA BBbb asdasdas(65)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas65" },
                    { 66, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 6, 30, 14, 44, 28, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/66/900/500.jpg", 92, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas66", "Random title Lorem ipsum aaAA BBbb asdasdas(66)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas66" },
                    { 67, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 19, 22, 23, 19, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/67/900/500.jpg", 545, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas67", "Random title Lorem ipsum aaAA BBbb asdasdas(67)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas67" },
                    { 68, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 6, 3, 21, 9, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/68/900/500.jpg", 385, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas68", "Random title Lorem ipsum aaAA BBbb asdasdas(68)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas68" },
                    { 69, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 23, 12, 20, 1, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/69/900/500.jpg", 558, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas69", "Random title Lorem ipsum aaAA BBbb asdasdas(69)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas69" },
                    { 70, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 6, 9, 53, 39, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/70/900/500.jpg", 101, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas70", "Random title Lorem ipsum aaAA BBbb asdasdas(70)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas70" },
                    { 72, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 24, 18, 1, 50, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/72/900/500.jpg", 697, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas72", "Random title Lorem ipsum aaAA BBbb asdasdas(72)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas72" },
                    { 38, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 6, 29, 21, 41, 35, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/38/900/500.jpg", 271, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas38", "Random title Lorem ipsum aaAA BBbb asdasdas(38)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas38" },
                    { 73, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 20, 16, 55, 51, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/73/900/500.jpg", 423, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas73", "Random title Lorem ipsum aaAA BBbb asdasdas(73)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas73" },
                    { 58, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 12, 17, 11, 56, 18, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/58/900/500.jpg", 62, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas58", "Random title Lorem ipsum aaAA BBbb asdasdas(58)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas58" },
                    { 57, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 7, 2, 8, 46, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/57/900/500.jpg", 415, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas57", "Random title Lorem ipsum aaAA BBbb asdasdas(57)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas57" },
                    { 71, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 2, 9, 7, 8, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/71/900/500.jpg", 39, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas71", "Random title Lorem ipsum aaAA BBbb asdasdas(71)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas71" },
                    { 55, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 18, 0, 56, 40, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/55/900/500.jpg", 551, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas55", "Random title Lorem ipsum aaAA BBbb asdasdas(55)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas55" },
                    { 56, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 20, 0, 0, 49, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/56/900/500.jpg", 541, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas56", "Random title Lorem ipsum aaAA BBbb asdasdas(56)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas56" },
                    { 42, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 1, 10, 4, 31, 31, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/42/900/500.jpg", 42, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas42", "Random title Lorem ipsum aaAA BBbb asdasdas(42)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas42" },
                    { 43, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 23, 2, 14, 45, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/43/900/500.jpg", 441, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas43", "Random title Lorem ipsum aaAA BBbb asdasdas(43)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas43" },
                    { 44, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 2, 7, 6, 31, 11, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/44/900/500.jpg", 212, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas44", "Random title Lorem ipsum aaAA BBbb asdasdas(44)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas44" },
                    { 45, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 2, 0, 39, 13, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/45/900/500.jpg", 631, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas45", "Random title Lorem ipsum aaAA BBbb asdasdas(45)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas45" },
                    { 46, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2020, 3, 11, 8, 52, 32, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/46/900/500.jpg", 175, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas46", "Random title Lorem ipsum aaAA BBbb asdasdas(46)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas46" },
                    { 41, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 26, 14, 55, 23, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/41/900/500.jpg", 300, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas41", "Random title Lorem ipsum aaAA BBbb asdasdas(41)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas41" },
                    { 47, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 6, 2, 54, 33, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/47/900/500.jpg", 306, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas47", "Random title Lorem ipsum aaAA BBbb asdasdas(47)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas47" },
                    { 49, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 4, 22, 29, 8, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/49/900/500.jpg", 438, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas49", "Random title Lorem ipsum aaAA BBbb asdasdas(49)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas49" },
                    { 50, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 8, 20, 2, 54, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/50/900/500.jpg", 699, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas50", "Random title Lorem ipsum aaAA BBbb asdasdas(50)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas50" },
                    { 51, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 6, 3, 5, 8, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/51/900/500.jpg", 67, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas51", "Random title Lorem ipsum aaAA BBbb asdasdas(51)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas51" },
                    { 52, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 12, 1, 1, 39, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/52/900/500.jpg", 178, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas52", "Random title Lorem ipsum aaAA BBbb asdasdas(52)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas52" },
                    { 53, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 11, 21, 4, 18, 17, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/53/900/500.jpg", 338, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas53", "Random title Lorem ipsum aaAA BBbb asdasdas(53)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas53" },
                    { 40, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 8, 31, 22, 51, 19, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/40/900/500.jpg", 641, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas40", "Random title Lorem ipsum aaAA BBbb asdasdas(40)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas40" },
                    { 54, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 9, 17, 10, 29, 5, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/54/900/500.jpg", 801, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas54", "Random title Lorem ipsum aaAA BBbb asdasdas(54)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas54" },
                    { 48, "Jan Kowalski", new DateTime(2020, 3, 20, 15, 44, 40, 107, DateTimeKind.Utc).AddTicks(9640), new DateTime(2019, 10, 21, 10, 38, 35, 0, DateTimeKind.Utc), "https:i.picsum.photos/id/48/900/500.jpg", 814, "random-title-lorem-ipsum-aaaa-bbbb-asdasdas48", "Random title Lorem ipsum aaAA BBbb asdasdas(48)!!! ??? %$^&", "https://randomwebsite.com/random-title-lorem-ipsum-aaaa-bbbb-asdasdas48" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "NameToDisplay", "Slug" },
                values: new object[,]
                {
                    { 7, "Random category name #7 !?$#", "random-category-name-7" },
                    { 10, "Random category name #10 !?$#", "random-category-name-10" },
                    { 9, "Random category name #9 !?$#", "random-category-name-9" },
                    { 6, "Random category name #6 !?$#", "random-category-name-6" },
                    { 8, "Random category name #8 !?$#", "random-category-name-8" },
                    { 4, "Random category name #4 !?$#", "random-category-name-4" },
                    { 3, "Random category name #3 !?$#", "random-category-name-3" },
                    { 2, "Random category name #2 !?$#", "random-category-name-2" },
                    { 1, "Random category name #1 !?$#", "random-category-name-1" },
                    { 5, "Random category name #5 !?$#", "random-category-name-5" }
                });

            migrationBuilder.InsertData(
                table: "Keywords",
                columns: new[] { "Id", "NameToDisplay", "Slug" },
                values: new object[,]
                {
                    { 72, "Random Keyword #72 !?$#", "random-keyword-72" },
                    { 71, "Random Keyword #71 !?$#", "random-keyword-71" },
                    { 70, "Random Keyword #70 !?$#", "random-keyword-70" },
                    { 69, "Random Keyword #69 !?$#", "random-keyword-69" },
                    { 68, "Random Keyword #68 !?$#", "random-keyword-68" },
                    { 67, "Random Keyword #67 !?$#", "random-keyword-67" },
                    { 66, "Random Keyword #66 !?$#", "random-keyword-66" },
                    { 65, "Random Keyword #65 !?$#", "random-keyword-65" },
                    { 64, "Random Keyword #64 !?$#", "random-keyword-64" },
                    { 63, "Random Keyword #63 !?$#", "random-keyword-63" },
                    { 60, "Random Keyword #60 !?$#", "random-keyword-60" },
                    { 61, "Random Keyword #61 !?$#", "random-keyword-61" },
                    { 52, "Random Keyword #52 !?$#", "random-keyword-52" },
                    { 59, "Random Keyword #59 !?$#", "random-keyword-59" },
                    { 58, "Random Keyword #58 !?$#", "random-keyword-58" },
                    { 57, "Random Keyword #57 !?$#", "random-keyword-57" },
                    { 56, "Random Keyword #56 !?$#", "random-keyword-56" },
                    { 55, "Random Keyword #55 !?$#", "random-keyword-55" },
                    { 53, "Random Keyword #53 !?$#", "random-keyword-53" },
                    { 54, "Random Keyword #54 !?$#", "random-keyword-54" },
                    { 73, "Random Keyword #73 !?$#", "random-keyword-73" },
                    { 62, "Random Keyword #62 !?$#", "random-keyword-62" },
                    { 74, "Random Keyword #74 !?$#", "random-keyword-74" },
                    { 96, "Random Keyword #96 !?$#", "random-keyword-96" },
                    { 76, "Random Keyword #76 !?$#", "random-keyword-76" },
                    { 98, "Random Keyword #98 !?$#", "random-keyword-98" },
                    { 51, "Random Keyword #51 !?$#", "random-keyword-51" },
                    { 97, "Random Keyword #97 !?$#", "random-keyword-97" },
                    { 95, "Random Keyword #95 !?$#", "random-keyword-95" },
                    { 94, "Random Keyword #94 !?$#", "random-keyword-94" },
                    { 93, "Random Keyword #93 !?$#", "random-keyword-93" },
                    { 92, "Random Keyword #92 !?$#", "random-keyword-92" },
                    { 91, "Random Keyword #91 !?$#", "random-keyword-91" },
                    { 90, "Random Keyword #90 !?$#", "random-keyword-90" },
                    { 89, "Random Keyword #89 !?$#", "random-keyword-89" },
                    { 75, "Random Keyword #75 !?$#", "random-keyword-75" },
                    { 88, "Random Keyword #88 !?$#", "random-keyword-88" },
                    { 86, "Random Keyword #86 !?$#", "random-keyword-86" },
                    { 85, "Random Keyword #85 !?$#", "random-keyword-85" },
                    { 84, "Random Keyword #84 !?$#", "random-keyword-84" },
                    { 83, "Random Keyword #83 !?$#", "random-keyword-83" },
                    { 82, "Random Keyword #82 !?$#", "random-keyword-82" },
                    { 81, "Random Keyword #81 !?$#", "random-keyword-81" },
                    { 80, "Random Keyword #80 !?$#", "random-keyword-80" },
                    { 79, "Random Keyword #79 !?$#", "random-keyword-79" },
                    { 78, "Random Keyword #78 !?$#", "random-keyword-78" },
                    { 77, "Random Keyword #77 !?$#", "random-keyword-77" },
                    { 87, "Random Keyword #87 !?$#", "random-keyword-87" },
                    { 50, "Random Keyword #50 !?$#", "random-keyword-50" },
                    { 8, "Random Keyword #8 !?$#", "random-keyword-8" },
                    { 48, "Random Keyword #48 !?$#", "random-keyword-48" },
                    { 21, "Random Keyword #21 !?$#", "random-keyword-21" },
                    { 20, "Random Keyword #20 !?$#", "random-keyword-20" },
                    { 19, "Random Keyword #19 !?$#", "random-keyword-19" },
                    { 18, "Random Keyword #18 !?$#", "random-keyword-18" },
                    { 17, "Random Keyword #17 !?$#", "random-keyword-17" },
                    { 16, "Random Keyword #16 !?$#", "random-keyword-16" },
                    { 15, "Random Keyword #15 !?$#", "random-keyword-15" },
                    { 14, "Random Keyword #14 !?$#", "random-keyword-14" },
                    { 13, "Random Keyword #13 !?$#", "random-keyword-13" },
                    { 12, "Random Keyword #12 !?$#", "random-keyword-12" },
                    { 11, "Random Keyword #11 !?$#", "random-keyword-11" },
                    { 10, "Random Keyword #10 !?$#", "random-keyword-10" },
                    { 9, "Random Keyword #9 !?$#", "random-keyword-9" },
                    { 7, "Random Keyword #7 !?$#", "random-keyword-7" },
                    { 6, "Random Keyword #6 !?$#", "random-keyword-6" },
                    { 5, "Random Keyword #5 !?$#", "random-keyword-5" },
                    { 4, "Random Keyword #4 !?$#", "random-keyword-4" },
                    { 3, "Random Keyword #3 !?$#", "random-keyword-3" },
                    { 2, "Random Keyword #2 !?$#", "random-keyword-2" },
                    { 1, "Random Keyword #1 !?$#", "random-keyword-1" },
                    { 99, "Random Keyword #99 !?$#", "random-keyword-99" },
                    { 22, "Random Keyword #22 !?$#", "random-keyword-22" },
                    { 23, "Random Keyword #23 !?$#", "random-keyword-23" },
                    { 24, "Random Keyword #24 !?$#", "random-keyword-24" },
                    { 25, "Random Keyword #25 !?$#", "random-keyword-25" },
                    { 47, "Random Keyword #47 !?$#", "random-keyword-47" },
                    { 46, "Random Keyword #46 !?$#", "random-keyword-46" },
                    { 45, "Random Keyword #45 !?$#", "random-keyword-45" },
                    { 44, "Random Keyword #44 !?$#", "random-keyword-44" },
                    { 43, "Random Keyword #43 !?$#", "random-keyword-43" },
                    { 42, "Random Keyword #42 !?$#", "random-keyword-42" },
                    { 41, "Random Keyword #41 !?$#", "random-keyword-41" },
                    { 40, "Random Keyword #40 !?$#", "random-keyword-40" },
                    { 39, "Random Keyword #39 !?$#", "random-keyword-39" },
                    { 38, "Random Keyword #38 !?$#", "random-keyword-38" },
                    { 49, "Random Keyword #49 !?$#", "random-keyword-49" },
                    { 37, "Random Keyword #37 !?$#", "random-keyword-37" },
                    { 35, "Random Keyword #35 !?$#", "random-keyword-35" },
                    { 34, "Random Keyword #34 !?$#", "random-keyword-34" },
                    { 33, "Random Keyword #33 !?$#", "random-keyword-33" },
                    { 32, "Random Keyword #32 !?$#", "random-keyword-32" },
                    { 31, "Random Keyword #31 !?$#", "random-keyword-31" },
                    { 30, "Random Keyword #30 !?$#", "random-keyword-30" },
                    { 29, "Random Keyword #29 !?$#", "random-keyword-29" },
                    { 28, "Random Keyword #28 !?$#", "random-keyword-28" },
                    { 27, "Random Keyword #27 !?$#", "random-keyword-27" },
                    { 26, "Random Keyword #26 !?$#", "random-keyword-26" },
                    { 36, "Random Keyword #36 !?$#", "random-keyword-36" },
                    { 100, "Random Keyword #100 !?$#", "random-keyword-100" }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategory",
                columns: new[] { "ArticleId", "CategoryId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 139, 6 },
                    { 142, 6 },
                    { 144, 6 },
                    { 145, 6 },
                    { 147, 6 },
                    { 148, 6 },
                    { 149, 6 },
                    { 2, 7 },
                    { 138, 6 },
                    { 3, 7 },
                    { 5, 7 },
                    { 6, 7 },
                    { 8, 7 },
                    { 10, 7 },
                    { 12, 7 },
                    { 13, 7 },
                    { 14, 7 },
                    { 15, 7 },
                    { 4, 7 },
                    { 134, 6 },
                    { 133, 6 },
                    { 131, 6 },
                    { 95, 6 },
                    { 96, 6 },
                    { 98, 6 },
                    { 100, 6 },
                    { 101, 6 },
                    { 102, 6 },
                    { 103, 6 },
                    { 105, 6 },
                    { 110, 6 },
                    { 112, 6 },
                    { 116, 6 },
                    { 117, 6 },
                    { 118, 6 },
                    { 120, 6 },
                    { 121, 6 },
                    { 123, 6 },
                    { 128, 6 },
                    { 129, 6 },
                    { 130, 6 },
                    { 17, 7 },
                    { 18, 7 },
                    { 20, 7 },
                    { 26, 7 },
                    { 79, 7 },
                    { 88, 7 },
                    { 90, 7 },
                    { 91, 7 },
                    { 92, 7 },
                    { 93, 7 },
                    { 94, 7 },
                    { 95, 7 },
                    { 96, 7 },
                    { 97, 7 },
                    { 98, 7 },
                    { 99, 7 },
                    { 101, 7 },
                    { 102, 7 },
                    { 103, 7 },
                    { 104, 7 },
                    { 105, 7 },
                    { 107, 7 },
                    { 108, 7 },
                    { 78, 7 },
                    { 94, 6 },
                    { 77, 7 },
                    { 73, 7 },
                    { 32, 7 },
                    { 34, 7 },
                    { 35, 7 },
                    { 36, 7 },
                    { 37, 7 },
                    { 38, 7 },
                    { 41, 7 },
                    { 43, 7 },
                    { 45, 7 },
                    { 46, 7 },
                    { 48, 7 },
                    { 50, 7 },
                    { 53, 7 },
                    { 57, 7 },
                    { 59, 7 },
                    { 66, 7 },
                    { 70, 7 },
                    { 71, 7 },
                    { 72, 7 },
                    { 76, 7 },
                    { 93, 6 },
                    { 92, 6 },
                    { 90, 6 },
                    { 113, 5 },
                    { 116, 5 },
                    { 118, 5 },
                    { 120, 5 },
                    { 121, 5 },
                    { 123, 5 },
                    { 124, 5 },
                    { 128, 5 },
                    { 131, 5 },
                    { 134, 5 },
                    { 138, 5 },
                    { 144, 5 },
                    { 145, 5 },
                    { 146, 5 },
                    { 148, 5 },
                    { 149, 5 },
                    { 150, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 112, 5 },
                    { 3, 6 },
                    { 110, 5 },
                    { 106, 5 },
                    { 77, 5 },
                    { 78, 5 },
                    { 79, 5 },
                    { 80, 5 },
                    { 81, 5 },
                    { 84, 5 },
                    { 86, 5 },
                    { 88, 5 },
                    { 89, 5 },
                    { 90, 5 },
                    { 91, 5 },
                    { 94, 5 },
                    { 95, 5 },
                    { 96, 5 },
                    { 99, 5 },
                    { 102, 5 },
                    { 103, 5 },
                    { 104, 5 },
                    { 105, 5 },
                    { 109, 5 },
                    { 112, 7 },
                    { 4, 6 },
                    { 6, 6 },
                    { 50, 6 },
                    { 51, 6 },
                    { 54, 6 },
                    { 55, 6 },
                    { 56, 6 },
                    { 59, 6 },
                    { 60, 6 },
                    { 62, 6 },
                    { 63, 6 },
                    { 66, 6 },
                    { 70, 6 },
                    { 71, 6 },
                    { 75, 6 },
                    { 76, 6 },
                    { 77, 6 },
                    { 78, 6 },
                    { 79, 6 },
                    { 86, 6 },
                    { 88, 6 },
                    { 49, 6 },
                    { 5, 6 },
                    { 48, 6 },
                    { 46, 6 },
                    { 8, 6 },
                    { 9, 6 },
                    { 11, 6 },
                    { 12, 6 },
                    { 14, 6 },
                    { 18, 6 },
                    { 21, 6 },
                    { 24, 6 },
                    { 25, 6 },
                    { 27, 6 },
                    { 31, 6 },
                    { 32, 6 },
                    { 35, 6 },
                    { 36, 6 },
                    { 39, 6 },
                    { 40, 6 },
                    { 41, 6 },
                    { 43, 6 },
                    { 44, 6 },
                    { 47, 6 },
                    { 72, 5 },
                    { 116, 7 },
                    { 118, 7 },
                    { 49, 9 },
                    { 51, 9 },
                    { 53, 9 },
                    { 54, 9 },
                    { 56, 9 },
                    { 57, 9 },
                    { 59, 9 },
                    { 61, 9 },
                    { 47, 9 },
                    { 62, 9 },
                    { 65, 9 },
                    { 66, 9 },
                    { 67, 9 },
                    { 68, 9 },
                    { 70, 9 },
                    { 71, 9 },
                    { 72, 9 },
                    { 73, 9 },
                    { 64, 9 },
                    { 46, 9 },
                    { 44, 9 },
                    { 41, 9 },
                    { 3, 9 },
                    { 4, 9 },
                    { 8, 9 },
                    { 10, 9 },
                    { 12, 9 },
                    { 13, 9 },
                    { 14, 9 },
                    { 19, 9 },
                    { 20, 9 },
                    { 21, 9 },
                    { 28, 9 },
                    { 30, 9 },
                    { 32, 9 },
                    { 33, 9 },
                    { 34, 9 },
                    { 35, 9 },
                    { 36, 9 },
                    { 39, 9 },
                    { 40, 9 },
                    { 74, 9 },
                    { 75, 9 },
                    { 76, 9 },
                    { 79, 9 },
                    { 117, 9 },
                    { 118, 9 },
                    { 119, 9 },
                    { 120, 9 },
                    { 122, 9 },
                    { 123, 9 },
                    { 124, 9 },
                    { 126, 9 },
                    { 127, 9 },
                    { 128, 9 },
                    { 129, 9 },
                    { 130, 9 },
                    { 132, 9 },
                    { 134, 9 },
                    { 142, 9 },
                    { 143, 9 },
                    { 144, 9 },
                    { 145, 9 },
                    { 149, 9 },
                    { 116, 9 },
                    { 150, 8 },
                    { 115, 9 },
                    { 113, 9 },
                    { 84, 9 },
                    { 86, 9 },
                    { 88, 9 },
                    { 89, 9 },
                    { 90, 9 },
                    { 91, 9 },
                    { 92, 9 },
                    { 93, 9 },
                    { 94, 9 },
                    { 96, 9 },
                    { 97, 9 },
                    { 100, 9 },
                    { 102, 9 },
                    { 103, 9 },
                    { 105, 9 },
                    { 106, 9 },
                    { 108, 9 },
                    { 110, 9 },
                    { 112, 9 },
                    { 114, 9 },
                    { 149, 8 },
                    { 145, 8 },
                    { 144, 8 },
                    { 19, 8 },
                    { 21, 8 },
                    { 23, 8 },
                    { 24, 8 },
                    { 28, 8 },
                    { 29, 8 },
                    { 31, 8 },
                    { 32, 8 },
                    { 35, 8 },
                    { 36, 8 },
                    { 37, 8 },
                    { 39, 8 },
                    { 40, 8 },
                    { 41, 8 },
                    { 46, 8 },
                    { 47, 8 },
                    { 48, 8 },
                    { 49, 8 },
                    { 54, 8 },
                    { 18, 8 },
                    { 56, 8 },
                    { 16, 8 },
                    { 13, 8 },
                    { 120, 7 },
                    { 124, 7 },
                    { 125, 7 },
                    { 128, 7 },
                    { 129, 7 },
                    { 131, 7 },
                    { 133, 7 },
                    { 134, 7 },
                    { 136, 7 },
                    { 140, 7 },
                    { 144, 7 },
                    { 145, 7 },
                    { 149, 7 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 8 },
                    { 6, 8 },
                    { 8, 8 },
                    { 12, 8 },
                    { 14, 8 },
                    { 117, 7 },
                    { 57, 8 },
                    { 61, 8 },
                    { 102, 8 },
                    { 103, 8 },
                    { 105, 8 },
                    { 108, 8 },
                    { 110, 8 },
                    { 112, 8 },
                    { 116, 8 },
                    { 117, 8 },
                    { 121, 8 },
                    { 125, 8 },
                    { 127, 8 },
                    { 128, 8 },
                    { 129, 8 },
                    { 130, 8 },
                    { 131, 8 },
                    { 132, 8 },
                    { 133, 8 },
                    { 134, 8 },
                    { 137, 8 },
                    { 98, 8 },
                    { 58, 8 },
                    { 97, 8 },
                    { 93, 8 },
                    { 62, 8 },
                    { 65, 8 },
                    { 66, 8 },
                    { 67, 8 },
                    { 69, 8 },
                    { 71, 8 },
                    { 73, 8 },
                    { 75, 8 },
                    { 76, 8 },
                    { 77, 8 },
                    { 78, 8 },
                    { 79, 8 },
                    { 81, 8 },
                    { 84, 8 },
                    { 85, 8 },
                    { 88, 8 },
                    { 89, 8 },
                    { 90, 8 },
                    { 92, 8 },
                    { 96, 8 },
                    { 71, 5 },
                    { 148, 9 },
                    { 67, 5 },
                    { 57, 2 },
                    { 59, 2 },
                    { 60, 2 },
                    { 61, 2 },
                    { 62, 2 },
                    { 63, 2 },
                    { 64, 2 },
                    { 65, 2 },
                    { 52, 2 },
                    { 66, 2 },
                    { 70, 2 },
                    { 71, 2 },
                    { 72, 2 },
                    { 75, 2 },
                    { 77, 2 },
                    { 78, 2 },
                    { 79, 2 },
                    { 81, 2 },
                    { 67, 2 },
                    { 51, 2 },
                    { 50, 2 },
                    { 46, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 21, 2 },
                    { 23, 2 },
                    { 24, 2 },
                    { 27, 2 },
                    { 28, 2 },
                    { 30, 2 },
                    { 31, 2 },
                    { 32, 2 },
                    { 34, 2 },
                    { 35, 2 },
                    { 36, 2 },
                    { 37, 2 },
                    { 38, 2 },
                    { 39, 2 },
                    { 41, 2 },
                    { 42, 2 },
                    { 43, 2 },
                    { 82, 2 },
                    { 84, 2 },
                    { 86, 2 },
                    { 88, 2 },
                    { 144, 2 },
                    { 145, 2 },
                    { 147, 2 },
                    { 149, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 7, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 19, 3 },
                    { 21, 3 },
                    { 24, 3 },
                    { 28, 3 },
                    { 32, 3 },
                    { 33, 3 },
                    { 34, 3 },
                    { 134, 2 },
                    { 68, 5 },
                    { 132, 2 },
                    { 130, 2 },
                    { 90, 2 },
                    { 92, 2 },
                    { 93, 2 },
                    { 96, 2 },
                    { 101, 2 },
                    { 102, 2 },
                    { 103, 2 },
                    { 106, 2 },
                    { 107, 2 },
                    { 112, 2 },
                    { 115, 2 },
                    { 116, 2 },
                    { 118, 2 },
                    { 119, 2 },
                    { 123, 2 },
                    { 124, 2 },
                    { 126, 2 },
                    { 127, 2 },
                    { 128, 2 },
                    { 131, 2 },
                    { 10, 2 },
                    { 8, 2 },
                    { 7, 2 },
                    { 49, 1 },
                    { 50, 1 },
                    { 51, 1 },
                    { 53, 1 },
                    { 54, 1 },
                    { 56, 1 },
                    { 57, 1 },
                    { 59, 1 },
                    { 61, 1 },
                    { 62, 1 },
                    { 64, 1 },
                    { 66, 1 },
                    { 67, 1 },
                    { 68, 1 },
                    { 70, 1 },
                    { 71, 1 },
                    { 72, 1 },
                    { 73, 1 },
                    { 75, 1 },
                    { 47, 1 },
                    { 77, 1 },
                    { 46, 1 },
                    { 41, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 18, 1 },
                    { 20, 1 },
                    { 22, 1 },
                    { 24, 1 },
                    { 28, 1 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 },
                    { 37, 1 },
                    { 39, 1 },
                    { 40, 1 },
                    { 44, 1 },
                    { 35, 3 },
                    { 81, 1 },
                    { 84, 1 },
                    { 118, 1 },
                    { 119, 1 },
                    { 120, 1 },
                    { 124, 1 },
                    { 125, 1 },
                    { 127, 1 },
                    { 128, 1 },
                    { 129, 1 },
                    { 131, 1 },
                    { 133, 1 },
                    { 134, 1 },
                    { 136, 1 },
                    { 138, 1 },
                    { 142, 1 },
                    { 144, 1 },
                    { 146, 1 },
                    { 149, 1 },
                    { 1, 2 },
                    { 6, 2 },
                    { 116, 1 },
                    { 83, 1 },
                    { 115, 1 },
                    { 113, 1 },
                    { 85, 1 },
                    { 86, 1 },
                    { 88, 1 },
                    { 89, 1 },
                    { 90, 1 },
                    { 92, 1 },
                    { 93, 1 },
                    { 94, 1 },
                    { 95, 1 },
                    { 96, 1 },
                    { 97, 1 },
                    { 98, 1 },
                    { 101, 1 },
                    { 103, 1 },
                    { 104, 1 },
                    { 105, 1 },
                    { 108, 1 },
                    { 110, 1 },
                    { 112, 1 },
                    { 114, 1 },
                    { 36, 3 },
                    { 11, 2 },
                    { 39, 3 },
                    { 92, 4 },
                    { 93, 4 },
                    { 94, 4 },
                    { 95, 4 },
                    { 96, 4 },
                    { 97, 4 },
                    { 101, 4 },
                    { 102, 4 },
                    { 105, 4 },
                    { 106, 4 },
                    { 107, 4 },
                    { 110, 4 },
                    { 114, 4 },
                    { 116, 4 },
                    { 117, 4 },
                    { 118, 4 },
                    { 120, 4 },
                    { 123, 4 },
                    { 124, 4 },
                    { 91, 4 },
                    { 132, 4 },
                    { 90, 4 },
                    { 88, 4 },
                    { 50, 4 },
                    { 55, 4 },
                    { 56, 4 },
                    { 57, 4 },
                    { 61, 4 },
                    { 62, 4 },
                    { 63, 4 },
                    { 64, 4 },
                    { 66, 4 },
                    { 67, 4 },
                    { 70, 4 },
                    { 71, 4 },
                    { 72, 4 },
                    { 73, 4 },
                    { 76, 4 },
                    { 77, 4 },
                    { 79, 4 },
                    { 81, 4 },
                    { 84, 4 },
                    { 89, 4 },
                    { 49, 4 },
                    { 133, 4 },
                    { 138, 4 },
                    { 35, 5 },
                    { 36, 5 },
                    { 38, 5 },
                    { 39, 5 },
                    { 42, 5 },
                    { 43, 5 },
                    { 44, 5 },
                    { 46, 5 },
                    { 48, 5 },
                    { 49, 5 },
                    { 50, 5 },
                    { 54, 5 },
                    { 56, 5 },
                    { 57, 5 },
                    { 59, 5 },
                    { 61, 5 },
                    { 62, 5 },
                    { 37, 3 },
                    { 66, 5 },
                    { 34, 5 },
                    { 134, 4 },
                    { 33, 5 },
                    { 28, 5 },
                    { 141, 4 },
                    { 142, 4 },
                    { 144, 4 },
                    { 145, 4 },
                    { 147, 4 },
                    { 149, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 7, 5 },
                    { 9, 5 },
                    { 12, 5 },
                    { 13, 5 },
                    { 14, 5 },
                    { 18, 5 },
                    { 20, 5 },
                    { 21, 5 },
                    { 22, 5 },
                    { 32, 5 },
                    { 48, 4 },
                    { 128, 4 },
                    { 46, 4 },
                    { 79, 3 },
                    { 81, 3 },
                    { 84, 3 },
                    { 85, 3 },
                    { 86, 3 },
                    { 87, 3 },
                    { 88, 3 },
                    { 90, 3 },
                    { 91, 3 },
                    { 92, 3 },
                    { 93, 3 },
                    { 94, 3 },
                    { 97, 3 },
                    { 101, 3 },
                    { 103, 3 },
                    { 107, 3 },
                    { 110, 3 },
                    { 111, 3 },
                    { 114, 3 },
                    { 77, 3 },
                    { 116, 3 },
                    { 76, 3 },
                    { 70, 3 },
                    { 47, 4 },
                    { 41, 3 },
                    { 42, 3 },
                    { 43, 3 },
                    { 46, 3 },
                    { 48, 3 },
                    { 50, 3 },
                    { 51, 3 },
                    { 53, 3 },
                    { 54, 3 },
                    { 56, 3 },
                    { 57, 3 },
                    { 58, 3 },
                    { 59, 3 },
                    { 60, 3 },
                    { 61, 3 },
                    { 62, 3 },
                    { 66, 3 },
                    { 69, 3 },
                    { 72, 3 },
                    { 117, 3 },
                    { 40, 3 },
                    { 121, 3 },
                    { 14, 4 },
                    { 18, 4 },
                    { 19, 4 },
                    { 21, 4 },
                    { 23, 4 },
                    { 24, 4 },
                    { 30, 4 },
                    { 32, 4 },
                    { 33, 4 },
                    { 34, 4 },
                    { 35, 4 },
                    { 36, 4 },
                    { 38, 4 },
                    { 39, 4 },
                    { 40, 4 },
                    { 41, 4 },
                    { 42, 4 },
                    { 43, 4 },
                    { 120, 3 },
                    { 13, 4 },
                    { 12, 4 },
                    { 44, 4 },
                    { 10, 4 },
                    { 123, 3 },
                    { 126, 3 },
                    { 127, 3 },
                    { 129, 3 },
                    { 133, 3 },
                    { 11, 4 },
                    { 135, 3 },
                    { 138, 3 },
                    { 140, 3 },
                    { 134, 3 },
                    { 144, 3 },
                    { 142, 3 },
                    { 5, 4 },
                    { 4, 4 },
                    { 3, 4 },
                    { 6, 4 },
                    { 149, 3 },
                    { 148, 3 },
                    { 145, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "ArticleKeyword",
                columns: new[] { "ArticleId", "KeywordId" },
                values: new object[,]
                {
                    { 76, 65 },
                    { 79, 65 },
                    { 81, 65 },
                    { 99, 65 },
                    { 111, 65 },
                    { 21, 66 },
                    { 22, 66 },
                    { 39, 66 },
                    { 130, 67 },
                    { 90, 66 },
                    { 145, 66 },
                    { 28, 67 },
                    { 36, 67 },
                    { 82, 67 },
                    { 90, 67 },
                    { 121, 67 },
                    { 123, 67 },
                    { 143, 62 },
                    { 80, 66 },
                    { 65, 65 },
                    { 10, 64 },
                    { 48, 65 },
                    { 141, 67 },
                    { 150, 62 },
                    { 9, 63 },
                    { 63, 63 },
                    { 70, 63 },
                    { 73, 63 },
                    { 85, 63 },
                    { 86, 63 },
                    { 93, 63 },
                    { 127, 63 },
                    { 141, 63 },
                    { 13, 64 },
                    { 21, 64 },
                    { 22, 64 },
                    { 36, 64 },
                    { 49, 64 },
                    { 59, 64 },
                    { 33, 65 },
                    { 39, 65 },
                    { 52, 65 },
                    { 17, 68 },
                    { 53, 71 },
                    { 49, 68 },
                    { 135, 71 },
                    { 13, 72 },
                    { 18, 72 },
                    { 32, 72 },
                    { 45, 72 },
                    { 85, 72 },
                    { 93, 72 },
                    { 110, 72 },
                    { 119, 72 },
                    { 128, 72 },
                    { 140, 72 },
                    { 16, 73 },
                    { 33, 73 },
                    { 40, 73 },
                    { 50, 73 },
                    { 58, 73 },
                    { 108, 73 },
                    { 149, 73 },
                    { 115, 62 },
                    { 123, 71 },
                    { 46, 68 },
                    { 117, 71 },
                    { 69, 71 },
                    { 70, 68 },
                    { 113, 68 },
                    { 40, 69 },
                    { 41, 69 },
                    { 55, 69 },
                    { 63, 69 },
                    { 126, 69 },
                    { 136, 69 },
                    { 138, 69 },
                    { 150, 69 },
                    { 6, 70 },
                    { 24, 70 },
                    { 33, 70 },
                    { 53, 70 },
                    { 55, 70 },
                    { 73, 70 },
                    { 88, 70 },
                    { 110, 70 },
                    { 116, 70 },
                    { 82, 71 },
                    { 94, 62 },
                    { 89, 50 },
                    { 46, 62 },
                    { 143, 53 },
                    { 144, 53 },
                    { 19, 54 },
                    { 39, 54 },
                    { 110, 54 },
                    { 146, 54 },
                    { 14, 55 },
                    { 15, 55 },
                    { 135, 53 },
                    { 26, 55 },
                    { 48, 55 },
                    { 49, 55 },
                    { 61, 55 },
                    { 68, 55 },
                    { 76, 55 },
                    { 98, 55 },
                    { 12, 56 },
                    { 19, 56 },
                    { 40, 55 },
                    { 134, 53 },
                    { 104, 53 },
                    { 103, 53 },
                    { 120, 50 },
                    { 130, 50 },
                    { 139, 50 },
                    { 147, 50 },
                    { 1, 51 },
                    { 60, 51 },
                    { 66, 51 },
                    { 82, 51 },
                    { 84, 51 },
                    { 104, 51 },
                    { 129, 51 },
                    { 132, 51 },
                    { 138, 51 },
                    { 89, 52 },
                    { 90, 52 },
                    { 128, 52 },
                    { 141, 52 },
                    { 21, 53 },
                    { 91, 53 },
                    { 32, 56 },
                    { 41, 56 },
                    { 52, 56 },
                    { 60, 56 },
                    { 123, 59 },
                    { 131, 59 },
                    { 133, 59 },
                    { 8, 60 },
                    { 60, 60 },
                    { 69, 60 },
                    { 122, 60 },
                    { 126, 60 },
                    { 6, 61 },
                    { 29, 61 },
                    { 54, 61 },
                    { 72, 61 },
                    { 74, 61 },
                    { 80, 61 },
                    { 106, 61 },
                    { 124, 61 },
                    { 127, 61 },
                    { 132, 61 },
                    { 32, 62 },
                    { 119, 59 },
                    { 69, 62 },
                    { 46, 59 },
                    { 57, 58 },
                    { 61, 56 },
                    { 118, 56 },
                    { 129, 56 },
                    { 132, 56 },
                    { 146, 56 },
                    { 4, 57 },
                    { 22, 57 },
                    { 26, 57 },
                    { 70, 57 },
                    { 104, 57 },
                    { 115, 57 },
                    { 123, 57 },
                    { 131, 57 },
                    { 136, 57 },
                    { 144, 57 },
                    { 8, 58 },
                    { 13, 58 },
                    { 45, 58 },
                    { 46, 58 },
                    { 116, 58 },
                    { 1, 74 },
                    { 90, 99 },
                    { 36, 74 },
                    { 102, 90 },
                    { 21, 91 },
                    { 60, 91 },
                    { 64, 91 },
                    { 70, 91 },
                    { 107, 91 },
                    { 117, 91 },
                    { 127, 91 },
                    { 48, 90 },
                    { 150, 91 },
                    { 28, 92 },
                    { 45, 92 },
                    { 50, 92 },
                    { 62, 92 },
                    { 73, 92 },
                    { 86, 92 },
                    { 112, 92 },
                    { 119, 92 },
                    { 13, 92 },
                    { 10, 90 },
                    { 84, 89 },
                    { 58, 89 },
                    { 32, 87 },
                    { 50, 87 },
                    { 80, 87 },
                    { 91, 87 },
                    { 110, 87 },
                    { 120, 87 },
                    { 125, 87 },
                    { 128, 87 },
                    { 20, 88 },
                    { 27, 88 },
                    { 43, 88 },
                    { 48, 88 },
                    { 61, 88 },
                    { 63, 88 },
                    { 90, 88 },
                    { 107, 88 },
                    { 128, 88 },
                    { 146, 88 },
                    { 28, 89 },
                    { 125, 92 },
                    { 20, 93 },
                    { 73, 93 },
                    { 95, 93 },
                    { 73, 96 },
                    { 54, 97 },
                    { 86, 97 },
                    { 92, 97 },
                    { 138, 97 },
                    { 1, 98 },
                    { 7, 98 },
                    { 37, 98 },
                    { 43, 98 },
                    { 57, 98 },
                    { 81, 98 },
                    { 101, 98 },
                    { 104, 98 },
                    { 124, 98 },
                    { 130, 98 },
                    { 19, 99 },
                    { 21, 99 },
                    { 48, 99 },
                    { 76, 50 },
                    { 54, 96 },
                    { 141, 86 },
                    { 39, 96 },
                    { 15, 96 },
                    { 104, 93 },
                    { 111, 93 },
                    { 134, 93 },
                    { 138, 93 },
                    { 146, 93 },
                    { 9, 94 },
                    { 44, 94 },
                    { 82, 94 },
                    { 95, 94 },
                    { 124, 94 },
                    { 129, 94 },
                    { 131, 94 },
                    { 6, 95 },
                    { 49, 95 },
                    { 61, 95 },
                    { 64, 95 },
                    { 122, 95 },
                    { 123, 95 },
                    { 3, 96 }
                });

            migrationBuilder.InsertData(
                table: "ArticleKeyword",
                columns: new[] { "ArticleId", "KeywordId" },
                values: new object[,]
                {
                    { 24, 96 },
                    { 121, 86 },
                    { 98, 86 },
                    { 61, 86 },
                    { 104, 77 },
                    { 111, 77 },
                    { 142, 77 },
                    { 32, 78 },
                    { 53, 78 },
                    { 81, 78 },
                    { 136, 78 },
                    { 50, 79 },
                    { 83, 79 },
                    { 101, 79 },
                    { 124, 79 },
                    { 127, 79 },
                    { 128, 79 },
                    { 141, 79 },
                    { 16, 80 },
                    { 17, 80 },
                    { 20, 80 },
                    { 27, 80 },
                    { 36, 80 },
                    { 97, 77 },
                    { 38, 80 },
                    { 64, 77 },
                    { 117, 76 },
                    { 39, 74 },
                    { 48, 74 },
                    { 100, 74 },
                    { 101, 74 },
                    { 28, 75 },
                    { 48, 75 },
                    { 54, 75 },
                    { 71, 75 },
                    { 84, 75 },
                    { 120, 75 },
                    { 125, 75 },
                    { 130, 75 },
                    { 139, 75 },
                    { 28, 76 },
                    { 55, 76 },
                    { 59, 76 },
                    { 71, 76 },
                    { 73, 76 },
                    { 80, 76 },
                    { 14, 77 },
                    { 18, 74 },
                    { 66, 80 },
                    { 94, 80 },
                    { 1, 84 },
                    { 2, 84 },
                    { 32, 84 },
                    { 55, 84 },
                    { 58, 84 },
                    { 85, 84 },
                    { 88, 84 },
                    { 91, 84 },
                    { 149, 84 },
                    { 37, 85 },
                    { 47, 85 },
                    { 66, 85 },
                    { 69, 85 },
                    { 73, 85 },
                    { 130, 85 },
                    { 148, 85 },
                    { 10, 86 },
                    { 13, 86 },
                    { 41, 86 },
                    { 125, 83 },
                    { 86, 80 },
                    { 115, 83 },
                    { 87, 83 },
                    { 8, 81 },
                    { 9, 81 },
                    { 41, 81 },
                    { 48, 81 },
                    { 65, 81 },
                    { 81, 81 },
                    { 84, 81 },
                    { 112, 81 },
                    { 133, 81 },
                    { 27, 82 },
                    { 85, 82 },
                    { 102, 82 },
                    { 130, 82 },
                    { 1, 83 },
                    { 30, 83 },
                    { 46, 83 },
                    { 51, 83 },
                    { 82, 83 },
                    { 83, 83 },
                    { 91, 83 },
                    { 72, 50 },
                    { 96, 25 },
                    { 40, 50 },
                    { 57, 17 },
                    { 91, 17 },
                    { 144, 17 },
                    { 148, 17 },
                    { 10, 18 },
                    { 19, 18 },
                    { 33, 18 },
                    { 61, 18 },
                    { 49, 17 },
                    { 76, 18 },
                    { 125, 18 },
                    { 22, 19 },
                    { 77, 19 },
                    { 88, 19 },
                    { 93, 19 },
                    { 109, 19 },
                    { 122, 19 },
                    { 139, 19 },
                    { 87, 18 },
                    { 46, 17 },
                    { 136, 16 },
                    { 127, 16 },
                    { 124, 12 },
                    { 6, 13 },
                    { 11, 13 },
                    { 24, 13 },
                    { 67, 13 },
                    { 86, 13 },
                    { 101, 13 },
                    { 43, 14 },
                    { 67, 14 },
                    { 82, 14 },
                    { 95, 14 },
                    { 2, 15 },
                    { 9, 15 },
                    { 82, 15 },
                    { 17, 16 },
                    { 95, 16 },
                    { 103, 16 },
                    { 121, 16 },
                    { 123, 16 },
                    { 142, 19 },
                    { 148, 19 },
                    { 13, 20 },
                    { 41, 20 },
                    { 53, 23 },
                    { 67, 23 },
                    { 110, 23 },
                    { 125, 23 },
                    { 134, 23 },
                    { 14, 24 },
                    { 33, 24 },
                    { 39, 24 },
                    { 47, 24 },
                    { 55, 24 },
                    { 59, 24 },
                    { 90, 24 },
                    { 137, 24 },
                    { 139, 24 },
                    { 11, 25 },
                    { 19, 25 },
                    { 22, 25 },
                    { 25, 25 },
                    { 45, 25 },
                    { 46, 23 },
                    { 96, 12 },
                    { 28, 23 },
                    { 10, 23 },
                    { 83, 20 },
                    { 86, 20 },
                    { 92, 20 },
                    { 98, 20 },
                    { 106, 20 },
                    { 107, 20 },
                    { 120, 20 },
                    { 127, 20 },
                    { 150, 20 },
                    { 36, 21 },
                    { 45, 21 },
                    { 80, 21 },
                    { 84, 21 },
                    { 138, 21 },
                    { 31, 22 },
                    { 35, 22 },
                    { 70, 22 },
                    { 107, 22 },
                    { 139, 22 },
                    { 11, 23 },
                    { 95, 12 },
                    { 75, 12 },
                    { 35, 12 },
                    { 146, 2 },
                    { 147, 2 },
                    { 6, 3 },
                    { 41, 3 },
                    { 70, 3 },
                    { 73, 3 },
                    { 132, 3 },
                    { 8, 4 },
                    { 40, 4 },
                    { 90, 4 },
                    { 130, 4 },
                    { 131, 4 },
                    { 28, 5 },
                    { 37, 5 },
                    { 50, 5 },
                    { 64, 5 },
                    { 80, 5 },
                    { 86, 5 },
                    { 90, 5 },
                    { 143, 2 },
                    { 95, 5 },
                    { 141, 2 },
                    { 131, 2 },
                    { 124, 99 },
                    { 11, 1 },
                    { 14, 1 },
                    { 18, 1 },
                    { 32, 1 },
                    { 87, 1 },
                    { 97, 1 },
                    { 103, 1 },
                    { 126, 1 },
                    { 149, 1 },
                    { 18, 2 },
                    { 21, 2 },
                    { 24, 2 },
                    { 33, 2 },
                    { 45, 2 },
                    { 69, 2 },
                    { 98, 2 },
                    { 112, 2 },
                    { 119, 2 },
                    { 135, 2 },
                    { 71, 25 },
                    { 104, 5 },
                    { 114, 5 },
                    { 2, 9 },
                    { 39, 9 },
                    { 40, 9 },
                    { 41, 9 },
                    { 105, 9 },
                    { 1, 10 },
                    { 23, 10 },
                    { 42, 10 },
                    { 43, 10 },
                    { 57, 10 },
                    { 71, 10 },
                    { 91, 10 },
                    { 118, 10 },
                    { 125, 10 },
                    { 129, 10 },
                    { 45, 11 },
                    { 119, 11 },
                    { 123, 11 },
                    { 22, 12 },
                    { 130, 8 },
                    { 108, 5 },
                    { 121, 8 },
                    { 78, 8 },
                    { 116, 5 },
                    { 136, 5 },
                    { 138, 5 },
                    { 139, 5 },
                    { 38, 6 },
                    { 42, 6 },
                    { 43, 6 },
                    { 55, 6 },
                    { 89, 6 },
                    { 94, 6 },
                    { 141, 6 },
                    { 33, 7 },
                    { 43, 7 },
                    { 71, 7 },
                    { 81, 7 },
                    { 127, 7 },
                    { 129, 7 },
                    { 28, 8 },
                    { 30, 8 },
                    { 102, 8 },
                    { 59, 50 },
                    { 82, 25 },
                    { 121, 25 },
                    { 6, 42 },
                    { 24, 42 },
                    { 33, 42 },
                    { 55, 42 },
                    { 83, 42 },
                    { 102, 42 },
                    { 148, 42 },
                    { 11, 43 },
                    { 146, 41 },
                    { 14, 43 },
                    { 39, 43 },
                    { 40, 43 },
                    { 95, 43 },
                    { 107, 43 },
                    { 116, 43 },
                    { 129, 43 },
                    { 150, 43 },
                    { 14, 44 },
                    { 16, 43 },
                    { 106, 41 },
                    { 71, 41 },
                    { 66, 41 },
                    { 22, 39 },
                    { 30, 39 },
                    { 55, 39 },
                    { 63, 39 },
                    { 75, 39 },
                    { 142, 39 },
                    { 145, 39 },
                    { 17, 40 },
                    { 19, 40 },
                    { 56, 40 },
                    { 81, 40 },
                    { 106, 40 },
                    { 150, 40 },
                    { 8, 41 },
                    { 9, 41 },
                    { 13, 41 },
                    { 36, 41 },
                    { 39, 41 },
                    { 52, 41 },
                    { 85, 44 },
                    { 110, 44 },
                    { 123, 44 },
                    { 131, 44 },
                    { 34, 48 },
                    { 50, 48 },
                    { 66, 48 },
                    { 69, 48 },
                    { 75, 48 },
                    { 96, 48 },
                    { 106, 48 },
                    { 108, 48 },
                    { 129, 48 },
                    { 138, 48 },
                    { 4, 49 },
                    { 12, 49 },
                    { 27, 49 },
                    { 32, 49 },
                    { 94, 49 },
                    { 110, 49 },
                    { 117, 49 },
                    { 24, 50 },
                    { 27, 50 },
                    { 150, 47 },
                    { 13, 39 },
                    { 139, 47 },
                    { 128, 47 },
                    { 139, 44 },
                    { 6, 45 },
                    { 18, 45 },
                    { 37, 45 },
                    { 51, 45 },
                    { 71, 45 },
                    { 126, 45 },
                    { 137, 45 },
                    { 150, 45 },
                    { 1, 46 },
                    { 35, 46 },
                    { 48, 46 },
                    { 53, 46 },
                    { 70, 46 },
                    { 85, 46 },
                    { 58, 47 },
                    { 93, 47 },
                    { 120, 47 },
                    { 125, 47 },
                    { 138, 47 },
                    { 5, 39 },
                    { 146, 38 },
                    { 131, 38 },
                    { 53, 29 },
                    { 55, 29 },
                    { 111, 29 },
                    { 127, 29 },
                    { 128, 29 },
                    { 148, 29 },
                    { 36, 30 },
                    { 80, 30 },
                    { 91, 30 },
                    { 93, 30 },
                    { 95, 30 },
                    { 127, 30 },
                    { 46, 31 },
                    { 107, 31 },
                    { 130, 31 },
                    { 1, 32 },
                    { 14, 32 },
                    { 84, 32 },
                    { 86, 32 },
                    { 31, 29 },
                    { 107, 32 },
                    { 141, 28 },
                    { 84, 28 },
                    { 144, 25 },
                    { 150, 25 },
                    { 9, 26 },
                    { 10, 26 },
                    { 17, 26 },
                    { 65, 26 },
                    { 78, 26 },
                    { 106, 26 },
                    { 113, 26 },
                    { 129, 26 },
                    { 2, 27 },
                    { 54, 27 },
                    { 61, 27 },
                    { 94, 27 },
                    { 4, 28 },
                    { 53, 28 },
                    { 58, 28 },
                    { 77, 28 },
                    { 82, 28 },
                    { 112, 28 },
                    { 87, 25 },
                    { 137, 32 },
                    { 13, 33 },
                    { 73, 36 },
                    { 87, 36 },
                    { 103, 36 },
                    { 122, 36 },
                    { 129, 36 },
                    { 131, 36 },
                    { 24, 37 },
                    { 29, 37 },
                    { 58, 37 },
                    { 69, 37 },
                    { 108, 37 },
                    { 114, 37 },
                    { 118, 37 },
                    { 124, 37 },
                    { 128, 37 },
                    { 131, 37 },
                    { 36, 38 },
                    { 37, 38 },
                    { 125, 38 },
                    { 70, 36 },
                    { 138, 32 },
                    { 69, 36 },
                    { 22, 36 },
                    { 22, 33 },
                    { 64, 33 },
                    { 86, 33 },
                    { 146, 33 },
                    { 6, 34 },
                    { 38, 34 },
                    { 46, 34 },
                    { 53, 34 },
                    { 87, 34 },
                    { 114, 34 },
                    { 28, 35 },
                    { 40, 35 },
                    { 51, 35 },
                    { 54, 35 },
                    { 61, 35 },
                    { 69, 35 },
                    { 87, 35 },
                    { 139, 35 },
                    { 1, 36 },
                    { 37, 36 },
                    { 128, 99 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 13, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 13, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 14, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 15, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 16, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 18, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 19, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 19, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 19, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 20, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 20, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 20, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 21, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 23, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 23, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 23, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 24, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 24, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 24, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 25, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 26, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 27, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 28, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 28, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 28, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 28, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 28, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 29, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 30, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 30, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 31, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 31, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 31, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 32, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 33, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 33, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 33, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 33, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 33, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 34, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 35, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 36, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 37, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 37, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 37, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 37, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 37, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 38, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 38, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 38, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 38, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 39, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 40, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 40, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 40, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 40, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 40, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 40, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 41, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 42, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 42, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 42, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 42, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 43, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 43, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 43, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 43, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 43, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 43, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 44, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 44, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 44, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 44, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 45, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 46, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 47, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 47, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 47, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 47, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 47, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 48, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 48, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 48, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 48, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 48, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 48, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 49, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 49, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 49, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 49, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 49, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 50, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 51, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 51, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 51, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 51, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 51, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 52, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 53, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 53, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 53, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 53, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 54, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 54, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 54, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 54, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 54, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 54, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 55, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 55, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 56, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 57, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 58, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 58, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 59, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 60, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 60, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 60, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 61, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 62, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 63, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 63, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 63, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 64, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 64, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 64, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 64, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 65, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 65, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 65, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 66, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 67, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 67, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 67, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 67, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 67, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 67, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 68, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 68, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 68, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 69, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 69, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 70, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 71, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 72, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 73, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 73, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 73, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 73, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 73, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 74, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 75, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 75, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 75, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 75, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 75, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 76, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 76, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 76, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 76, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 76, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 76, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 77, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 78, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 78, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 78, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 78, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 78, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 79, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 80, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 81, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 81, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 81, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 81, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 81, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 81, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 82, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 83, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 84, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 85, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 85, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 85, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 86, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 86, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 86, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 86, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 86, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 86, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 87, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 88, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 89, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 89, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 89, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 89, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 89, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 90, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 91, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 91, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 91, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 91, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 91, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 92, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 93, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 94, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 95, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 95, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 95, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 95, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 95, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 96, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 97, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 97, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 97, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 97, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 97, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 97, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 98, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 98, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 98, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 98, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 99, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 99, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 100, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 100, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 101, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 101, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 101, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 101, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 101, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 102, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 103, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 104, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 104, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 104, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 105, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 106, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 106, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 106, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 106, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 107, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 107, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 107, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 107, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 108, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 108, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 108, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 108, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 109, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 110, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 111, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 112, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 113, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 113, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 113, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 114, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 114, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 114, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 114, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 115, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 115, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 115, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 116, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 117, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 117, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 117, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 117, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 117, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 117, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 118, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 119, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 119, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 119, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 120, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 121, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 121, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 121, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 121, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 122, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 123, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 123, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 123, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 123, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 123, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 123, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 124, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 124, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 124, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 124, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 124, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 124, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 125, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 125, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 125, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 126, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 126, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 126, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 127, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 127, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 127, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 127, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 127, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 128, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 129, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 129, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 129, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 129, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 129, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 129, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 130, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 130, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 130, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 130, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 131, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 131, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 131, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 131, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 131, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 131, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 132, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 132, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 132, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 132, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 133, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 133, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 133, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 133, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 133, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 133, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 134, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 135, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 136, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 136, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 137, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 138, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 138, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 138, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 138, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 138, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 139, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 140, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 140, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 141, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 142, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 142, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 142, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 142, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 142, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 143, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 144, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 145, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 146, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 146, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 147, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 147, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 147, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 148, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 148, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 148, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 148, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 149, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 150, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumns: new[] { "ArticleId", "CategoryId" },
                keyValues: new object[] { 150, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 46 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 1, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 2, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 3, 96 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 4, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 4, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 4, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 5, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 34 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 6, 95 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 7, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 8, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 8, 58 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 8, 60 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 8, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 9, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 9, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 9, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 9, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 9, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 10, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 10, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 10, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 10, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 10, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 10, 90 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 11, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 11, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 11, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 11, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 12, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 12, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 33 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 58 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 13, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 44 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 14, 77 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 15, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 15, 96 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 16, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 16, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 16, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 17, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 17, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 17, 40 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 17, 68 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 17, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 18, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 18, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 18, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 19, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 19, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 19, 40 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 19, 54 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 19, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 19, 99 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 20, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 20, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 20, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 21, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 21, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 21, 66 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 21, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 21, 99 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 33 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 22, 66 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 23, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 24, 96 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 25, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 26, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 26, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 27, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 27, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 27, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 27, 82 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 27, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 89 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 28, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 29, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 29, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 30, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 30, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 30, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 31, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 31, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 78 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 32, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 33, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 34, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 35, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 35, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 35, 46 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 21 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 30 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 38 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 36, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 37, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 37, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 37, 38 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 37, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 37, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 37, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 38, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 38, 34 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 38, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 54 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 66 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 39, 96 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 40, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 41, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 42, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 42, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 43, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 43, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 43, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 43, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 43, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 43, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 44, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 11 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 21 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 58 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 45, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 31 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 34 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 58 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 59 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 68 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 46, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 47, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 47, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 46 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 90 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 48, 99 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 49, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 49, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 49, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 49, 68 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 49, 95 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 50, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 50, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 50, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 50, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 50, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 50, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 51, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 51, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 51, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 52, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 52, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 52, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 34 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 46 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 71 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 53, 78 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 54, 27 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 54, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 54, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 54, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 54, 96 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 54, 97 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 55, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 56, 40 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 57, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 57, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 57, 58 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 57, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 58, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 58, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 58, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 58, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 58, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 58, 89 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 59, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 59, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 59, 64 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 59, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 60, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 60, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 60, 60 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 60, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 27 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 61, 95 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 62, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 63, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 63, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 63, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 63, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 64, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 64, 33 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 64, 77 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 64, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 64, 95 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 65, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 65, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 65, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 66, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 66, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 66, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 66, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 66, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 67, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 67, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 67, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 68, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 60 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 71 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 69, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 46 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 68 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 70, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 71, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 72, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 72, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 73, 96 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 74, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 75, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 75, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 75, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 76, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 76, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 76, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 76, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 77, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 77, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 78, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 78, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 79, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 21 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 30 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 66 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 80, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 81, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 81, 40 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 81, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 81, 78 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 81, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 81, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 15 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 71 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 82, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 83, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 83, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 83, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 83, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 21 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 84, 89 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 85, 44 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 85, 46 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 85, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 85, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 85, 82 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 85, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 33 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 86, 97 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 34 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 87, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 88, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 88, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 88, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 89, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 89, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 89, 52 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 52 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 66 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 90, 99 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 30 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 91, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 92, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 92, 97 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 93, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 93, 30 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 93, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 93, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 93, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 94, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 94, 27 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 94, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 94, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 94, 80 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 30 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 95, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 96, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 96, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 96, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 97, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 97, 77 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 98, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 98, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 98, 55 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 98, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 99, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 100, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 101, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 101, 74 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 101, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 101, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 102, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 102, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 102, 82 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 102, 90 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 103, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 103, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 103, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 103, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 77 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 104, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 105, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 106, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 106, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 106, 40 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 106, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 106, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 106, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 31 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 107, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 108, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 108, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 108, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 108, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 109, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 44 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 54 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 110, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 111, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 111, 65 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 111, 77 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 111, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 112, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 112, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 112, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 112, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 113, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 113, 68 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 114, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 114, 34 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 114, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 115, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 115, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 115, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 116, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 116, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 116, 58 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 116, 70 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 117, 49 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 117, 71 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 117, 76 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 117, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 118, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 118, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 118, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 119, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 119, 11 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 119, 59 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 119, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 119, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 120, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 120, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 120, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 120, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 120, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 121, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 121, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 121, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 121, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 121, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 122, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 122, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 122, 60 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 122, 95 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 11 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 44 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 59 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 71 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 123, 95 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 124, 99 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 38 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 83 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 125, 92 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 126, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 126, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 126, 60 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 126, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 30 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 127, 91 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 52 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 87 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 128, 99 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 26 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 129, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 31 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 82 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 130, 98 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 36 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 37 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 38 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 44 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 59 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 131, 94 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 132, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 132, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 132, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 132, 61 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 133, 59 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 133, 81 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 134, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 134, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 134, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 135, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 135, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 135, 71 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 136, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 136, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 136, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 136, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 136, 78 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 137, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 137, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 137, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 21 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 32 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 48 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 51 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 138, 97 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 35 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 44 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 139, 75 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 140, 72 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 28 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 52 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 63 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 67 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 79 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 141, 86 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 142, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 142, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 142, 77 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 143, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 143, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 143, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 144, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 144, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 144, 53 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 144, 57 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 145, 39 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 145, 66 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 33 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 38 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 41 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 54 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 56 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 88 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 146, 93 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 147, 2 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 147, 50 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 148, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 148, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 148, 29 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 148, 42 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 148, 85 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 149, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 149, 73 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 149, 84 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 40 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 43 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 45 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 47 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 62 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 69 });

            migrationBuilder.DeleteData(
                table: "ArticleKeyword",
                keyColumns: new[] { "ArticleId", "KeywordId" },
                keyValues: new object[] { 150, 91 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Articles");
        }
    }
}
