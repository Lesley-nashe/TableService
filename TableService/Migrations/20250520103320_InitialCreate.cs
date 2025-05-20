using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableItems",
                columns: table => new
                {
                    TableId = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableItems", x => x.TableId);
                });

            migrationBuilder.InsertData(
                table: "TableItems",
                columns: new[] { "TableId", "Available", "Capacity", "Location" },
                values: new object[,]
                {
                    { "T001", true, 4, "Window" },
                    { "T002", false, 2, "Corner" },
                    { "T003", true, 6, "Center" },
                    { "T004", false, 6, "Balcony" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableItems");
        }
    }
}
