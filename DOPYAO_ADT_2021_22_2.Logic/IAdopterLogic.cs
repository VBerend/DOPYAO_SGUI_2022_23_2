using DOPYAO_ADT_2021_22_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace DOPYAO_ADT_2021_22_2.Logic
{
	public interface IAdopterLogic
	{
        void ChangeAdopterAddress(int id, string newCity, string newAddress);

        void ChangeAdopterHasKidBool(int id, bool hasKid);

        void DeleteAdopter(int id);

        Adopter GetOneAdopter(int id);

        IQueryable<Adopter> GetAllAdopters();

        Adopter InsertNewAdopter(Adopter newAdopter);

        IList<GibAnimalFromAdopter> animalFromAdopter();
        IList<AdoptersTherePetsWithName> adoptersTherePetsWithNames();
        IList<AdopterInfo> adopterInfos();
    }
}