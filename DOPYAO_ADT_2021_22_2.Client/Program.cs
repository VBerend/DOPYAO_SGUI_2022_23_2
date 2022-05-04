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
		#region Menu
			Thread.Sleep(8000);
			RestService rserv = new RestService("http://localhost:38088");

			var adoptermenu = new ConsoleMenu()
				.Add("CREATE A NEW ADOPTER", () => AddNewAdopter(rserv))
				.Add("GET ONE ADOPTER", () => GetOneAdopter(rserv))
				.Add("GET ADOPTERS", () => GetAdopters(rserv))
				.Add("DELETE ADOPTER", () => DeleteAdopter(rserv))
				.Add("GO BACK", ConsoleMenu.Close)
				.Configure(config =>
				{
					config.Selector = "--> ";
					config.SelectedItemBackgroundColor = ConsoleColor.Red;
				});

			var animalmenu = new ConsoleMenu()
				.Add("CREATE A NEW ANIMAL", () => InsertNewAnimal(rserv))
				.Add("GET ONE ANIMAL", () => GetOneAnimal(rserv))
				.Add("GET ANIMALS", () => GetAllAnimals(rserv))
				.Add("DELETE ANIMAL", () => DeleteAnimal(rserv))
				.Add("GO BACK", ConsoleMenu.Close)
				.Configure(config =>
				{
					config.Selector = "--> ";
					config.SelectedItemBackgroundColor = ConsoleColor.Red;
				});

			var sheltermenu = new ConsoleMenu()
				.Add("CREATE A NEW SHELTER", () => InsertNewShelter(rserv))
				.Add("GET ONE SHELTER", () => GetOneShelter(rserv))
				.Add("GET SHELTER", () => GetAllShelters(rserv))
				.Add("DELETE SHELTER", () => DeleteShelter(rserv))
				.Add("GO BACK", ConsoleMenu.Close)
				.Configure(config =>
				{
					config.Selector = "--> ";
					config.SelectedItemBackgroundColor = ConsoleColor.Red;
				});

			var crudmenu = new ConsoleMenu()
				.Add("Adopters", () => adoptermenu.Show())
				.Add("Animals", () => animalmenu.Show())
				.Add("Shelters", () => sheltermenu.Show())
				.Add("GO BACK", ConsoleMenu.Close)
				.Configure(config =>
				{
					config.Selector = "--> ";
					config.SelectedItemBackgroundColor = ConsoleColor.Red;
				});

			var linqmenu = new ConsoleMenu()
				.Add("Adopters and Animals",() => GibAnimalFromAdopter(rserv)) 		
				.Add("Most Animal got permanent home from shelters",() => animalFromShelters(rserv)) 		
				.Add("Adopters and the name of there pets",() => adoptersTherePetsWithNames(rserv)) 		
				.Add("Adopter info",() => adopterInfos(rserv)) 		
				.Add("Dog Shelters",() => dogShelters(rserv)) 		
				.Add("Shelter List",() => SheltersName(rserv)) 		

				.Configure(config =>
				{
					config.Selector = "--> ";
					config.SelectedItemBackgroundColor = ConsoleColor.Red;
				});

			var menu = new ConsoleMenu()
			.Add("CRUD methods", () => crudmenu.Show())
			.Add("LINQ queries", () => linqmenu.Show())
			.Add("EXIT", ConsoleMenu.Close)
			.Configure(config =>
			{
				config.Selector = "]=> ";
				config.SelectedItemBackgroundColor = ConsoleColor.Red;
			});

			menu.Show();
		}
		#endregion 

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

		#region Adopter

			// Create
			static void AddNewAdopter(RestService rest)
			{
				try
				{
					Console.WriteLine("\n:: CREATING A NEW ADOPTER ::\n");
					Console.WriteLine("TYPE THE NAME!");
					string name = Console.ReadLine();
					Console.WriteLine("TYPE THE ADDRESS!");
					string address = Console.ReadLine();
					Console.WriteLine("TYPE THE CITY!");
					string city = Console.ReadLine();
					Console.WriteLine("TYPE TRUE IF HAS KIDS OR TYPE FALSE IF NOT!");
					bool hasKid = bool.Parse(Console.ReadLine());
					rest.Post(new Adopter { Name = name, Address = address, City = city, HasKid = hasKid, }, "ADOPTER");
					Console.WriteLine("\n:: ADOPTER CREATED ::");
					Console.ReadKey();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			// Read
			static void GetOneAdopter(RestService rest)
			{
				Console.WriteLine("PLEASE TELL ME WHICH ADOPTER DO YOU WANNA GET [id]");
				int id = int.Parse(Console.ReadLine());
				var adopter = rest.Get<Adopter>(id, $"adopter/GetOneAdopter/{id}");
				Console.WriteLine(adopter.ToString());
				Console.WriteLine("\n Press any button to continue");
				Console.ReadLine();
			}

			static void GetAdopters(RestService rest)
			{
				try
				{
					Console.WriteLine("ADOPTER LIST");
					var adopters = rest.Get<Adopter>("adopter/GetAllAdopters");
					adopters.ForEach(x => Console.WriteLine(x.ToString()));
					Console.WriteLine("\n Press any button to continue");
					Console.ReadLine();
				}
				catch (Exception e)
				{

					Console.WriteLine(e.Message);
				}

			}

		//Update

		//public void ChangeAdopterAddress(RestService rest)
		//{
		//	try
		//	{
		//		Console.WriteLine("PLEASE TELL ME WHERE DID THE ADOPTER MOVED(CITY)");
		//		string city = Console.ReadLine();
		//		rest.Post<string>(city, "ADOPTER");
		//		Console.WriteLine("PLEASE TELL ME WHERE DID THE ADOPTER MOVED(ADDRESS)");
		//		string address = Console.ReadLine();
		//		rest.Post<string>(address, "ADOPTER");
		//		Console.WriteLine("");

		//	}
		//	catch (Exception e)
		//	{
		//		Console.WriteLine(e.Message);
		//	}
		//}

		//public void ChangeAdopterHasKidBool(int id, bool hasKid)
		//{
		//	this.adopterRepo.ChangeHasKids(id, hasKid);
		//}


		// Delete
		static void DeleteAdopter(RestService rest)
			{
				Console.WriteLine("PLEASE TELL ME WHICH ADOPTER DO YOU WANNA DELETE [id] (FROM EXISTENCE)");
				int id = int.Parse(Console.ReadLine());
				rest.Delete(id, $"adopter/DeleteAdopter/{id}");
				Console.WriteLine("ADOPTER DELETED, MAYBE THE ARCHIVE ARE INCOMPLETE ");
				Console.WriteLine("\n Press any button to continue");
				Console.ReadLine();
			}

		#endregion

		#region Animal

		// Create
		static void InsertNewAnimal(RestService rest)
		{
			try
			{
				Console.WriteLine("\n:: CREATING A NEW ANIMAL ::\n");
				Console.WriteLine("TYPE THE NAME!");
				string name = Console.ReadLine();
				Console.WriteLine("TYPE THE GENDER!");
				string gender = Console.ReadLine();
				Console.WriteLine("TYPE THE SPECIE!");
				string specie = Console.ReadLine();
				Console.WriteLine("TYPE THE AGE!");
				int age = int.Parse(Console.ReadLine());
				rest.Post(new Animal { Name = name, Gender = gender, Specie = specie, Age = age, }, "animal");
				Console.WriteLine("\n:: ANIMAL CREATED ::");
				Console.ReadKey();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		// Read
		static void GetOneAnimal(RestService rest)
		{
			Console.WriteLine("PLEASE TELL ME WHICH ANIMAL DO YOU WANNA GET [id]");
			int id = int.Parse(Console.ReadLine());
			var animal = rest.Get<Animal>(id, $"animal/GetOneAnimal/{id}");
			Console.WriteLine(animal.ToString());
			Console.WriteLine("\n Press any button to continue");
			Console.ReadLine();
		}

		static void GetAllAnimals(RestService rest)
		{
			try
			{
				Console.WriteLine("ANIMAL LIST");
				var animal = rest.Get<Adopter>("animal/GetAllAnimals");
				animal.ForEach(x => Console.WriteLine(x.ToString()));
				Console.WriteLine("\n Press any button to continue");
				Console.ReadLine();
			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}

		}

		//Update

		//public void ChangeAdopterAddress(int id, string newCity, string newAddress)
		//{
		//	this.adopterRepo.ChangeAddress(id, newCity, newAddress);
		//}


		// Delete
		static void DeleteAnimal(RestService rest)
		{
			Console.WriteLine("PLEASE TELL ME WHICH ANIMAL DO YOU WANNA DELETE [id]");
			int id = int.Parse(Console.ReadLine());
			rest.Delete(id, "ANIMAL");
			Console.WriteLine("ANIMAL DELETED, MAYBE YOUR ARCHIVE ARE INCOMPLETE ");
			Console.WriteLine("\n Press any button to continue");
			Console.ReadLine();
		}

		#endregion

		#region Shelter

		// Create
		static void InsertNewShelter(RestService rest)
		{
			try
			{
				Console.WriteLine("\n:: CREATING A NEW SHELTER ::\n");
				Console.WriteLine("TYPE THE NAME!");
				string sheltername = Console.ReadLine();
				Console.WriteLine("TYPE THE GENDER!");
				string city = Console.ReadLine();
				Console.WriteLine("TYPE THE SPECIE!");
				string address = Console.ReadLine();
				rest.Post(new Shelter { ShelterName = sheltername, City = city, Address = address, }, "shelter");
				Console.WriteLine("\n:: SHELTER CREATED ::");
				Console.ReadKey();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		// Read
		static void GetOneShelter(RestService rest)
		{
			Console.WriteLine("PLEASE TELL ME WHICH SHELTER DO YOU WANNA GET [id]");
			int id = int.Parse(Console.ReadLine());
			var animal = rest.Get<Animal>(id, "SHELTER");
			Console.WriteLine(animal.ToString());
			Console.WriteLine("\n Press any button to continue");
			Console.ReadLine();
		}

		static void GetAllShelters(RestService rest)
		{
			try
			{
				Console.WriteLine("SHELTER LIST");
				var shelters = rest.Get<Shelter>("SHELTER");
				shelters.ForEach(x => Console.WriteLine(x.ToString()));
				Console.WriteLine("\n Press any button to continue");
				Console.ReadLine();
			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}

		}


		//Update

		//public void ChangeShelterAddress(int id, string newCity, string newAddress)
		//{
		//	shelterLogic.ChangeShelterAddress(id, newCity, newAddress);
		//}


		// Delete
		static void DeleteShelter(RestService rest)
		{
			Console.WriteLine("PLEASE TELL ME WHICH SHELTER DO YOU WANNA DELETE [id] (FROM EXISTENCE)");
			int id = int.Parse(Console.ReadLine());
			rest.Delete(id, "SHELTER");
			Console.WriteLine("SHELTER DELETED, MAYBE YOUR ARCHIVE ARE INCOMPLETE ");
			Console.WriteLine("\n Press any button to continue");
			Console.ReadLine();
		}

		#endregion
	}
}
