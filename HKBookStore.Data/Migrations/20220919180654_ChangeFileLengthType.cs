using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKBookStore.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "38690bbe-ba86-4db1-b72a-649e822a98b6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "392ccaeb-e1c7-4627-bfc4-84a94aec946b", "AQAAAAEAACcQAAAAEGlnxuOCBaqbpKfl8qtxxHBq2K1op4HNOll065IThviT0bsKZt62xlYe+IpzUrbVVQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 9, 20, 1, 6, 53, 948, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 9, 20, 1, 6, 53, 948, DateTimeKind.Local).AddTicks(7402));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "19f55485-e472-42fc-b2ef-7e2a9aecc7d8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba5c45ed-4c21-4c35-840c-d60e2a9a60a2", "AQAAAAEAACcQAAAAEKDknbx1K3aDCMAg+gIWJxCEYpOtX5UDPEvYdZglHJucABSkVl/N4zfHiDJKDtskpw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 9, 20, 0, 22, 2, 654, DateTimeKind.Local).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 9, 20, 0, 22, 2, 654, DateTimeKind.Local).AddTicks(4431));
        }
    }
}
