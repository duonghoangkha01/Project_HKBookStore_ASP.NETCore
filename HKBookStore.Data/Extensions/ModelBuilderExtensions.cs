using HKBookStore.Data.Entities;
using HKBookStore.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "Đây la trang chủ HKBookStore" },
               new AppConfig() { Key = "HomeKeyword", Value = "Đây là từ khóa của HKBookStore" },
               new AppConfig() { Key = "HomeDescription", Value = "Đây là mô tả của HKBookStore" }
               );

            modelBuilder.Entity<Category>().HasData(
                    new Category()
                    {
                        Id = 1,
                        Name = "Văn học",
                        SortOrder = 1,
                        IsShowOnHome = true,
                        Status = Status.Active,
                        ParentId = null,
                    },
                     new Category()
                     {
                         Id = 2,
                         Name = "Kinh tế",
                         SortOrder = 2,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     },
                     new Category()
                     {
                         Id = 3,
                         Name = "Tâm lý - Kĩ năng sống",
                         SortOrder = 3,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     },
                     new Category()
                     {
                         Id = 4,
                         Name = "Nuôi dạy con",
                         SortOrder = 4,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     },
                     new Category()
                     {
                         Id = 5,
                         Name = "Sách thiếu nhi",
                         SortOrder = 5,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     },
                     new Category()
                     {
                         Id = 6,
                         Name = "Tiểu sử - Hồi ký",
                         SortOrder = 6,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     },
                     new Category()
                     {
                         Id = 7,
                         Name = "Giáo khoa - Tham khảo",
                         SortOrder = 7,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     },
                     new Category()
                     {
                         Id = 8,
                         Name = "Sách ngoại ngữ",
                         SortOrder = 8,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = null,
                     }
                     ,
                     new Category()
                     {
                         Id = 9,
                         Name = "Tiểu thuyết",
                         SortOrder = 1,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = 1,
                     }
                     ,
                     new Category()
                     {
                         Id = 10,
                         Name = "Truyện ngắn - Tản văn",
                         SortOrder = 2,
                         IsShowOnHome = true,
                         Status = Status.Active,
                         ParentId = 1,
                     });

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   Name = "Nhà Giả Kim (Tái Bản 2020)",
                   Author = "Paulo Coelho",
                   Description = "Đây là mô tả của sách Nhà Giả Kim (Tái Bản 2020)",
                   Details = "Đây là chi tiết của sách Nhà Giả Kim (Tái Bản 2020)",
                   OriginalPrice = 79000,
                   Price = 59000,
                   Stock = 0,
                   ViewCount = 0,
                   DateCreated = DateTime.Now,
               },
               new Product()
               {
                   Id = 2,
                   Name = "Từ Điển Tiếng “Em” - Tái Bản 2021",
                   Author = "Khotudien",
                   Description = "Đây là mô tả của sách Từ Điển Tiếng “Em” - Tái Bản 2021",
                   Details = "Đây là chi tiết của sách Từ Điển Tiếng “Em” - Tái Bản 2021",
                   OriginalPrice = 69000,
                   Price = 50000,
                   Stock = 0,
                   ViewCount = 0,
                   DateCreated = DateTime.Now,
               });

            modelBuilder.Entity<ProductInCategory>().HasData(
                    new ProductInCategory() { ProductId = 1, CategoryId = 9 },
                    new ProductInCategory() { ProductId = 2, CategoryId = 10 }
                    );

        }
    }
}

