using DOPYAO_ADT_2021_22_2.Models;
using DOPYAO_ADT_2021_22_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Logic
{
	public class AnimalLogic : IAnimalLogic
	{
        IAnimalRepository animalRepo;
        IAdopterRepository adopterRepo;

        public AnimalLogic(IAnimalRepository animalRepo)
        {
            this.animalRepo = animalRepo;
        }

        public void ChangeAnimalName(int id, string newName)
        {
            this.animalRepo.ChangeName(id, newName);
        }

        public void DeleteAnimal(int id)
        {
            Animal animal = this.animalRepo.GimmeOne(id);
            if (animal == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");
            }
            else
            {
                this.animalRepo.Delete(id);
            }
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            return this.animalRepo.GimmeAll().AsQueryable();
        }

        public Animal GetOneAnimal(int id)
        {
            Animal animal = this.animalRepo.GimmeOne(id);
            if (animal == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");

            }
            return animal;
        }

        public Animal InsertNewAnimal(string name, string gender, string specie, string bodysize, int age)
        {
            Animal animal = new Animal()
            {
                Name = name,
                Gender = gender,
                Specie = specie,
                Bodysize = bodysize,
                Age = age,
            };
            this.animalRepo.Insert(animal);
            return animal;
        }
    }
}
