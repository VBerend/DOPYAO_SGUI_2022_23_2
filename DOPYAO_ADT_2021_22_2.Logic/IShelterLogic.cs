using DOPYAO_ADT_2021_22_2.Models;
using System.Collections.Generic;

namespace DOPYAO_ADT_2021_22_2.Logic
{
	public interface IShelterLogic
	{
        void ChangeShelterAddress(int id, string newCity, string newAddress);

        void DeleteShelter(int id);

        Shelter GetOneShelter(int id);

        IEnumerable<Shelter> GetAllShelters();

        Shelter InsertNewShelter(Shelter newShelter);

        IList<MostAnimalFromShelters> animalFromShelters();
        IList<DogShelter> DogShelters();

        IList<ShelterNames> SheltersName();
    }
}