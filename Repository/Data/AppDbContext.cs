using System;
using System.Xml.Linq;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<About> About { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<Slider>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<ProductImage>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<About>().HasQueryFilter(x => !x.SoftDeleted);

            modelBuilder.Entity<Setting>()
                     .HasData(
        new Setting
        {
            Id = 1,
            Key = "HeaderLogo",
            Value = "kish_mish-logo.png"
        }
        );
            modelBuilder.Entity<Slider>()
                       .HasData(
          new Slider
          {
              Id = 1,
              Image = "slider2.png",

          },

          new Slider
          {
              Id = 2,
              Image = "slider1.png",

          },

            new Slider
            {
                Id = 3,
                Image = "slider4.png",

            }

          );
            modelBuilder.Entity<Category>()
                               .HasData(
                  new Category
                  {
                      Id = 1,
                      Name = "ÇƏRƏZLƏR"
                  },

                   new Category
                   {
                       Id = 2,
                       Name = "ŞOKOLADLAR"
                   },
                    new Category
                    {
                        Id = 3,
                        Name = "MEYVƏ QURULARI"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "DUZLU TƏAMLAR"
                    },
                   new Category
                   {
                       Id = 5,
                       Name = "KISH-MISH QUTULARI"
                   }
                   );

            modelBuilder.Entity<Product>()
                   .HasData(
      new Product
      {
          Id = 1,
          Name = "ALTIN ÇILEK",
          Price = 10.65M,
          Description = "",
          CategoryId = 3
      },
      new Product
      { 
            Id = 2,
          Name = "BITTER ŞOKOLADLI DUBLE LOKUM",
          Price = 9.40M,
          Description = "",
          CategoryId = 2

      },
            new Product
            {
                Id = 3,
                Name = "BADAMLI PRALIN",
                Price = 10.20M,
                Description = "",
                CategoryId = 2

            }
            ,
             new Product
             {
                 Id = 4,
                 Name = "ALMA QURUSU DARÇINLI",
                 Price = 2.10M,
                 Description = "",
                 CategoryId = 3

             },
              new Product
              {
                  Id = 5,
                  Name = "NATURAL ANANAS QURUSU",
                  Price = 12.50M,
                  Description = "Təbii üsul ilə qurudulmuş yüksək keyfiyyətə malik Natural Ananas Qurusu",
                  CategoryId = 3

              },
               new Product
               {
                   Id = 6,
                   Name = "FRANBUAZLI TRUFEL",
                   Price = 9.30M,
                   Description = "Əsl şokolad ləzzətini sizlərə yaşadacaq – Franbuazlı Trufel",
                   CategoryId = 2

               },
                new Product
                {
                    Id = 7,
                    Name = "FINDIQLI TRUFEL",
                    Price = 9.30M,
                    Description = "Əsl şokolad ləzzətini sizlərə yaşadacaq – Fındıqlı Trufel",
                    CategoryId = 2

                },
                 new Product
                 {
                     Id = 8,
                     Name = "KVADRAT TAXTA QUTU",
                     Price = 416M,
                     Description = "Kvadrat Taxta Qutu",
                     CategoryId = 5

                 }
              ); modelBuilder.Entity<ProductImage>()
                             .HasData(
          new ProductImage
          {
              Id = 1,
              Image = "slider4.png",
              IsMain = true,
              ProductId = 1
          },

            new ProductImage
            {
                Id = 2,
                Image = "Bitter-Sokoladli-Duble-Lokum-scaled.jpg",
                IsMain = true,
                ProductId = 2

            },

            new ProductImage
            {
                Id = 3,
                Image = "slider3.png",
                IsMain = true,
                ProductId = 3
            },
              new ProductImage
              {
                  Id = 4,
                  Image = "ALMA-QURUSU-DARÇINLI.jpg",
                  IsMain = true,
                  ProductId = 4
              },
             new ProductImage
             {
                 Id = 5,
                 Image = "Natural-Ananas-Qurusu.jpg",
                 IsMain = true,
                 ProductId = 5
             },
              new ProductImage
              {
                  Id = 6,
                  Image = "Franbuazli-Trufel.jpg",
                  IsMain = true,
                  ProductId = 6
              },
               new ProductImage
               {
                   Id = 7,
                   Image = "Findiqli-Trufel.jpg",
                   IsMain = true,
                   ProductId = 7
               },
                 new ProductImage
                 {
                     Id = 8,
                     Image = "Kvadrat-Taxta-Qutu-1300x1300.jpg",
                     IsMain = true,
                     ProductId = 8
                 },
                
                    new ProductImage
                    {
                        Id = 10,
                        Image = "cilek2.jpg",
                        IsMain = false,
                        ProductId = 1
                    }
                    ,
                      new ProductImage
                      {
                          Id = 11,
                          Image = "Bitter-Sokoladli-Duble-Lokum2.jpg",
                          IsMain = false,
                          ProductId = 2
                      },
                       new ProductImage
                       {
                           Id = 12,
                           Image = "Badamli-Pralin2.jpg",
                           IsMain = false,
                           ProductId = 3
                       },
                         new ProductImage
                         {
                             Id = 13,
                             Image = "alma-qurusu2.jpeg",
                             IsMain = false,
                             ProductId = 4
                         },
                         new ProductImage
                         {
                             Id = 14,
                             Image = "Natural-Ananas-Qurusu2.jpg",
                             IsMain = false,
                             ProductId = 5
                         },
                           new ProductImage
                           {
                               Id = 15,
                               Image = "Franbuazli-Trufel2.jpg",
                               IsMain = false,
                               ProductId = 6
                           },
                             new ProductImage
                             {
                                 Id = 16,
                                 Image = "Findiqli-Trufel2.jpg",
                                 IsMain = false,
                                 ProductId = 7
                             },
                                 new ProductImage
                                 {
                                     Id = 17,
                                     Image = "instagram2.jpeg",
                                     IsMain = false,
                                     ProductId = 8
                                 }


          );
            modelBuilder.Entity<About>()
                  .HasData(
     new About
     {
         Id = 1,
         Description = "Kish-Mish is one of the newest family-owned and operated sweets entreprise in Azerbaijan. It has been making taffy, milk chocolate and dark chocolate orange sticks, and cinnamon bears for 1 year. Additionally, Kish-Mish makes an array of gourmet chocolate candies, holiday candy, sugar free candy, and nostalgic candy - an assortment ranging from chocolate covered peanut clusters to marshmallow Easter eggs and jelly beans."
     });

        }

    }
}  

       

       


