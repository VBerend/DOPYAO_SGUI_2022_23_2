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
    public class ShelterController : ControllerBase
    {
        IShelterLogic shelterLogic;

        public ShelterController(IShelterLogic shelterLogic)
        {
            this.shelterLogic = shelterLogic;
        }

        [HttpGet]
        public IQueryable<Shelter> GetAllShelters()
        {
            return shelterLogic.GetAllShelters().AsQueryable();
        }

        [Route("{id}")]
        [HttpGet]
        public Shelter GetOneShelter(int id)
        {
            return shelterLogic.GetOneShelter(id);
        }

        [HttpPost]
        public Shelter InsertNewShelter([FromBody] Shelter newShelter)
        {
            return shelterLogic.InsertNewShelter(newShelter);
        }

        [HttpDelete("{id}")]
        public void DeleteShelter(int id)
        {
            shelterLogic.DeleteShelter(id);
        }

        [HttpPut]
        public void ChangeShelterAddress(Shelter newShelter)
        {
            shelterLogic.ChangeShelterAddress(newShelter.Id,newShelter.City,newShelter.Address);
        }

        [Route("animalfromshelter")]
        [HttpGet]
        public IList<MostAnimalFromShelters> animalFromShelters()
        {
            return shelterLogic.animalFromShelters();
        }

        [Route("Dogshelters")]
        [HttpGet]
        public IList<DogShelter> DogShelters()
        {
            return shelterLogic.DogShelters();
        }

        [Route("Shelters")]
        [HttpGet]
        public IList<ShelterNames> SheltersName()
        {
            return shelterLogic.SheltersName();
        }
    }
}
