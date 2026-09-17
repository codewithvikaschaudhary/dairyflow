using DairyFlow.Data.Enum;
using DairyFlow.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using System; // Add this using directive

namespace DairyFlow.Data.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Inventories> Inventories { get; set; }
        public DbSet<StockTransaction> StockTransaction { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Purchases> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StockTransaction>()
                .Property(x => x.TransactionType)
                .HasConversion<string>();

            modelBuilder.Entity<Purchases>()
                .Property(x => x.Status)
                .HasConversion<string>();


            //modelBuilder.Entity<Purchases>()
            //    .Property(x => x.Status)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => System.Enum.Parse<PurchaseStatus>(v, true));


        }
    }
}
