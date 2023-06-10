using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia.Models;

public class User
{
    public int Id { get; set; }
    public string? Pesel { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public virtual IEnumerable<RentedCar> RentedCars { get; set; }
}
