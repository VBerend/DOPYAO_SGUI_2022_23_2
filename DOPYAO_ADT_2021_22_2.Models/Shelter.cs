using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DOPYAO_ADT_2021_22_2.Models
{
	[Table("shelter")]
	public class Shelter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(100)]
		[Required]
		public string ShelterName { get; set; }

		[MaxLength(100)]
		[Required]
		public string City { get; set; }

		[MaxLength(100)]
		[Required]
		public string Address { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Animal> Animals { get; set; }

		public Shelter()
		{
			Animals = new HashSet<Animal>();
		}

		public override string ToString()
		{
			return $"\n{this.Id} {this.ShelterName} - {this.City} - {this.Address} - {this.Animals}";
		}

	}
}
