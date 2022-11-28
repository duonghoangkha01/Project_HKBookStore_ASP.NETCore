using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKBookStore.Data.Migrations
{
    public partial class EditPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8fea4b3a-d409-4e57-b70b-54e68825412a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0660ef14-d270-4223-bf69-46e08747a2b9", "AQAAAAEAACcQAAAAEEkgIJQZbdyHMwSzmARnhS9W+6LAQCprAa36dcqDypGSEJHuIsygIqvq/saQBs7VtA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 28, 2, 9, 8, 332, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 11, 28, 2, 9, 8, 332, DateTimeKind.Local).AddTicks(1489));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "cc1b1426-f896-40b3-bbf9-031536f39a7d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c587109-b2a6-45c0-a8a3-1c5af5a49f7e", "AQAAAAEAACcQAAAAENp2mf7h+iSYeChPoXI410CvI8o2NnXnimupb0q+1cGFa/OTn/8ZQCEsMgyc6UDp7g==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 28, 0, 33, 17, 448, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 11, 28, 0, 33, 17, 448, DateTimeKind.Local).AddTicks(7015));
        }
    }
}
