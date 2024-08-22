﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240822100338_CreatedAboutTablesssss")]
    partial class CreatedAboutTablesssss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("About");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Kish-Mish is one of the newest family-owned and operated sweets entreprise in Azerbaijan. It has been making taffy, milk chocolate and dark chocolate orange sticks, and cinnamon bears for 1 year. Additionally, Kish-Mish makes an array of gourmet chocolate candies, holiday candy, sugar free candy, and nostalgic candy - an assortment ranging from chocolate covered peanut clusters to marshmallow Easter eggs and jelly beans.",
                            SoftDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ProductTotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ÇƏRƏZLƏR",
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            Name = "ŞOKOLADLAR",
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            Name = "MEYVƏ QURULARI",
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            Name = "DUZLU TƏAMLAR",
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            Name = "KISH-MISH QUTULARI",
                            SoftDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            Count = 0,
                            Description = "",
                            Name = "ALTIN ÇILEK",
                            Price = 10.65m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Count = 0,
                            Description = "",
                            Name = "BITTER ŞOKOLADLI DUBLE LOKUM",
                            Price = 9.40m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Count = 0,
                            Description = "",
                            Name = "BADAMLI PRALIN",
                            Price = 10.20m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Count = 0,
                            Description = "",
                            Name = "ALMA QURUSU DARÇINLI",
                            Price = 2.10m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Count = 0,
                            Description = "Təbii üsul ilə qurudulmuş yüksək keyfiyyətə malik Natural Ananas Qurusu",
                            Name = "NATURAL ANANAS QURUSU",
                            Price = 12.50m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Count = 0,
                            Description = "Əsl şokolad ləzzətini sizlərə yaşadacaq – Franbuazlı Trufel",
                            Name = "FRANBUAZLI TRUFEL",
                            Price = 9.30m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Count = 0,
                            Description = "Əsl şokolad ləzzətini sizlərə yaşadacaq – Fındıqlı Trufel",
                            Name = "FINDIQLI TRUFEL",
                            Price = 9.30m,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            Count = 0,
                            Description = "Kvadrat Taxta Qutu",
                            Name = "KVADRAT TAXTA QUTU",
                            Price = 416m,
                            SoftDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("Domain.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "slider4.png",
                            IsMain = true,
                            ProductId = 1,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            Image = "Bitter-Sokoladli-Duble-Lokum-scaled.jpg",
                            IsMain = true,
                            ProductId = 2,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            Image = "slider3.png",
                            IsMain = true,
                            ProductId = 3,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            Image = "ALMA-QURUSU-DARÇINLI.jpg",
                            IsMain = true,
                            ProductId = 4,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            Image = "Natural-Ananas-Qurusu.jpg",
                            IsMain = true,
                            ProductId = 5,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 6,
                            Image = "Franbuazli-Trufel.jpg",
                            IsMain = true,
                            ProductId = 6,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 7,
                            Image = "Findiqli-Trufel.jpg",
                            IsMain = true,
                            ProductId = 7,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 8,
                            Image = "Kvadrat-Taxta-Qutu-1300x1300.jpg",
                            IsMain = true,
                            ProductId = 8,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 10,
                            Image = "cilek2.jpg",
                            IsMain = false,
                            ProductId = 1,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 11,
                            Image = "Bitter-Sokoladli-Duble-Lokum2.jpg",
                            IsMain = false,
                            ProductId = 2,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 12,
                            Image = "Badamli-Pralin2.jpg",
                            IsMain = false,
                            ProductId = 3,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 13,
                            Image = "alma-qurusu2.jpeg",
                            IsMain = false,
                            ProductId = 4,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 14,
                            Image = "Natural-Ananas-Qurusu2.jpg",
                            IsMain = false,
                            ProductId = 5,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 15,
                            Image = "Franbuazli-Trufel2.jpg",
                            IsMain = false,
                            ProductId = 6,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 16,
                            Image = "Findiqli-Trufel2.jpg",
                            IsMain = false,
                            ProductId = 7,
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 17,
                            Image = "instagram2.jpeg",
                            IsMain = false,
                            ProductId = 8,
                            SoftDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "HeaderLogo",
                            SoftDeleted = false,
                            Value = "kish_mish-logo.png"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Sliders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "slider2.png",
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            Image = "slider1.png",
                            SoftDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            Image = "slider4.png",
                            SoftDeleted = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Basket", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
