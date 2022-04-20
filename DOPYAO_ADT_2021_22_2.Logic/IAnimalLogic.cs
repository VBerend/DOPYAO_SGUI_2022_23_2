using DOPYAO_ADT_2021_22_2.Models;
using System.Collections.Generic;

namespace DOPYAO_ADT_2021_22_2.Logic
{
	internal interface IAnimalLogic
	{
		void ChangeAnimalName(int id, string newName);

		void DeleteAnimal(int id);

		Animal GetOneAnimal(int id);

		IEnumerable<Animal> GetAllAnimals();

		Animal InsertNewAnimal(string name, string gender, string specie, string bodysize, int age);
	}
}