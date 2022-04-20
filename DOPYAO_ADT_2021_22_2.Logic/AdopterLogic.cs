using DOPYAO_ADT_2021_22_2.Models;
using DOPYAO_ADT_2021_22_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOPYAO_ADT_2021_22_2.Logic
{
	public class AdopterLogic : IAdopterLogic
	{
		IAdopterRepository adopterRepo;
		IAnimalRepository animalRepo;

		public AdopterLogic(IAdopterRepository adopterRepo, IAnimalRepository animalRepo)
		{
			this.adopterRepo = adopterRepo;
			this.animalRepo = animalRepo;
		}

		public void ChangeAdopterAddress(int id, string newCity, string newAddress)
		{
			this.adopterRepo.ChangeAddress(id, newCity, newAddress);
		}

		public void ChangeAdopterHasKidBool(int id, bool hasKid)
		{
			this.adopterRepo.ChangeHasKids(id, hasKid);
		}

		public void DeleteAdopter(int id)
		{
			Adopter adopter = this.adopterRepo.GimmeOne(id);
			if (adopter == null)
			{
				throw new InvalidOperationException("ERROR: No corresponding record!");
			}
			else
			{
				this.adopterRepo.Delete(id);
			}
		}

		public IQueryable<Adopter> GetAllAdopters()
		{
			return this.adopterRepo.GimmeAll();
		}

		public Adopter GetOneAdopter(int id)
		{
			Adopter adopter = this.adopterRepo.GimmeOne(id);
			if (adopter == null)
			{
				throw new InvalidOperationException("ERROR: No corresponding record!");

			}
			return this.adopterRepo.GimmeOne(id);
		}

		public Adopter InsertNewAdopter(string adoptername, string city, string address, bool haskid)
		{
			Adopter adopter = new Adopter()
			{
				Name = adoptername,
				Address = address,
				City = city,
				HasKid = haskid,
			};
			this.adopterRepo.Insert(adopter);
			return adopter;
		}

		public IList<GibAnimalFromAdopter> animalFromAdopter()
		{
			var query1 = from adopter in adopterRepo.GimmeAll().ToList()
						 join animal in animalRepo.GimmeAll().ToList()
						 on adopter.Id equals animal.AdopterId
						 group animal by animal.AdopterId.Value into grp
						 let counting = grp.Count()
						 select new GibAnimalFromAdopter()
						 {
							 Id = grp.Key,
							 Name = adopterRepo.GimmeOne(grp.Key).Name,
							 Counter = counting,
						 };

			return query1.ToList();
		}

		public IList<AdoptersTherePetsWithName> adoptersTherePetsWithNames()
		{
			var query3 = from adopter in adopterRepo.GimmeAll().ToList()
						 join animal in animalRepo.GimmeAll().ToList()
						 on adopter.Id equals animal.AdopterId.Value
						 orderby adopter.Name ascending
						 select new AdoptersTherePetsWithName()
						 {
							 Id = animal.Id,
							 Name = adopter.Name,
							 AnimalName = animal.Name,
						 };

			return query3.ToList();
		}

		public IList<AdopterInfo> adopterInfos()
		{
			var query4 = from adopter in adopterRepo.GimmeAll().ToList()
						 join animal in animalRepo.GimmeAll().ToList()
						 on adopter.Id equals animal.AdopterId.Value
						 where adopter.HasKid = true && animal.Bodysize == "Large" && animal.Age > 5
						 select new AdopterInfo()
						 {
							 Name = adopter.Name,
							 AnimalName = animal.Name,
							 Adopterhaskid = adopter.HasKid,
							 AnimalAge = animal.Age,
							 AnimalBodysize = animal.Bodysize,
						 };
			return query4.ToList();
		}
	}

}
