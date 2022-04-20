using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Models
{
	public class DogShelter
    {
        public string Name { get; set; }

        public string AnimalName { get; set; }

        public override string ToString()
        {
            return $"{Name} has dog(s) named {AnimalName}.";
        }
    }
}
