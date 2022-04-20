using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Models
{
	public class AdopterInfo
	{
        public string Name { get; set; }
        public string AnimalName { get; set; }
        public string AnimalBodysize { get; set; }
        public int AnimalAge { get; set; }
        public bool Adopterhaskid { get; set; }


        public override string ToString()
        {
            return $" Adopter name: { Name}, Adopter has kid :{ Adopterhaskid},has {AnimalBodysize} sized pet(s), and has {AnimalAge} years old pet";
        }


    }
}
