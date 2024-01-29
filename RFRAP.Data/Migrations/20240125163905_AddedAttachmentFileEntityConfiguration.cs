using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttachmentFileEntityConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileReference",
                table: "unverified_point");

            migrationBuilder.CreateTable(
                name: "AttachmentFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UniqueName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    PointId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastlyEditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentFile", x => x.Id);
                    table.UniqueConstraint("AK_AttachmentFile_UniqueName", x => x.UniqueName);
                    table.ForeignKey(
                        name: "FK_AttachmentFile_unverified_point_PointId",
                        column: x => x.PointId,
                        principalTable: "unverified_point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentFile_PointId",
                table: "AttachmentFile",
                column: "PointId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentFile");

            migrationBuilder.AddColumn<string>(
                name: "FileReference",
                table: "unverified_point",
                type: "text",
                nullable: true);
        }
    }
}
