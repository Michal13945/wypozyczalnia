using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<CarModel> Models { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
