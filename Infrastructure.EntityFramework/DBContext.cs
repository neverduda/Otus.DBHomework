using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Advertisement>()
                .HasOne(a => a.Buyer)
                .WithMany(c => c.BuyerAdvertisements)
                .HasForeignKey(a => a.BuyerId);

            modelBuilder.Entity<Advertisement>()
                .HasOne(a => a.Seller)
                .WithMany(c => c.SellerAdvertisements)
                .HasForeignKey(a => a.SellerId);

            modelBuilder.Entity<Advertisement>()
               .HasOne(a => a.Product)
               .WithMany(c => c.Advertisements)
               .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<User>().Property(e => e.Id).UseIdentityColumn();
            modelBuilder.Entity<Advertisement>().Property(e => e.Id).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(e => e.Id).UseIdentityColumn();


            // не понятно почему обязательно требует заполнения поля Id несмотря на наличие UseIdentityColumn
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Sergey", LastName = "Dudkin", PhoneNumber = "77777" },
                new User { Id = 2, FirstName = "Mary", LastName = "Mary", PhoneNumber = "888888888" },
                new User { Id = 3, FirstName = "Serg", PhoneNumber = "888888888" },
                new User { Id = 4, FirstName = "Alex", PhoneNumber = "111" },
                new User { Id = 5, FirstName = "Ivan", LastName = "Vasilev", PhoneNumber = "222" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Phone", Price = 12000 },
                new Product { Id = 2, Name = "Basketball ball Wilson", Price = 7000 },
                new Product { Id = 3, Name = "Nike sport shoes", Price = 15000 },
                new Product { Id = 4, Name = "SUP Serf", Price = 50000 },
                new Product { Id = 5, Name = "Backpack", Price = 5000 }
                );

            modelBuilder.Entity<Advertisement>().HasData(
                new Advertisement { Id = 1, SellerId = 1, BuyerId = 2, ProductId = 1, Status = 1 },
                new Advertisement { Id = 2, SellerId = 2, BuyerId = 3, ProductId = 2, Status = 2 },
                new Advertisement { Id = 3, SellerId = 3, ProductId = 3, Status = 3 },
                new Advertisement { Id = 4, SellerId = 4, ProductId = 4, Status = 4 },
                new Advertisement { Id = 5, SellerId = 5, ProductId = 5, Status = 5 }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}