﻿// <auto-generated />
using System;
using MagicVilla.DatabaseConfig.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla.DatabaseConfig.Migrations
{
    [DbContext(typeof(MagicVillaDbContext))]
    partial class MagicVillaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla.Models.VillaDbModels.Villa", b =>
                {
                    b.Property<int>("VillaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VillaId"));

                    b.Property<string>("Amenity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VillaDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VillaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VillaId");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            VillaId = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4066),
                            ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VillaDetails = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            VillaName = "Royal Villa"
                        },
                        new
                        {
                            VillaId = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4081),
                            ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                            Occupancy = 4,
                            Rate = 300.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VillaDetails = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            VillaName = "Premium Pool Villa"
                        },
                        new
                        {
                            VillaId = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4083),
                            ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                            Occupancy = 4,
                            Rate = 400.0,
                            Sqft = 750,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VillaDetails = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            VillaName = "Luxury Pool Villa"
                        },
                        new
                        {
                            VillaId = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4084),
                            ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                            Occupancy = 4,
                            Rate = 550.0,
                            Sqft = 900,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VillaDetails = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            VillaName = "Diamond Villa"
                        },
                        new
                        {
                            VillaId = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4086),
                            ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                            Occupancy = 4,
                            Rate = 600.0,
                            Sqft = 1100,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VillaDetails = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            VillaName = "Diamond Pool Villa"
                        });
                });

            modelBuilder.Entity("MagicVilla.Models.VillaDbModels.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumbers");
                });

            modelBuilder.Entity("MagicVilla.Models.VillaDbModels.VillaNumber", b =>
                {
                    b.HasOne("MagicVilla.Models.VillaDbModels.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
