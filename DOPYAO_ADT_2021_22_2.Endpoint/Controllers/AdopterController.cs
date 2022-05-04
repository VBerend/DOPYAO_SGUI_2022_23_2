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
	public class AdopterController : ControllerBase
	{
        IAdopterLogic adopterLogic;

        public AdopterController(IAdopterLogic adopterLogic)
        {
            this.adopterLogic = adopterLogic;
        }
        [Route("GetAllAdopters")]
        [HttpGet]
        public IQueryable<Adopter> GetAllAdopters()
        {
            return adopterLogic.GetAllAdopters();
        }

        [Route("GetOneAdopter/{id}")]
        [HttpGet]
        public Adopter GetOneAdopter(int id)
        {
            return adopterLogic.GetOneAdopter(id);
        }
        [Route("InsertNewAdopter/{adoptername}/{city}/{address}/{haskid}")]
        [HttpPost]
        public Adopter InsertNewAdopter([FromBody] string adoptername, string city, string address, bool haskid)
        {
            return adopterLogic.InsertNewAdopter(adoptername, city, address, haskid);
        }

        [Route("DeleteAdopter/{id}")]
        [HttpDelete]
        public void DeleteAdopter(int id)
        {
            adopterLogic.DeleteAdopter(id);
        }

        [Route("ChangeAdopterAddress/{id}/{newCity}/{newAddress}")]
        [HttpPut]
        public void ChangeAdopterAddress(int id, string newCity, string newAddress)
        {
            adopterLogic.ChangeAdopterAddress(id, newCity, newAddress);
        }
        [Route("ChangeAdopterHasKidBool/{id}/{hasKid}")]
        [HttpPut]
        public void ChangeAdopterHasKidBool(int id, bool hasKid)
        {
            adopterLogic.ChangeAdopterHasKidBool(id, hasKid);
        }


        [Route("animalfromadopter")]
        [HttpGet]
        public IList<GibAnimalFromAdopter> animalFromAdopter()
        {
            return adopterLogic.animalFromAdopter();
        }

        [Route("gib")]
        [HttpGet]
        public IList<AdoptersTherePetsWithName> adoptersTherePetsWithNames()
        {
            return adopterLogic.adoptersTherePetsWithNames();
        }

        [Route("AdopterInfo")]
        [HttpGet]
        public IList<AdopterInfo> adopterInfos()
        {
            return adopterLogic.adopterInfos();
        }
    }
}
