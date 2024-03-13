using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedAttachmentFileRelationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentFile_unverified_point_PointId",
                table: "AttachmentFile");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AttachmentFile_UniqueName",
                table: "AttachmentFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentFile",
                table: "AttachmentFile");

            migrationBuilder.RenameTable(
                name: "AttachmentFile",
                newName: "attachment_file");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentFile_PointId",
                table: "attachment_file",
                newName: "IX_attachment_file_PointId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_attachment_file_UniqueName",
                table: "attachment_file",
                column: "UniqueName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attachment_file",
                table: "attachment_file",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_attachment_file_unverified_point_PointId",
                table: "attachment_file",
                column: "PointId",
                principalTable: "unverified_point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachment_file_unverified_point_PointId",
                table: "attachment_file");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_attachment_file_UniqueName",
                table: "attachment_file");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attachment_file",
                table: "attachment_file");

            migrationBuilder.RenameTable(
                name: "attachment_file",
                newName: "AttachmentFile");

            migrationBuilder.RenameIndex(
                name: "IX_attachment_file_PointId",
                table: "AttachmentFile",
                newName: "IX_AttachmentFile_PointId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AttachmentFile_UniqueName",
                table: "AttachmentFile",
                column: "UniqueName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentFile",
                table: "AttachmentFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentFile_unverified_point_PointId",
                table: "AttachmentFile",
                column: "PointId",
                principalTable: "unverified_point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
