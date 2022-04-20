using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Models
{
	public class ShelterNames
	{
		public string Name { get; set; }
		public string City { get; set; }
		public string Address { get; set; }

		public override string ToString()
		{
			return $"{Name} {City} {Address}";
		}
	}
}
