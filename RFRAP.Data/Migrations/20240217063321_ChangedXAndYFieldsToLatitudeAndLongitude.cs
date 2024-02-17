using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedXAndYFieldsToLatitudeAndLongitude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "unverified_point");

            migrationBuilder.DropColumn(
                name: "Point1",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "Point2",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "gas_station");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "unverified_point",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "unverified_point",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude1",
                table: "segment",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude2",
                table: "segment",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude1",
                table: "segment",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude2",
                table: "segment",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "gas_station",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "gas_station",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "unverified_point");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "unverified_point");

            migrationBuilder.DropColumn(
                name: "Latitude1",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "Latitude2",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "Longitude1",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "Longitude2",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "gas_station");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "gas_station");

            migrationBuilder.AddColumn<NpgsqlPoint>(
                name: "Coordinates",
                table: "unverified_point",
                type: "point",
                nullable: false,
                defaultValue: new NpgsqlTypes.NpgsqlPoint(0.0, 0.0));

            migrationBuilder.AddColumn<NpgsqlPoint>(
                name: "Point1",
                table: "segment",
                type: "point",
                nullable: false,
                defaultValue: new NpgsqlTypes.NpgsqlPoint(0.0, 0.0));

            migrationBuilder.AddColumn<NpgsqlPoint>(
                name: "Point2",
                table: "segment",
                type: "point",
                nullable: false,
                defaultValue: new NpgsqlTypes.NpgsqlPoint(0.0, 0.0));

            migrationBuilder.AddColumn<NpgsqlPoint>(
                name: "Coordinates",
                table: "gas_station",
                type: "point",
                nullable: false,
                defaultValue: new NpgsqlTypes.NpgsqlPoint(0.0, 0.0));
        }
    }
}
