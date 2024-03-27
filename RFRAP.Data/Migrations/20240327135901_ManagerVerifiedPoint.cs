using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManagerVerifiedPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_verified_point_segment_SegmentId",
                table: "verified_point");

            migrationBuilder.AlterColumn<Guid>(
                name: "SegmentId",
                table: "verified_point",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "RoadId",
                table: "verified_point",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_verified_point_RoadId",
                table: "verified_point",
                column: "RoadId");

            migrationBuilder.AddForeignKey(
                name: "FK_verified_point_road_RoadId",
                table: "verified_point",
                column: "RoadId",
                principalTable: "road",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_verified_point_segment_SegmentId",
                table: "verified_point",
                column: "SegmentId",
                principalTable: "segment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_verified_point_road_RoadId",
                table: "verified_point");

            migrationBuilder.DropForeignKey(
                name: "FK_verified_point_segment_SegmentId",
                table: "verified_point");

            migrationBuilder.DropIndex(
                name: "IX_verified_point_RoadId",
                table: "verified_point");

            migrationBuilder.DropColumn(
                name: "RoadId",
                table: "verified_point");

            migrationBuilder.AlterColumn<Guid>(
                name: "SegmentId",
                table: "verified_point",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_verified_point_segment_SegmentId",
                table: "verified_point",
                column: "SegmentId",
                principalTable: "segment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
