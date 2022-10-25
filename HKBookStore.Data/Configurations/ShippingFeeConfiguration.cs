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
    public class ShippingFeeConfiguration : IEntityTypeConfiguration<ShippingFee>
    {
        public void Configure(EntityTypeBuilder<ShippingFee> builder)
        {
            builder.ToTable("ShippingFees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Price).IsRequired();



        }
    }
}
