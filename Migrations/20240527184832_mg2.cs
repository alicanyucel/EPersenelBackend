using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonelApp.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personels",
                columns: new[] { "Id", "FirstName", "LastName", "StartingDate" },
                values: new object[,]
                {
                    { new Guid("80cc7bd2-1fec-474a-b3bd-0b847014fab1"), "Taner", "Saydam", new DateOnly(2024, 5, 27) },
                    { new Guid("e3e67fac-5791-459a-8bc0-4371b43de239"), "Toprak", "Saydam", new DateOnly(2024, 5, 27) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personels",
                keyColumn: "Id",
                keyValue: new Guid("80cc7bd2-1fec-474a-b3bd-0b847014fab1"));

            migrationBuilder.DeleteData(
                table: "Personels",
                keyColumn: "Id",
                keyValue: new Guid("e3e67fac-5791-459a-8bc0-4371b43de239"));
        }
    }
}
