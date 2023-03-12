
using CleanStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanStore.Infrastructure.Context
{
    public class StoreDbContext : DbContext
    {


        public DbSet<Product>? Products { get; set; }
        public DbSet<Seller>? Sellers { get; set; }
        public DbSet<Category>? Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T8R6POH\TESTINGDB; Database=CleanStore; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);    //TODO:Revisar ondelete restrict
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity<ProductCategory>(
                    pc => pc.HasKey(e => new { e.ProductId, e.CategoryId })
                );
        }
    }
}
