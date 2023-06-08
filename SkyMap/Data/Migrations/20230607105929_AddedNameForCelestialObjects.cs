using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyMap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNameForCelestialObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CelestialObjects",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CelestialObjects");
        }
    }
}
