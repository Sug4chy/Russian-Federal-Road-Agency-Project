using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletedFilePathField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "AttachmentFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "AttachmentFile",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
