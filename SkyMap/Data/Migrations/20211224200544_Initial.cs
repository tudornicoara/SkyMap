using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyMap.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelestialObjectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoverySourceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoverySources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiscoverySourceTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StateOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscoverySources_DiscoverySourceTypes_DiscoverySourceTypeId",
                        column: x => x.DiscoverySourceTypeId,
                        principalTable: "DiscoverySourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Mass = table.Column<string>(type: "TEXT", nullable: true),
                    EquatorialDiameter = table.Column<string>(type: "TEXT", nullable: true),
                    DiscoveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiscoverySourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CelestialObjectTypeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialObjects_CelestialObjectTypes_CelestialObjectTypeId",
                        column: x => x.CelestialObjectTypeId,
                        principalTable: "CelestialObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelestialObjects_DiscoverySources_DiscoverySourceId",
                        column: x => x.DiscoverySourceId,
                        principalTable: "DiscoverySources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObjects_CelestialObjectTypeId",
                table: "CelestialObjects",
                column: "CelestialObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObjects_DiscoverySourceId",
                table: "CelestialObjects",
                column: "DiscoverySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscoverySources_DiscoverySourceTypeId",
                table: "DiscoverySources",
                column: "DiscoverySourceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialObjects");

            migrationBuilder.DropTable(
                name: "CelestialObjectTypes");

            migrationBuilder.DropTable(
                name: "DiscoverySources");

            migrationBuilder.DropTable(
                name: "DiscoverySourceTypes");
        }
    }
}
