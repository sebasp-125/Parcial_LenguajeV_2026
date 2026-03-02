using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Shoes_v1.Migrations
{
    /// <inheritdoc />
    public partial class AutoIncrementIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wokers",
                table: "Wokers");

            migrationBuilder.RenameTable(
                name: "Wokers",
                newName: "Workers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Wokers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wokers",
                table: "Wokers",
                column: "Id");
        }
    }
}
