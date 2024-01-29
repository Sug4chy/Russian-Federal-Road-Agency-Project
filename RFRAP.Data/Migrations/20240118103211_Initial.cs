using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "road",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastlyEditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_road", x => x.Id);
                    table.UniqueConstraint("AK_road_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "segment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Point1 = table.Column<NpgsqlPoint>(type: "point", nullable: false),
                    Point2 = table.Column<NpgsqlPoint>(type: "point", nullable: false),
                    RoadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastlyEditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_segment_road_RoadId",
                        column: x => x.RoadId,
                        principalTable: "road",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gas_station",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Coordinates = table.Column<NpgsqlPoint>(type: "point", nullable: false),
                    SegmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastlyEditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gas_station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gas_station_segment_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "segment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unverified_point",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Coordinates = table.Column<NpgsqlPoint>(type: "point", nullable: false),
                    FileReference = table.Column<string>(type: "text", nullable: true),
                    SegmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastlyEditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unverified_point", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unverified_point_segment_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "segment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gas_station_SegmentId",
                table: "gas_station",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_segment_RoadId",
                table: "segment",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_unverified_point_SegmentId",
                table: "unverified_point",
                column: "SegmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gas_station");

            migrationBuilder.DropTable(
                name: "unverified_point");

            migrationBuilder.DropTable(
                name: "segment");

            migrationBuilder.DropTable(
                name: "road");
        }
    }
}
