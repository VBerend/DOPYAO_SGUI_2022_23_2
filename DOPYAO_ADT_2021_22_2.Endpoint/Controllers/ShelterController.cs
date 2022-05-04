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

        [Route("GetAllShelters")]
        [HttpGet]
        public IQueryable<Shelter> GetAllShelters()
        {
            return shelterLogic.GetAllShelters().AsQueryable();
        }

        [Route("GetOneShelter/{id}")]
        [HttpGet]
        public Shelter GetOneShelter(int id)
        {
            return shelterLogic.GetOneShelter(id);
        }

        [Route("InsertNewShelter/{ShelterName}/{City}/{Address}")]
        [HttpPost]
        public Shelter InsertNewShelter([FromBody] string sheltername, string city, string address)
        {
            return shelterLogic.InsertNewShelter(sheltername, city, address);
        }

        [Route("DeleteShelter/{id}")]
        [HttpDelete]
        public void DeleteShelter(int id)
        {
            shelterLogic.DeleteShelter(id);
        }

        [Route("ChangeShelterAddress/{id}/{newCity}/{newAddress}")]
        [HttpPut]
        public void ChangeShelterAddress(int id, string newCity, string newAddress)
        {
            shelterLogic.ChangeShelterAddress(id, newCity, newAddress);
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
