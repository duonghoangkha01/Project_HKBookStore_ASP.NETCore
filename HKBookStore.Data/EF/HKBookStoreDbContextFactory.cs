using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.EF
{
    public class HKBookStoreDbContextFactory : IDesignTimeDbContextFactory<HKBookStoreDbContext>
    {
        public HKBookStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HKBookStoreDb");

            var optionsBuilder = new DbContextOptionsBuilder<HKBookStoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HKBookStoreDbContext(optionsBuilder.Options);
        }
    }
}
