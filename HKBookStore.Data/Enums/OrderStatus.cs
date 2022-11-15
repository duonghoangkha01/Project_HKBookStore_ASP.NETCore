using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Enums
{
    public static class OrderStatus
    {
        public const string Pending = "Chờ xác nhận";
        public const string Approved = "Đã xác nhận";
        public const string Progressing = "Đang giao";
        public const string Shipped = "Đã giao";
        public const string Cancelled = "Đã hủy";
        public const string Refunded = "Đã hoàn lại";
    }
}
