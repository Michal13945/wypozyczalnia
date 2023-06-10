using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia.Models;

public class Car
{
    public int Id { get; set; }
    public int Year { get; set; }
    public decimal ValuePerDay { get; set; }

    public int CarModelId { get; set; }
    public virtual CarModel? CarModel { get; set; }
    public virtual IEnumerable<RentedCar> RentedCars { get; set; }


    public override string ToString()
    {
        return $"{CarModel?.Brand.Name} {CarModel?.Name} rocznik {Year}";
    }
}

