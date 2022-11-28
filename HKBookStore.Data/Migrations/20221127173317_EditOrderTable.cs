using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKBookStore.Data.Migrations
{
    public partial class EditOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "431f5161-ef27-403f-ad57-238e07d2463d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5ea157a-03e0-41d3-8eba-d5c25b4b1986", "AQAAAAEAACcQAAAAEBs0yC0k4yG3pckQ++ZHL3KE4EpJkXiLU5Xg9MdoErTAgQ0BqAkQlqqbBqRdqOYaTg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 25, 14, 48, 40, 667, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 11, 25, 14, 48, 40, 667, DateTimeKind.Local).AddTicks(9556));
        }
    }
}
