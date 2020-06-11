using Microsoft.EntityFrameworkCore;
using bedayzAPI.Core.Models;
using bedayzAPI.Domain.Models;

namespace bedayzAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "T-SHIRTS" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "HOODIES" },
                new Category { Id = 102, Name = "AKSESUAR" }
            );
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Url).IsRequired();
            builder.Entity<Product>().Property(p => p.Cost).IsRequired();
            builder.Entity<Product>().Property(p => p.Marka).IsRequired();
            builder.Entity<Product>().Property(p => p.PreviousCost).IsRequired();
            builder.Entity<Product>().Property(p => p.NumberInStock).IsRequired();
            builder.Entity<Product>().Property(p => p.Info).IsRequired();
            builder.Entity<Product>().Property(p => p.KargoFiyatı).IsRequired();
            builder.Entity<Product>().Property(p => p.ToplamSiparisSayisi).IsRequired();
            builder.Entity<Product>().Property(p => p.Tag).IsRequired();
            builder.Entity<Product>().HasMany(p => p.Images).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.Entity<Product>().HasMany(p => p.Sepetler).WithOne(p => p.Product).HasForeignKey(p => p.ProductID);
            builder.Entity<Product>().HasMany(p => p.Siparisler).WithOne(p => p.Product).HasForeignKey(p => p.ProductID);
            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "GOLD VINTAGE KOLYE",
                    Url = "https://www.bedayz.com/gold-vintage-kolye",
                    Cost = 45,
                    Marka = EMarka.BEDAYZ,
                    CategoryId = 102,
                    PreviousCost = 50,
                    NumberInStock = 15,
                    Info = "GOLD VINTAGE",
                    KargoFiyatı = 0,
                    Tag = ProductTags.ÖneÇıkanlar
                },
                new Product
                {
                    Id = 101,
                    Name = "SILVER VINTAGE KOLYE",
                    Url = "https://www.bedayz.com/silver-vintage-kolye",
                    Marka = EMarka.BEDAYZ,
                    CategoryId = 102,
                    Cost = 45,
                    PreviousCost = 50,
                    NumberInStock = 9,
                    Info = "SILVER VINTAGE",
                    KargoFiyatı = 0,
                    Tag = ProductTags.Diğer
                },
                new Product
                {
                    Id = 102,
                    Name = "QUARANTINE T-SHIRT",
                    Url = "https://www.bedayz.com/quarantine-t-shirt",
                    Marka = EMarka.BEDAYZ,
                    CategoryId = 100,
                    Cost = 90,
                    PreviousCost = 100,
                    NumberInStock = 10,
                    Info = "BLUE",
                    KargoFiyatı = 0,
                    Tag = ProductTags.ÖneÇıkanlar
                },
                new Product
                {
                    Id = 103,
                    Name = "BETTERDAYZ OVERSIZE T-SHIRT ",
                    Url = "https://www.bedayz.com/betterdayz-oversize-t-shirt",
                    Marka = EMarka.BEDAYZ,
                    CategoryId = 100,
                    Cost = 100,
                    PreviousCost = 5000,
                    NumberInStock = 8,
                    Info = "BLACK",
                    KargoFiyatı = 0,
                    Tag = ProductTags.Diğer
                },
                new Product
                {
                    Id = 104,
                    Name = "TOKYO OVERSIZE T-SHIRT ",
                    Url = "https://www.bedayz.com/tokyo-oversize-t-shirt",
                    Marka = EMarka.BEDAYZ,
                    CategoryId = 100,
                    Cost = 110,
                    PreviousCost = 150,
                    NumberInStock = 15,
                    Info = "WHITE",
                    KargoFiyatı = 0,
                    Tag = ProductTags.FırsatÜrünü

                },
                new Product
                {
                    Id = 105,
                    Name = "RED MUNCHIES OVERSIZE T - SHIRT",
                    Url = "https://www.bedayz.com/red-munchies-oversize-t-shirt",
                    Marka = EMarka.BEDAYZ,
                    CategoryId = 100,
                    Cost = 90,
                    PreviousCost = 100,
                    NumberInStock = 3,
                    Info = "RED",
                    KargoFiyatı = 0,
                    Tag = ProductTags.FırsatÜrünü
                }

            ); ;
            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(p => p.Id);
            builder.Entity<Image>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Image>().Property(p => p.Url).IsRequired();
            builder.Entity<Image>().Property(p => p.Name).IsRequired();
            builder.Entity<Image>().HasData
            (
                new Image
                {
                    Id = 100,
                    Url = "https://www.bedayz.com/Uploads/UrunResimleri/thumb/gold-vintage-kolye-de93.jpg",
                    Name = "TeoriV2-106687_large.jpg",
                    ProductId = 100
                },
                new Image
                {
                    Id = 101,
                    Url = "https://www.bedayz.com/Uploads/UrunResimleri/thumb/silver-vintage-kolye-8181.jpg",
                    Name = "TeoriV2-97788_large.jpg",
                    ProductId = 101
                },
                new Image
                {
                    Id = 102,
                    Url = "https://www.bedayz.com/Uploads/UrunResimleri/thumb/quarantine-t-shirt-7983.jpg",
                    Name = "TeoriV2-106613_large.jpg",
                    ProductId = 102
                },
                new Image
                {
                    Id = 103,
                    Url = "https://www.bedayz.com/Uploads/UrunResimleri/thumb/betterdayz-oversize-t-shirt-b9f9.jpg",
                    Name = "TeoriV2-105445-7_large.jpg",
                    ProductId = 103
                },
                new Image
                {
                    Id = 104,
                    Url = "https://www.bedayz.com/Uploads/UrunResimleri/thumb/tokyo-oversize-t-shirt-8171.jpg",
                    Name = "TeoriV2-106597_large.jpg",
                    ProductId = 104
                },
                new Image
                {
                    Id = 105,
                    Url = "https://www.bedayz.com/Uploads/UrunResimleri/thumb/red-munchies-oversize-t-shirt-d1b2.jpg",
                    ProductId = 105,
                    Name = "TeoriV2-105271-4_large.jpg"
                }
            );
            builder.Entity<Sepet>().ToTable("Sepet");
            builder.Entity<Sepet>().HasKey(p => p.SepetId);
            builder.Entity<Sepet>().Property(p => p.SepetId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Siparis>().Property(p => p.Adet).IsRequired();
            builder.Entity<Siparis>().Property(p => p.UserId).IsRequired();
            builder.Entity<Siparis>().Property(p => p.ProductID).IsRequired();
            builder.Entity<Sepet>().HasData
            (
                 new Sepet
                 {
                     SepetId = 1,
                     Adet = 1,
                     UserId = 1,
                     ProductID = 100

                 },
                 new Sepet
                 {
                     SepetId = 2,
                     Adet = 1,
                     UserId = 2,
                     ProductID = 101

                 }
            );


            builder.Entity<Siparis>().ToTable("Siparis");
            builder.Entity<Siparis>().HasKey(p => p.SiparisId);
            builder.Entity<Siparis>().Property(p => p.SiparisId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Siparis>().Property(p => p.Adet).IsRequired();
            builder.Entity<Siparis>().Property(p => p.UserId).IsRequired();
            builder.Entity<Siparis>().Property(p => p.ProductID).IsRequired();
            builder.Entity<Siparis>().HasData
            (
                 new Siparis
                 {
                     SiparisId = 1,
                     Adet = 1,
                     UserId = 1,
                     ProductID = 100



                 },
                new Siparis
                {
                    SiparisId = 2,
                    Adet = 1,
                    UserId = 2,
                    ProductID = 101
                }
             );

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });




            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Name).IsRequired();
            builder.Entity<User>().Property(p => p.LastName).IsRequired();
            builder.Entity<User>().Property(p => p.UserName).IsRequired();
            builder.Entity<User>().Property(p => p.Password).IsRequired();
            builder.Entity<User>().HasMany(p => p.Sepetler).WithOne(p => p.User).HasForeignKey(b => b.UserId);
            builder.Entity<User>().HasMany(p => p.Siparisler).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.Entity<User>().HasData
            (

                new User { Id = 1, Name = "Deneme1", LastName = "DSoyad1", UserName = "deneme1", Email = "deneme1@gmail.com", Password = "1234" },
                new User { Id = 2, Name = "Deneme2", LastName = "DSoyad2", UserName = "deneme2", Email = "deneme2@gmail.com", Password = "4567" }
            );


            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
