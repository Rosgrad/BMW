using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Domain.ViewModel.Cars
{
    public class CarsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }    

        public decimal Price { get; set; }

        public string DataCreate { get; set; }
        
        public string TypeCar { get; set; } 
    }
}
