using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RFRAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "advertisement",
                keyColumn: "Id",
                keyValue: new Guid("1574f607-1c3e-4cde-9863-33ba6d1ca974"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("31923144-b0fd-4f24-a6bb-ae77320d2f47"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("e764de5f-3790-4081-a96c-0badb4076771"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("1ae1428d-2dff-4c40-b7b7-8c2834dec16d"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("3e6a6163-082e-4fa8-a632-7d3360b9d826"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("75df5128-4df2-4e88-b368-094f64df4a9c"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("7c6fd30d-b9a0-4252-84c6-a5cc50358f10"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("9cb8e728-9dac-435d-b38e-213c21ff0115"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("abd2e6d8-f530-48af-9a5d-c1129ca41fd7"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("f9b15bc7-a267-4827-b6c7-67ce39ae2de0"));

            migrationBuilder.InsertData(
                table: "advertisement",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ExpirationDateTime", "LastlyEditedAt", "MessageText", "RoadId", "Title" },
                values: new object[] { new Guid("514146f9-bb1f-4b93-af97-dc9f7f957a13"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "На дороге всё спокойно, просто тестируем объявления", new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"), "Объявления для М-5" });

            migrationBuilder.InsertData(
                table: "segment",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude1", "Latitude2", "Longitude1", "Longitude2", "RoadId" },
                values: new object[,]
                {
                    { new Guid("8b1be003-94ea-49c1-bad2-3a689707b9a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 0.0, 0.0, 0.0, new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb") },
                    { new Guid("bd6a92ba-8161-49ea-9108-b4ab07aefd63"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 0.0, 0.0, 0.0, new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7") }
                });

            migrationBuilder.InsertData(
                table: "verified_point",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude", "Longitude", "Name", "SegmentId", "Type" },
                values: new object[,]
                {
                    { new Guid("1ad0c929-c66a-4a8d-98e5-4c3f5625950e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.951769053652228, 60.869138434859998, "Газпромнефть", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("433bc556-0ade-4803-8bd8-147c09644355"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.945492999999999, 60.827627, "Salavat", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("55b0136d-336f-41b4-ba37-90e8c0f36030"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.233764999999998, 62.032693000000002, "Челябнефтепродукт", new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"), "GasStations" },
                    { new Guid("71ee3c0c-cb72-4767-8f24-24969bce4c66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.987986999999997, 61.044195000000002, "РегионUNO", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("870ec846-559e-4e8f-bf23-0faa6a287f17"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.989184000000002, 61.043416000000001, "Subway", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "Cafes" },
                    { new Guid("87431c3d-7bf7-4383-b6e7-95b845b3352b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.996371000000003, 61.133454, "Кафе Урал", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "Cafes" },
                    { new Guid("bd5e3c9a-312e-4b54-96f7-de52417d9567"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.010850387932749, 61.257548157714069, "Salavat", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "advertisement",
                keyColumn: "Id",
                keyValue: new Guid("514146f9-bb1f-4b93-af97-dc9f7f957a13"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("8b1be003-94ea-49c1-bad2-3a689707b9a0"));

            migrationBuilder.DeleteData(
                table: "segment",
                keyColumn: "Id",
                keyValue: new Guid("bd6a92ba-8161-49ea-9108-b4ab07aefd63"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("1ad0c929-c66a-4a8d-98e5-4c3f5625950e"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("433bc556-0ade-4803-8bd8-147c09644355"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("55b0136d-336f-41b4-ba37-90e8c0f36030"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("71ee3c0c-cb72-4767-8f24-24969bce4c66"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("870ec846-559e-4e8f-bf23-0faa6a287f17"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("87431c3d-7bf7-4383-b6e7-95b845b3352b"));

            migrationBuilder.DeleteData(
                table: "verified_point",
                keyColumn: "Id",
                keyValue: new Guid("bd5e3c9a-312e-4b54-96f7-de52417d9567"));

            migrationBuilder.InsertData(
                table: "advertisement",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ExpirationDateTime", "LastlyEditedAt", "MessageText", "RoadId", "Title" },
                values: new object[] { new Guid("1574f607-1c3e-4cde-9863-33ba6d1ca974"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "На дороге всё спокойно, просто тестируем объявления", new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"), "Объявления для М-5" });

            migrationBuilder.InsertData(
                table: "segment",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude1", "Latitude2", "Longitude1", "Longitude2", "RoadId" },
                values: new object[,]
                {
                    { new Guid("31923144-b0fd-4f24-a6bb-ae77320d2f47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 0.0, 0.0, 0.0, new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb") },
                    { new Guid("e764de5f-3790-4081-a96c-0badb4076771"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 0.0, 0.0, 0.0, new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7") }
                });

            migrationBuilder.InsertData(
                table: "verified_point",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LastlyEditedAt", "Latitude", "Longitude", "Name", "SegmentId", "Type" },
                values: new object[,]
                {
                    { new Guid("1ae1428d-2dff-4c40-b7b7-8c2834dec16d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.945492999999999, 60.827627, "Salavat", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("3e6a6163-082e-4fa8-a632-7d3360b9d826"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.010850387932749, 61.257548157714069, "Salavat", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("75df5128-4df2-4e88-b368-094f64df4a9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.951769053652228, 60.869138434859998, "Газпромнефть", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" },
                    { new Guid("7c6fd30d-b9a0-4252-84c6-a5cc50358f10"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.996371000000003, 61.133454, "Кафе Урал", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "Cafes" },
                    { new Guid("9cb8e728-9dac-435d-b38e-213c21ff0115"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.989184000000002, 61.043416000000001, "Subway", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "Cafes" },
                    { new Guid("abd2e6d8-f530-48af-9a5d-c1129ca41fd7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.233764999999998, 62.032693000000002, "Челябнефтепродукт", new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"), "GasStations" },
                    { new Guid("f9b15bc7-a267-4827-b6c7-67ce39ae2de0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.987986999999997, 61.044195000000002, "РегионUNO", new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"), "GasStations" }
                });
        }
    }
}
