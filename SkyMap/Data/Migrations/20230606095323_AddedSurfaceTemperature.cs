using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyMap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSurfaceTemperature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelestialObjects_CelestialObjectTypes_CelestialObjectTypeId",
                table: "CelestialObjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "CelestialObjectTypeId",
                table: "CelestialObjects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "SurfaceTemperature",
                table: "CelestialObjects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialObjects_CelestialObjectTypes_CelestialObjectTypeId",
                table: "CelestialObjects",
                column: "CelestialObjectTypeId",
                principalTable: "CelestialObjectTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelestialObjects_CelestialObjectTypes_CelestialObjectTypeId",
                table: "CelestialObjects");

            migrationBuilder.DropColumn(
                name: "SurfaceTemperature",
                table: "CelestialObjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "CelestialObjectTypeId",
                table: "CelestialObjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialObjects_CelestialObjectTypes_CelestialObjectTypeId",
                table: "CelestialObjects",
                column: "CelestialObjectTypeId",
                principalTable: "CelestialObjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
