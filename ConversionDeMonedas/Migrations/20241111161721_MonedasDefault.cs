using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class MonedasDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "monedasDefault",
                columns: new[] { "Id", "IC", "Leyenda", "Simbolo" },
                values: new object[,]
                {
                    { 3, 0.042999999999999997, "CoroaCheca", "KC" },
                    { 5, 1.2E-05, "Bictoin", "Btc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "monedasDefault",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "monedasDefault",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
