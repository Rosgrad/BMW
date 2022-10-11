using BMW.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Domain.Entity
{
    public class Cars
    {
        public int Id { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }  
        public decimal Price { get;set; }
        public DateTime DataCreate { get;set; }
        public TypeCar TypeCar { get; set; }
    }
}
