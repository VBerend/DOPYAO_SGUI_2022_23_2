using DOPYAO_ADT_2021_22_2.Models;
using Microsoft.EntityFrameworkCore;

namespace DOPYAO_ADT_2021_22_2.Data
{
	public class ShelterDbContext : DbContext
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
				builder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\FosDbDotCom.mdf; Integrated Security = True; ");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// creating test objects
			Shelter shelter1 = new Shelter() { Id = 1, ShelterName = "Tetovált Állatmentők", City = "Budapest", Address = "Szófia utca, 1068" };
			Shelter shelter2 = new Shelter() { Id = 2, ShelterName = "Herosz", City = "Budapest", Address = "Brassói u. sarok, 1223" };
			Shelter shelter3 = new Shelter() { Id = 3, ShelterName = "Állatmentő Sereg", City = "Budapest", Address = "Nagymező u. 8, 1065" };
			Shelter shelter4 = new Shelter() { Id = 4, ShelterName = "Rex Dog Home Foundation", City = "Budapest", Address = "Óceánárok u. 33, 1048" };

			Adopter adopter1 = new Adopter() { Id = 1, Name = "Keanu Reeves", City = "Budapest", Address = "Dob utca 13", HasKid = true };
			Adopter adopter2 = new Adopter() { Id = 2, Name = "Mekk Elek", City = "Kaposvár", Address = "Bécsi út 96", HasKid = false };
			Adopter adopter3 = new Adopter() { Id = 3, Name = "Öblös Miklós", City = "Pécs", Address = "Peterdy utca 33", HasKid = false };
			Adopter adopter4 = new Adopter() { Id = 4, Name = "Anna Karenyina", City = "San Jose", Address = "Vaskapu utca 55", HasKid = false };
			Adopter adopter5 = new Adopter() { Id = 5, Name = "Austen Fry", City = "Fort Washington", Address = "valamilyen utca 69", HasKid = true };

			Animal animal1 = new Animal() { Id = 1, Name = "Rock", Gender = "Male", Specie = "Dog", Bodysize = "small", Age = 10, AdopterId = adopter1.Id, ShelterId = shelter3.Id };
			Animal animal2 = new Animal() { Id = 2, Name = "Nokedli", Gender = "Male", Specie = "Cat", Bodysize = "small", Age = 5, AdopterId = adopter2.Id, ShelterId = shelter3.Id };
			Animal animal3 = new Animal() { Id = 3, Name = "Nudli", Gender = "Female", Specie = "Dog", Bodysize = "Medium", Age = 3, AdopterId = adopter2.Id, ShelterId = shelter2.Id };
			Animal animal4 = new Animal() { Id = 4, Name = "Béla", Gender = "Male", Specie = "Birb", Bodysize = "Small", Age = 6, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
			Animal animal5 = new Animal() { Id = 5, Name = "Csili", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 2, AdopterId = adopter3.Id, ShelterId = shelter1.Id };
			Animal animal6 = new Animal() { Id = 6, Name = "Lady", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 4, AdopterId = adopter4.Id, ShelterId = shelter2.Id };
			Animal animal7 = new Animal() { Id = 7, Name = "Buttercup", Gender = "Female", Specie = "Catto", Bodysize = "smol", Age = 2, AdopterId = adopter4.Id, ShelterId = shelter4.Id }; // she's kinda special
			Animal animal8 = new Animal() { Id = 8, Name = "krém", Gender = "Female", Specie = "Cat", Bodysize = "Medium", Age = 6, AdopterId = adopter5.Id, ShelterId = shelter1.Id };
			Animal animal9 = new Animal() { Id = 9, Name = "Pisztácia", Gender = "Male", Specie = "Birb", Bodysize = "Medium", Age = 1, AdopterId = adopter5.Id, ShelterId = shelter1.Id };
			Animal animal10 = new Animal() { Id = 10, Name = "HolymotherofGod", Gender = "Male", Specie = "Dog", Bodysize = "Large", Age = 10, AdopterId = adopter5.Id, ShelterId = shelter3.Id };

			// connections
			modelBuilder.Entity<Animal>(entity =>
			{
				entity.HasOne(animal => animal.Adopter)
					.WithMany(adopter => adopter.Animals)
					.HasForeignKey(animal => animal.AdopterId)
					.OnDelete(DeleteBehavior.SetNull);
			});

			modelBuilder.Entity<Animal>(entity =>
			{
				entity.HasOne(animal => animal.Shelter)
				 .WithMany(shelter => shelter.Animals)
				 .HasForeignKey(animal => animal.ShelterId)
				 .OnDelete(DeleteBehavior.SetNull);
			});

			// adding the objects to the correct tables
			modelBuilder.Entity<Animal>().HasData(animal1, animal2, animal3, animal4, animal5, animal6, animal7, animal8, animal9, animal10);
			modelBuilder.Entity<Adopter>().HasData(adopter1, adopter2, adopter3, adopter4, adopter5);
			modelBuilder.Entity<Shelter>().HasData(shelter1, shelter2, shelter3, shelter4);

		}
	}
}

