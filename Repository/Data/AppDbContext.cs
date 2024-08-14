using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<Slider>().HasQueryFilter(x => !x.SoftDeleted);

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
            //new Setting
            //{
            //    Id = 2,
            //    Key = "Address",
            //    Value = "123 Street, New York"
            //},
            // new Setting
            // {
            //     Id = 3,
            //     Key = "Email",
            //     Value = "Email@Example.com"
            // },
            //    new Setting
            //    {
            //        Id = 4,
            //        Key = "Phone",
            //        Value = "+0123 4567 8910"
            //    },
            //      new Setting
            //      {
            //          Id = 5,
            //          Key = "FooterAddress",
            //          Value = "1429 Netus Rd, NY 48247"
            //      },
            //         new Setting
            //         {
            //             Id = 6,
            //             Key = "FooterLogo",
            //             Value = "Fruitables"
            //         },
            //            new Setting
            //            {
            //                Id = 7,
            //                Key = "FooterLogoDesc",
            //                Value = "Fresh products"
            //            }

            //modelBuilder.Entity<Slider>()
            //             .HasData(
            //new Slider
            //{
            //    Id = 1,
            //   SliderImage = 
            //}
            //); }
        }
    }
}

