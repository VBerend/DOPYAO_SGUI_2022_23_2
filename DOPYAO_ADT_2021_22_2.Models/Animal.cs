using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DOPYAO_ADT_2021_22_2.Models
{
	[Table("animal")]
	public class Animal
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(100)]
		[Required]
		public string Name { get; set; }

		[MaxLength(10)]
		[Required]
		public string Gender { get; set; }

		[MaxLength(100)]
		[Required]
		public string Specie { get; set; }

		[MaxLength(100)]
		[Required]
		public string Bodysize { get; set; }

		[Required]
		public int Age { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual Adopter Adopter { get; set; }

		[ForeignKey(nameof(Adopter))]
		public int? AdopterId { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual Shelter Shelter { get; set; }

		[ForeignKey(nameof(Shelter))]
		public int? ShelterId { get; set; }

		public override string ToString()
		{
			return $"\n{this.Id} {this.Name} - {this.Gender} - {this.Specie} - {this.Bodysize} - {this.Age}";
		}

	}
}
