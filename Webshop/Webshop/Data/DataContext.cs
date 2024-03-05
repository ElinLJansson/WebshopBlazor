using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webshop.Models;

namespace Webshop.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, ProductNumber = 10001, Name = "Fisk", Description = "En god fisk.", Price = 9.90m, StockQuantity = 5, ImgURL = "/images/fisk.jpg" },
            new Product { Id = 2, ProductNumber = 10002, Name = "Gurka", Description = "En gurka som passar alla tillfällen.", Price = 15.90m, StockQuantity = 20, ImgURL = "/images/gurka.jpg" },
            new Product { Id = 3, ProductNumber = 10003, Name = "Husvagn", Description = "Rymlig och mordern husvagn för hela familjen.", Price = 99.90m, StockQuantity = 8, ImgURL = "/images/husvagn.jpg" },
            new Product { Id = 4, ProductNumber = 10004, Name = "Sprit", Description = "Kan innehålla spår av alkohol.", Price = 899.90m, StockQuantity = 10, ImgURL = "/images/sprit.jpg" },
            new Product { Id = 5, ProductNumber = 10005, Name = "Kassett", Description = "En fossil, väl omhändertagen.", Price = 100, DiscountPercent = 10 ,StockQuantity = 1, ImgURL = "/images/kassett.jpg" },
            new Product { Id = 6, ProductNumber = 10006, Name = "Paraply", Description = "Fullt funktionellt paraply, jag lovar.", Price = 79.90m, StockQuantity = 2, ImgURL = "/images/paraply.jpg" },
            new Product { Id = 7, ProductNumber = 10007, Name = "Skruvmejsel", Description = "En lagom stor skruvmejsel.", Price = 5.90m, StockQuantity = 10, ImgURL = "/images/skruvmejsel.jpg" },
            new Product { Id = 8, ProductNumber = 10008, Name = "Diskborste", Description = "Du kan diska med denna, knappt använd.", Price = 79.90m, StockQuantity = 10, ImgURL = "/images/diskborste.jpg" },
            new Product { Id = 9, ProductNumber = 10009, Name = "Tålamod", Description = "Bra att ha.", Price = 559.90m, StockQuantity = 0, ImgURL = "/images/patience.jpg" }
            );

        modelBuilder.Entity<Product>()
            .Property(p => p.DiscountPrice)
            .HasComputedColumnSql("[Price] * (1 - [DiscountPercent] / 100)");

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.ApplicationUser)
            .WithOne(au => au.ShoppingCart)
            .HasForeignKey<ShoppingCart>(sc => sc.Id);

        modelBuilder.Entity<ShoppingCartProduct>()
            .HasKey(scp => new { scp.ProductId, scp.ShoppingCartId });

        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => sc.Id);

        modelBuilder.Entity<ShoppingCartProduct>()
            .Property(scp => scp.Quantity)
            .HasDefaultValue(1);
    }
}
