using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Models
{
	public class MostAnimalFromShelters
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Counter { get; set; }


        public override string ToString()
        {
            return $"{Name} had {Counter} pets before adopters took them :3";
        }
    }
}
