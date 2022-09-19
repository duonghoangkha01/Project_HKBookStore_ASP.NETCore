using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKBookStore.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeDescription", "Đây là mô tả của HKBookStore" },
                    { "HomeKeyword", "Đây là từ khóa của HKBookStore" },
                    { "HomeTitle", "Đây la trang chủ HKBookStore" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "Name", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, "Văn học", null, 1, 1 },
                    { 2, true, "Kinh tế", null, 2, 1 },
                    { 3, true, "Tâm lý - Kĩ năng sống", null, 3, 1 },
                    { 4, true, "Nuôi dạy con", null, 4, 1 },
                    { 5, true, "Sách thiếu nhi", null, 5, 1 },
                    { 6, true, "Tiểu sử - Hồi ký", null, 6, 1 },
                    { 7, true, "Giáo khoa - Tham khảo", null, 7, 1 },
                    { 8, true, "Sách ngoại ngữ", null, 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "DateCreated", "Description", "Details", "Name", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, "Paulo Coelho", new DateTime(2022, 9, 19, 18, 42, 37, 867, DateTimeKind.Local).AddTicks(5074), "Đây là mô tả của sách Nhà Giả Kim (Tái Bản 2020)", "Đây là chi tiết của sách Nhà Giả Kim (Tái Bản 2020)", "Nhà Giả Kim (Tái Bản 2020)", 79000m, 59000m },
                    { 2, "Khotudien", new DateTime(2022, 9, 19, 18, 42, 37, 867, DateTimeKind.Local).AddTicks(5085), "Đây là mô tả của sách Từ Điển Tiếng “Em” - Tái Bản 2021", "Đây là chi tiết của sách Từ Điển Tiếng “Em” - Tái Bản 2021", "Từ Điển Tiếng “Em” - Tái Bản 2021", 69000m, 50000m }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "Name", "ParentId", "SortOrder", "Status" },
                values: new object[] { 9, true, "Tiểu thuyết", 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "Name", "ParentId", "SortOrder", "Status" },
                values: new object[] { 10, true, "Truyện ngắn - Tản văn", 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 10, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
