using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "road",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "М-5" },
                    { new Guid("37d115a0-10e8-444f-9379-78a231852962"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Р-254" },
                    { new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Р-354" },
                    { new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "А-310" }
                });

            migrationBuilder.InsertData(
                table: "advertisement",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ExpirationDateTime", "LastlyEditedAt", "MessageText", "RoadId", "Title" },
                values: new object[] { new Guid("05513f6e-85bf-4454-9086-c243c2dc6441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "На дороге всё спокойно, просто тестируем объявления", new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"), "Объявления для М-5" });

            migrationBuilder.InsertData(
                table: "segment",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude1", "Latitude2", "Longitude1", "Longitude2", "RoadId" },
                values: new object[,]
                {
                    { new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0.0, 0.0, 0.0, 0.0, new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89") },
                    { new Guid("a5065dbf-417d-43d7-890b-2a5c64d930ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0.0, 0.0, 0.0, 0.0, new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb") },
                    { new Guid("a72f8fff-f48c-4e34-ba60-d5e6b74e93df"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0.0, 0.0, 0.0, 0.0, new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7") },
                    { new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0.0, 0.0, 0.0, 0.0, new Guid("37d115a0-10e8-444f-9379-78a231852962") }
                });

            migrationBuilder.InsertData(
                table: "verified_point",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude", "Longitude", "Name", "SegmentId", "Type" },
                values: new object[,]
                {
                    { new Guid("403a8023-4711-4db0-9b99-8f80c2b99060"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54.989184000000002, 61.043416000000001, "Subway", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "Cafes" },
                    { new Guid("40e0963e-676c-4b3e-87d6-b369222d774c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54.987986999999997, 61.044195000000002, "РегионUNO", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("5ef5ef5a-ae4e-447a-94a2-c9d982d19e71"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54.945492999999999, 60.827627, "Salavat", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("ed7a038c-1dac-4b67-ac83-7c7933f73d45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 55.233764999999998, 62.032693000000002, "Челябнефтепродукт", new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"), "GasStations" },
                    { new Guid("f1069ee4-14c5-4f96-99a6-6db1f251a4bc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54.996371000000003, 61.133454, "Кафе Урал", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "Cafes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "advertisement",
                keyColumn: "Id",
                keyValue: new Guid("05513f6e-85bf-4454-9086-c243c2dc6441"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("a5065dbf-417d-43d7-890b-2a5c64d930ac"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("a72f8fff-f48c-4e34-ba60-d5e6b74e93df"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("403a8023-4711-4db0-9b99-8f80c2b99060"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("40e0963e-676c-4b3e-87d6-b369222d774c"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("5ef5ef5a-ae4e-447a-94a2-c9d982d19e71"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("ed7a038c-1dac-4b67-ac83-7c7933f73d45"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("f1069ee4-14c5-4f96-99a6-6db1f251a4bc"));

            migrationBuilder.DeleteData(
                table: "road",
                keyColumn: "Id",
                keyValue: new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7"));

            migrationBuilder.DeleteData(
                table: "road",
                keyColumn: "Id",
                keyValue: new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"));

            migrationBuilder.DeleteData(
                table: "road",
                keyColumn: "Id",
                keyValue: new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"));

            migrationBuilder.DeleteData(
                table: "road",
                keyColumn: "Id",
                keyValue: new Guid("37d115a0-10e8-444f-9379-78a231852962"));
        }
    }
}
