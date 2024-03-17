using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added2MoreDefaultGasStations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "verified_point",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude", "Longitude", "Name", "SegmentId", "Type" },
                values: new object[,]
                {
                    { new Guid("3e6a6163-082e-4fa8-a632-7d3360b9d826"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 55.010850387932749, 61.257548157714069, "Salavat", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("75df5128-4df2-4e88-b368-094f64df4a9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54.951769053652228, 60.869138434859998, "Газпромнефть", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("3e6a6163-082e-4fa8-a632-7d3360b9d826"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("75df5128-4df2-4e88-b368-094f64df4a9c"));
        }
    }
}
