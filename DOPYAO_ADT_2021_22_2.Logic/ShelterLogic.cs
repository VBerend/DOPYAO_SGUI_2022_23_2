using DOPYAO_ADT_2021_22_2.Models;
using DOPYAO_ADT_2021_22_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Logic
{
	public class ShelterLogic : IShelterLogic
	{
        IShelterRepository shelterRepo;
        IAnimalRepository animalRepo;

        public ShelterLogic(IShelterRepository shelterRepo, IAnimalRepository animalRepo)
        {
            this.shelterRepo = shelterRepo;
            this.animalRepo = animalRepo;
        }

        public void ChangeShelterAddress(int id, string newCity, string newAddress)
        {
            this.shelterRepo.ChangeAddress(id, newCity, newAddress);
        }

        public void DeleteShelter(int id)
        {
            Shelter shelter = this.shelterRepo.GimmeOne(id);
            if (shelter == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");
            }
            else
            {
                this.shelterRepo.Delete(id);
            }
        }

        public IEnumerable<Shelter> GetAllShelters()
        {
            return this.shelterRepo.GimmeAll().AsQueryable();
        }

        public Shelter GetOneShelter(int id)
        {
            Shelter shelter = this.shelterRepo.GimmeOne(id);
            if (shelter == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");

            }
            return shelter;
        }

        public Shelter InsertNewShelter(string sheltername, string city, string address)
        {
            Shelter shelter = new Shelter()
            {
                ShelterName = sheltername,
                Address = address,
                City = city,
            };
            this.shelterRepo.Insert(shelter);
            return shelter;

        }
        public IList<MostAnimalFromShelters> animalFromShelters()
        {
            List<Shelter> shelters = shelterRepo.GimmeAll().ToList();
            List<Animal> animals = animalRepo.GimmeAll().ToList();

            var query2 = from shelter in shelters
                         join animal in animals
                         on shelter.Id equals animal.ShelterId
                         group animal by animal.ShelterId.Value into grp
                         let counting = grp.Count()
                         where grp.Count() >= 3
                         select new MostAnimalFromShelters()
                         {
                             Id = grp.Key,
                             Name = shelterRepo.GimmeOne(grp.Key).ShelterName,
                             Counter = counting,
                         };

            return query2.ToList();
        }


        public IList<DogShelter> DogShelters()
        {
            var query5 = from shelter in shelterRepo.GimmeAll().ToList()
                         join animal in animalRepo.GimmeAll().ToList()
                         on shelter.Id equals animal.ShelterId.Value
                         where animal.Specie == "Dog"
                         select new DogShelter()
                         {
                             Name = shelter.ShelterName,
                             AnimalName = animal.Name,
                         };

            return query5.ToList();
        }

        public IList<ShelterNames> SheltersName()
        {
            var query6 = from shelter in shelterRepo.GimmeAll().ToList()
                         select new ShelterNames()
                         {
                             Name = shelter.ShelterName,
                             Address = shelter.Address,
                             City = shelter.City
                         };
            return query6.ToList();

        }
    }
}
