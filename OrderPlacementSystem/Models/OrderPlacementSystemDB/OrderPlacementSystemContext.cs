using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.OrderPlacementSystemDB
{
    public class OrderPlacementSystemContext : DbContext
    {
        public OrderPlacementSystemContext() { }

        public OrderPlacementSystemContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configurationRoot["ConnectionStrings:OrderPlacementDB"];
                optionsBuilder.UseSqlServer(connectionString, option =>
                {
                    option.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>().HasData(
                new Services
                {
                    id = 1,
                    name = "Moving"
                },
                new Services
                {
                    id = 2,
                    name = "Packing"
                },
                new Services
                {
                    id = 3,
                    name = "Cleaning"
                });
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Order_Service> Order_Service { get; set; }
    }
}
