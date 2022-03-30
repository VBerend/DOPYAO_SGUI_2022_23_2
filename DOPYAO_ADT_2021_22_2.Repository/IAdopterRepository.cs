using DOPYAO_ADT_2021_22_2.Models;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public interface IAdopterRepository : IRepository<Adopter>
	{
		void ChangeAddress(int id, string newCity, string newAddress);

		void ChangeHasKids(int id, bool hasKid);
	}
}