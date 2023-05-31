using DOPYAO_ADT_2021_22_2.Logic;
using DOPYAO_ADT_2021_22_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Endpoint.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class AnimalController : ControllerBase
	{
        IAnimalLogic animalLogic;

        public AnimalController(IAnimalLogic animalLogic)
        {
            this.animalLogic = animalLogic;
        }

        [HttpGet]
        public IQueryable<Animal> GetAllAnimals()
        {
            return animalLogic.GetAllAnimals().AsQueryable();
        }

        [Route("{id}")]
        [HttpGet]
        public Animal GetOneAnimal(int id)
        {
            return animalLogic.GetOneAnimal(id);
        }

        [Route("InsertNewAnimal/{name}/{gender}/{specie}/{bodysize}/{age}")]
        [HttpPost]
        public Animal InsertNewAnimal([FromBody] string name, string gender, string specie, string bodysize, int age)
        {
            return animalLogic.InsertNewAnimal(name, gender, specie, bodysize, age);
        }

        [Route("DeleteAnimal/{id}")]
        [HttpDelete]
        public void DeleteAnimal(int id)
        {
            animalLogic.DeleteAnimal(id);
        }

        [HttpPut]
        public void ChangeAnimalName(Animal animal)
        {
            animalLogic.ChangeAnimalName(animal.Id, animal.Name);
        }
    }
}
