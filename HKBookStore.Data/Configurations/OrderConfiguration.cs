using HKBookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.OrderDate);


            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).IsRequired(false);
            builder.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentId);
            builder.HasOne(x => x.ShippingFee).WithMany(x => x.Orders).HasForeignKey(x => x.ShippingFeeId);
            builder.HasOne(x => x.ShippingInfo).WithMany(x => x.Orders).HasForeignKey(x => x.ShippingInfoId);
        }
    }
}
