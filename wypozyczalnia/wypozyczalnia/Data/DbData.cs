using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalnia.Models;

namespace wypozyczalnia.Data;

public static class DbData
{
    public static void AddCar(Car car)
    {
        using (var db = new AppDbContext())
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }
    }

    public static Car? GetCar(int id)
    {
        using (var db = new AppDbContext())
        {
            return db.Cars.FirstOrDefault(x => x.Id == id);
        }
    }

    public static IEnumerable<Car> GetCars()
    {
        using (var db = new AppDbContext())
        {
            return db.Cars
                .Include(x => x.CarModel)
                .ThenInclude(x => x.Brand)
                .Include(x => x.RentedCars)
                .ToList();
        }
    }

    public static User? GetUser(string pesel)
    {
        using (var db = new AppDbContext())
        {
            return db.Users.FirstOrDefault(x => x.Pesel == pesel);
        }
    }

    public static void AddUser(User user)
    {
        using (var db = new AppDbContext())
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }

    public static void UpdateUser(User user)
    {
        using (var db = new AppDbContext())
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
    }

    public static IEnumerable<User> GetUsers()
    {
        using (var db = new AppDbContext())
        {
            return db.Users.ToList();
        }
    }

    public static void AddRentedCar(RentedCar rentedCar)
    {
        using (var db = new AppDbContext())
        {
            db.RentedCars.Add(rentedCar);
            db.SaveChanges();
        }
    }

    public static IEnumerable<RentedCar> GetRentedCars()
    {
        using (var db = new AppDbContext())
        {
            return db.RentedCars.ToList();
        }
    }
}
