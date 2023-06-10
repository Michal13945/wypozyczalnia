﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wypozyczalnia.Data;

#nullable disable

namespace wypozyczalnia.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("wypozyczalnia.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarModelId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValuePerDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarModelId = 1,
                            ValuePerDay = 60m,
                            Year = 2005
                        },
                        new
                        {
                            Id = 2,
                            CarModelId = 2,
                            ValuePerDay = 120m,
                            Year = 2015
                        },
                        new
                        {
                            Id = 3,
                            CarModelId = 3,
                            ValuePerDay = 70m,
                            Year = 2012
                        },
                        new
                        {
                            Id = 4,
                            CarModelId = 4,
                            ValuePerDay = 80m,
                            Year = 2005
                        },
                        new
                        {
                            Id = 5,
                            CarModelId = 5,
                            ValuePerDay = 200m,
                            Year = 2015
                        },
                        new
                        {
                            Id = 6,
                            CarModelId = 6,
                            ValuePerDay = 150m,
                            Year = 2012
                        },
                        new
                        {
                            Id = 7,
                            CarModelId = 7,
                            ValuePerDay = 110m,
                            Year = 2005
                        },
                        new
                        {
                            Id = 8,
                            CarModelId = 8,
                            ValuePerDay = 90m,
                            Year = 2015
                        });
                });

            modelBuilder.Entity("wypozyczalnia.Models.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Skoda"
                        });
                });

            modelBuilder.Entity("wypozyczalnia.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarBrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarBrandId = 1,
                            Name = "Focus"
                        },
                        new
                        {
                            Id = 2,
                            CarBrandId = 1,
                            Name = "Fiesta"
                        },
                        new
                        {
                            Id = 3,
                            CarBrandId = 3,
                            Name = "Octavia"
                        },
                        new
                        {
                            Id = 4,
                            CarBrandId = 3,
                            Name = "Superb"
                        },
                        new
                        {
                            Id = 5,
                            CarBrandId = 2,
                            Name = "206"
                        },
                        new
                        {
                            Id = 6,
                            CarBrandId = 2,
                            Name = "206+"
                        },
                        new
                        {
                            Id = 7,
                            CarBrandId = 2,
                            Name = "207"
                        },
                        new
                        {
                            Id = 8,
                            CarBrandId = 2,
                            Name = "208"
                        });
                });

            modelBuilder.Entity("wypozyczalnia.Models.RentedCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("RentedCars");
                });

            modelBuilder.Entity("wypozyczalnia.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pesel")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("wypozyczalnia.Models.Car", b =>
                {
                    b.HasOne("wypozyczalnia.Models.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("wypozyczalnia.Models.CarModel", b =>
                {
                    b.HasOne("wypozyczalnia.Models.CarBrand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("wypozyczalnia.Models.RentedCar", b =>
                {
                    b.HasOne("wypozyczalnia.Models.Car", "Car")
                        .WithMany("RentedCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wypozyczalnia.Models.User", "User")
                        .WithMany("RentedCars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wypozyczalnia.Models.Car", b =>
                {
                    b.Navigation("RentedCars");
                });

            modelBuilder.Entity("wypozyczalnia.Models.CarBrand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("wypozyczalnia.Models.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("wypozyczalnia.Models.User", b =>
                {
                    b.Navigation("RentedCars");
                });
#pragma warning restore 612, 618
        }
    }
}
