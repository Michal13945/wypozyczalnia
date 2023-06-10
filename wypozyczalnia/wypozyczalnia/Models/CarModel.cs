using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CarBrandId { get; set; }
        public virtual CarBrand Brand { get; set; }
        public virtual IEnumerable<Car> Cars { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
