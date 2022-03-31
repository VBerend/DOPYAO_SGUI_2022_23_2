using DOPYAO_ADT_2021_22_2.Models;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public interface IAnimalRepository : IRepository<Animal>
	{
		void ChangeName(int id, string newName);
	}
}