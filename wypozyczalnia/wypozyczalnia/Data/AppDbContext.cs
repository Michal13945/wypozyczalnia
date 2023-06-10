using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using wypozyczalnia.Models;

namespace wypozyczalnia.Data;

public class AppDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RentedCar> RentedCars { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarModel> CarModels { get; set; }

    private string path = @"C:\Temp\rentCar.db";

    public AppDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Car>()
            .HasOne(x => x.CarModel)
            .WithMany(x => x.Cars);

        modelBuilder
            .Entity<CarModel>()
            .HasOne(x => x.Brand)
            .WithMany(x => x.Models);

        modelBuilder
            .Entity<RentedCar>()
            .HasOne(x => x.User)
            .WithMany(x => x.RentedCars);

        modelBuilder
            .Entity<RentedCar>()
            .HasOne(x => x.Car)
            .WithMany(x => x.RentedCars);

        var carBrands = new CarBrand[]
        {
            new CarBrand() {Id = 1, Name = "Ford"},
            new CarBrand() {Id = 2, Name = "Peugeot"},
            new CarBrand() {Id = 3, Name = "Skoda"},
        };

        var carModels = new CarModel[]
        {
            new CarModel() {Id = 1, Name = "Focus", CarBrandId = 1 },
            new CarModel() {Id = 2, Name = "Fiesta", CarBrandId = 1},
            new CarModel() {Id = 3, Name = "Octavia", CarBrandId = 3},
            new CarModel() {Id = 4, Name = "Superb", CarBrandId = 3},
            new CarModel() {Id = 5, Name = "206", CarBrandId = 2},
            new CarModel() {Id = 6, Name = "206+", CarBrandId = 2},
            new CarModel() {Id = 7, Name = "207", CarBrandId = 2},
            new CarModel() {Id = 8, Name = "208", CarBrandId = 2},
        };

        modelBuilder.Entity<CarBrand>()
            .HasData(carBrands);

        modelBuilder.Entity<CarModel>()
            .HasData(carModels);

        modelBuilder.Entity<Car>()
            .HasData(new Car[]
            {
                new Car() { Id = 1, CarModelId = 1, Year = 2005, ValuePerDay = 60 },
                new Car() { Id = 2, CarModelId = 2, Year = 2015, ValuePerDay = 120 },
                new Car() { Id = 3, CarModelId = 3, Year = 2012, ValuePerDay = 70 },
                new Car() { Id = 4, CarModelId = 4, Year = 2005, ValuePerDay = 80 },
                new Car() { Id = 5, CarModelId = 5, Year = 2015, ValuePerDay = 200},
                new Car() { Id = 6, CarModelId = 6, Year = 2012, ValuePerDay =  150},
                new Car() { Id = 7, CarModelId = 7, Year = 2005, ValuePerDay =  110 },
                new Car() { Id = 8, CarModelId = 8, Year = 2015, ValuePerDay =  90 },
             });
    }
}
