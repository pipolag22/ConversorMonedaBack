using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "monedasDefault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monedasDefault", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Contrasenia = table.Column<string>(type: "TEXT", nullable: false),
                    Suscripcion = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalConversiones = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favoritas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritas_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monedasUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monedasUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_monedasUser_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "monedasDefault",
                columns: new[] { "Id", "IC", "Leyenda", "Simbolo" },
                values: new object[,]
                {
                    { 1, 0.002, "Peso Argentino", "Ars$" },
                    { 2, 1.0, "Dolar Americano", "Usd$" },
                    { 4, 1.0900000000000001, "Euro", "Eur$" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritas_UserId",
                table: "Favoritas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_monedasUser_UserId",
                table: "monedasUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritas");

            migrationBuilder.DropTable(
                name: "monedasDefault");

            migrationBuilder.DropTable(
                name: "monedasUser");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
