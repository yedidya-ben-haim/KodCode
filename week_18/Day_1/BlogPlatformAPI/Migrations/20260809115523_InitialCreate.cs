using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogPlatformAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JoinedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsPublished = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommenterName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Email", "FullName", "JoinedDate" },
                values: new object[,]
                {
                    { 1, "author1@test.com", "Author 1", new DateTime(2026, 7, 30, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6610) },
                    { 2, "author2@test.com", "Author 2", new DateTime(2026, 7, 20, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6680) },
                    { 3, "author3@test.com", "Author 3", new DateTime(2026, 7, 10, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6690) },
                    { 4, "author4@test.com", "Author 4", new DateTime(2026, 6, 30, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6690) },
                    { 5, "author5@test.com", "Author 5", new DateTime(2026, 6, 20, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6690) }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "IsPublished", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "This is a dummy post body.", true, new DateTime(2026, 8, 8, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6730), "Post 1 by Author 1" },
                    { 2, 1, "This is a dummy post body.", true, new DateTime(2026, 8, 7, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6740), "Post 2 by Author 1" },
                    { 3, 1, "This is a dummy post body.", true, new DateTime(2026, 8, 6, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6740), "Post 3 by Author 1" },
                    { 4, 1, "This is a dummy post body.", true, new DateTime(2026, 8, 5, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6740), "Post 4 by Author 1" },
                    { 5, 1, "This is a dummy post body.", true, new DateTime(2026, 8, 4, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6740), "Post 5 by Author 1" },
                    { 6, 2, "This is a dummy post body.", true, new DateTime(2026, 8, 3, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6740), "Post 6 by Author 2" },
                    { 7, 2, "This is a dummy post body.", true, new DateTime(2026, 8, 2, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6750), "Post 7 by Author 2" },
                    { 8, 2, "This is a dummy post body.", true, new DateTime(2026, 8, 1, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6750), "Post 8 by Author 2" },
                    { 9, 2, "This is a dummy post body.", true, new DateTime(2026, 7, 31, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6750), "Post 9 by Author 2" },
                    { 10, 2, "This is a dummy post body.", true, new DateTime(2026, 7, 30, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6750), "Post 10 by Author 2" },
                    { 11, 3, "This is a dummy post body.", true, new DateTime(2026, 7, 29, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6750), "Post 11 by Author 3" },
                    { 12, 3, "This is a dummy post body.", true, new DateTime(2026, 7, 28, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6760), "Post 12 by Author 3" },
                    { 13, 3, "This is a dummy post body.", true, new DateTime(2026, 7, 27, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6760), "Post 13 by Author 3" },
                    { 14, 3, "This is a dummy post body.", true, new DateTime(2026, 7, 26, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6760), "Post 14 by Author 3" },
                    { 15, 3, "This is a dummy post body.", true, new DateTime(2026, 7, 25, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6760), "Post 15 by Author 3" },
                    { 16, 4, "This is a dummy post body.", true, new DateTime(2026, 7, 24, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6760), "Post 16 by Author 4" },
                    { 17, 4, "This is a dummy post body.", true, new DateTime(2026, 7, 23, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6760), "Post 17 by Author 4" },
                    { 18, 4, "This is a dummy post body.", true, new DateTime(2026, 7, 22, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6770), "Post 18 by Author 4" },
                    { 19, 4, "This is a dummy post body.", true, new DateTime(2026, 7, 21, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6770), "Post 19 by Author 4" },
                    { 20, 4, "This is a dummy post body.", true, new DateTime(2026, 7, 20, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6770), "Post 20 by Author 4" },
                    { 21, 5, "This is a dummy post body.", true, new DateTime(2026, 7, 19, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6770), "Post 21 by Author 5" },
                    { 22, 5, "This is a dummy post body.", true, new DateTime(2026, 7, 18, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6770), "Post 22 by Author 5" },
                    { 23, 5, "This is a dummy post body.", true, new DateTime(2026, 7, 17, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6770), "Post 23 by Author 5" },
                    { 24, 5, "This is a dummy post body.", true, new DateTime(2026, 7, 16, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6780), "Post 24 by Author 5" },
                    { 25, 5, "This is a dummy post body.", true, new DateTime(2026, 7, 15, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6780), "Post 25 by Author 5" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommenterName", "CreatedAt", "PostId", "Text" },
                values: new object[,]
                {
                    { 1, "Reader 1", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6800), 1, "Great post number 1!" },
                    { 2, "Reader 2", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6800), 1, "Great post number 1!" },
                    { 3, "Reader 3", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6810), 1, "Great post number 1!" },
                    { 4, "Reader 4", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6810), 2, "Great post number 2!" },
                    { 5, "Reader 5", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6810), 2, "Great post number 2!" },
                    { 6, "Reader 6", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6810), 2, "Great post number 2!" },
                    { 7, "Reader 7", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6810), 3, "Great post number 3!" },
                    { 8, "Reader 8", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6820), 3, "Great post number 3!" },
                    { 9, "Reader 9", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6820), 3, "Great post number 3!" },
                    { 10, "Reader 10", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6820), 4, "Great post number 4!" },
                    { 11, "Reader 11", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6820), 4, "Great post number 4!" },
                    { 12, "Reader 12", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6820), 4, "Great post number 4!" },
                    { 13, "Reader 13", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6830), 5, "Great post number 5!" },
                    { 14, "Reader 14", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6830), 5, "Great post number 5!" },
                    { 15, "Reader 15", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6830), 5, "Great post number 5!" },
                    { 16, "Reader 16", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6840), 6, "Great post number 6!" },
                    { 17, "Reader 17", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6840), 6, "Great post number 6!" },
                    { 18, "Reader 18", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6840), 6, "Great post number 6!" },
                    { 19, "Reader 19", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6840), 7, "Great post number 7!" },
                    { 20, "Reader 20", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6840), 7, "Great post number 7!" },
                    { 21, "Reader 21", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6850), 7, "Great post number 7!" },
                    { 22, "Reader 22", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6850), 8, "Great post number 8!" },
                    { 23, "Reader 23", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6850), 8, "Great post number 8!" },
                    { 24, "Reader 24", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6850), 8, "Great post number 8!" },
                    { 25, "Reader 25", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6850), 9, "Great post number 9!" },
                    { 26, "Reader 26", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6860), 9, "Great post number 9!" },
                    { 27, "Reader 27", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6860), 9, "Great post number 9!" },
                    { 28, "Reader 28", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6860), 10, "Great post number 10!" },
                    { 29, "Reader 29", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6860), 10, "Great post number 10!" },
                    { 30, "Reader 30", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6860), 10, "Great post number 10!" },
                    { 31, "Reader 31", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6870), 11, "Great post number 11!" },
                    { 32, "Reader 32", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6870), 11, "Great post number 11!" },
                    { 33, "Reader 33", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6870), 11, "Great post number 11!" },
                    { 34, "Reader 34", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6870), 12, "Great post number 12!" },
                    { 35, "Reader 35", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6870), 12, "Great post number 12!" },
                    { 36, "Reader 36", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6880), 12, "Great post number 12!" },
                    { 37, "Reader 37", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6880), 13, "Great post number 13!" },
                    { 38, "Reader 38", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6880), 13, "Great post number 13!" },
                    { 39, "Reader 39", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6880), 13, "Great post number 13!" },
                    { 40, "Reader 40", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6880), 14, "Great post number 14!" },
                    { 41, "Reader 41", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6890), 14, "Great post number 14!" },
                    { 42, "Reader 42", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6890), 14, "Great post number 14!" },
                    { 43, "Reader 43", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6890), 15, "Great post number 15!" },
                    { 44, "Reader 44", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6890), 15, "Great post number 15!" },
                    { 45, "Reader 45", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6890), 15, "Great post number 15!" },
                    { 46, "Reader 46", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6900), 16, "Great post number 16!" },
                    { 47, "Reader 47", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6900), 16, "Great post number 16!" },
                    { 48, "Reader 48", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6900), 16, "Great post number 16!" },
                    { 49, "Reader 49", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6900), 17, "Great post number 17!" },
                    { 50, "Reader 50", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6900), 17, "Great post number 17!" },
                    { 51, "Reader 51", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6910), 17, "Great post number 17!" },
                    { 52, "Reader 52", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6910), 18, "Great post number 18!" },
                    { 53, "Reader 53", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6910), 18, "Great post number 18!" },
                    { 54, "Reader 54", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6910), 18, "Great post number 18!" },
                    { 55, "Reader 55", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6910), 19, "Great post number 19!" },
                    { 56, "Reader 56", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6920), 19, "Great post number 19!" },
                    { 57, "Reader 57", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6920), 19, "Great post number 19!" },
                    { 58, "Reader 58", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6920), 20, "Great post number 20!" },
                    { 59, "Reader 59", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6920), 20, "Great post number 20!" },
                    { 60, "Reader 60", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6920), 20, "Great post number 20!" },
                    { 61, "Reader 61", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6940), 21, "Great post number 21!" },
                    { 62, "Reader 62", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6940), 21, "Great post number 21!" },
                    { 63, "Reader 63", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6940), 21, "Great post number 21!" },
                    { 64, "Reader 64", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6940), 22, "Great post number 22!" },
                    { 65, "Reader 65", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6940), 22, "Great post number 22!" },
                    { 66, "Reader 66", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6950), 22, "Great post number 22!" },
                    { 67, "Reader 67", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6950), 23, "Great post number 23!" },
                    { 68, "Reader 68", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6950), 23, "Great post number 23!" },
                    { 69, "Reader 69", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6950), 23, "Great post number 23!" },
                    { 70, "Reader 70", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6950), 24, "Great post number 24!" },
                    { 71, "Reader 71", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6960), 24, "Great post number 24!" },
                    { 72, "Reader 72", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6960), 24, "Great post number 24!" },
                    { 73, "Reader 73", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6960), 25, "Great post number 25!" },
                    { 74, "Reader 74", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6960), 25, "Great post number 25!" },
                    { 75, "Reader 75", new DateTime(2026, 8, 9, 14, 55, 23, 788, DateTimeKind.Local).AddTicks(6960), 25, "Great post number 25!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
