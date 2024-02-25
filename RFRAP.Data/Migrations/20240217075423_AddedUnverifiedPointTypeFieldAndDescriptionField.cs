using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUnverifiedPointTypeFieldAndDescriptionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "unverified_point",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "unverified_point",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "unverified_point");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "unverified_point");
        }
    }
}
