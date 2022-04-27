using ConsoleTools;
using System;
using System.Threading;
using DOPYAO_ADT_2021_22_2.Models;

namespace DOPYAO_ADT_2021_22_2.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			#region linq
			private static void GibAnimalFromAdopter(RestService rest)
			{
				Console.WriteLine("This query should return each adopter along with the number of pets they have adopted");
				var adopteranimallist = rest.Get<GibAnimalFromAdopter>("adopter/animalfromadopter");

				foreach (var item in adopteranimallist)
				{
					Console.WriteLine(item);

				}
				Console.ReadLine();

			}

			private static void animalFromShelters(RestService rest)
			{
				Console.WriteLine("This query should return each shelter which had more than 3 animal in it before adopters came and took them :3");
				var shelteranimallist = rest.Get<MostAnimalFromShelters>("shelter/animalfromshelter");

				foreach (var item in shelteranimallist)
				{
					Console.WriteLine(item);

				}
				Console.ReadLine();

			}

			private static void adoptersTherePetsWithNames(RestService rest)
			{
				Console.WriteLine("This query should return each adopter along with their pets and theirs name");
				var adopterpetswithnameslist = rest.Get<AdoptersTherePetsWithName>("adopter/gib");

				foreach (var item in adopterpetswithnameslist)
				{
					Console.WriteLine(item);

				}
				Console.ReadLine();

			}

			private static void adopterInfos(RestService rest)
			{
				Console.WriteLine("This query should return each adopter who has kid(s) and has an older pet which bodysize is large");
				var valami = rest.Get<AdopterInfo>("adopter/AdopterInfo");

				foreach (var item in valami)
				{
					Console.WriteLine(item);

				}
				Console.ReadLine();

			}

			private static void dogShelters(RestService rest)
			{
				Console.WriteLine("This query should return which shelters contains dogs");
				var dogshelterlist = rest.Get<DogShelter>("shelter/Dogshelters");

				foreach (var item in dogshelterlist)
				{
					Console.WriteLine(item);

				}
				Console.ReadLine();

			}
			private static void SheltersName(RestService rest)
			{
				Console.WriteLine("This query should return each shelters its just a simple query");
				var ShelterList = rest.Get<ShelterNames>("shelter/Shelters");

				foreach (var item in ShelterList)
				{
					Console.WriteLine(item);

				}
				Console.ReadLine();

			}


			#endregion
		}
	}
}
