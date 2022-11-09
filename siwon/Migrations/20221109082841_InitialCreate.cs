using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace siwon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreateDate", "Title" },
                values: new object[,]
                {
                    { 1, "Henryk Sienkiewicz", new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1298), "W pustyni i w puszczy" },
                    { 2, "Adam Mickiewicz", new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1334), "Pan Tadeusz" },
                    { 3, "Adam Mickiewicz", new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1336), "Dziady" },
                    { 4, "Bolesław Prus", new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1338), "Lalka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
