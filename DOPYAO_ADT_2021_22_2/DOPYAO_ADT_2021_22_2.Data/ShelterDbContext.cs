using DOPYAO_ADT_2021_22_2.Models;
using Microsoft.EntityFrameworkCore;

namespace DOPYAO_ADT_2021_22_2.Data
{public class ShelterDbContext
	{
		public ShelterDbContext(DbContextOptions<ShelterDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public virtual DbSet<Animal> Animals { get; set; }
		public virtual DbSet<Adopter> Adopters { get; set; }
		public virtual DbSet<Shelter> Shelters { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (builder != null && !builder.IsConfigured)
			{
				builder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database.mdf; Integrated Security = True; ");
			}
		}
	}
}

