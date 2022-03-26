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
	[Table("adopter")]
	public class Adopter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(100)]
		[Required]
		public string Name { get; set; }

		[MaxLength(100)]
		[Required]
		public string Address { get; set; }

		[MaxLength(100)]
		[Required]
		public string City { get; set; }

		[Required]
		public bool HasKid { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Animal> Animals { get; }

		public override string ToString()
		{
			return $"\n{this.Id}, {this.Name}, {this.HasKid}, {this.Animals.Count}, {this.Address}, {this.City}";
		}

		public Adopter()
		{
			Animals = new HashSet<Animal>();
		}
	}
}
