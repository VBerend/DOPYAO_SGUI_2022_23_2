using DOPYAO_ADT_2021_22_2.Logic;
using DOPYAO_ADT_2021_22_2.Models;
using DOPYAO_ADT_2021_22_2.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOPYAO_ADT_2021_22_2.Test
{
	[TestFixture]
	public class CRUDTests
	{
        #region CRUD TEST
        [Test]
        public void TestCreateAdopter()
        {
            Mock<IAdopterRepository> mockedAdopterRepo = new Mock<IAdopterRepository>(MockBehavior.Loose);
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);
            AdopterLogic adopterLogic = new AdopterLogic(mockedAdopterRepo.Object, mockedAnimalRepo.Object);
            mockedAdopterRepo.Setup(repo => repo.Insert(It.IsAny<Adopter>()));
            adopterLogic.InsertNewAdopter("Teszt Elek", "Csudapest", "Main street 42.", false);
            mockedAdopterRepo.Verify(repo => repo.Insert(It.IsAny<Adopter>()), Times.Once);
        }

        [Test]
        public void TestCreateAnimal()
        {
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);
            AnimalLogic animalLogic = new AnimalLogic(mockedAnimalRepo.Object);
            mockedAnimalRepo.Setup(repo => repo.Insert(It.IsAny<Animal>()));
            animalLogic.InsertNewAnimal("Fluffy", "female", "gatto", "smoll", 1);
            mockedAnimalRepo.Verify(repo => repo.Insert(It.IsAny<Animal>()), Times.Once);
        }

        [Test]
        public void TestCreateShelter()
        {
            Mock<IShelterRepository> mockedShelterRepo = new Mock<IShelterRepository>(MockBehavior.Loose);
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);
            ShelterLogic shelterLogic = new ShelterLogic(mockedShelterRepo.Object, mockedAnimalRepo.Object);
            mockedShelterRepo.Setup(repo => repo.Insert(It.IsAny<Shelter>()));
            shelterLogic.InsertNewShelter("Homeless Kitty Network", "Csudapest", "Other Street 19.");
            mockedShelterRepo.Verify(repo => repo.Insert(It.IsAny<Shelter>()), Times.Once);
        }

        [Test]
        public void TestDeleteAnimal()
        {
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);

            List<Animal> testAnimals = new List<Animal>()
            {
                new Animal() { Id = 1, Name = "Bob", Gender = "male", Specie = "dog", Bodysize = "average", Age = 3, ShelterId = 1, AdopterId = 2 },
                new Animal() { Id = 2, Name = "Luna", Gender = "female", Specie = "cat", Bodysize = "fat", Age = 7, ShelterId = 3, AdopterId = 5 },
                new Animal() { Id = 3, Name = "Rex", Gender = "male", Specie = "dog", Bodysize = "small", Age = 1, ShelterId = 1, AdopterId = 4 },
            };

            mockedAnimalRepo.Setup(repo => repo.GimmeAll()).Returns(testAnimals.AsQueryable());
            mockedAnimalRepo.Setup(repo => repo.GimmeOne(It.IsAny<int>())).Returns((int i) => testAnimals.Where(x => x.Id == i).Single());
            mockedAnimalRepo.Setup(repo => repo.Delete(It.IsAny<int>()));

            AnimalLogic animalLogic = new AnimalLogic(mockedAnimalRepo.Object);
            animalLogic.DeleteAnimal(2);
            mockedAnimalRepo.Verify(repo => repo.Delete(2));

        }
   

        [Test]
        public void TestChangeAdopterAddress()
        {
            Mock<IAdopterRepository> mockedAdopterRepo = new Mock<IAdopterRepository>(MockBehavior.Loose);
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);

            List<Adopter> testAdopters = new List<Adopter>()
            {
                new Adopter() { Id = 1, Name = "John Doe", City="Kiskunfélegyháza", Address="Petőfi Sándor utca 5.", HasKid=true},
                new Adopter() { Id = 2, Name = "Béla Béla", City="Vác", Address="Fő út 37.", HasKid=false},
            };

            mockedAdopterRepo.Setup(repo => repo.GimmeAll()).Returns(testAdopters.AsQueryable());
            mockedAdopterRepo.Setup(x => x.GimmeOne(It.IsAny<int>())).Returns((int i) => testAdopters.Where(x => x.Id == i).Single());

            AdopterLogic adopterLogic = new AdopterLogic(mockedAdopterRepo.Object, mockedAnimalRepo.Object);

            adopterLogic.ChangeAdopterAddress(1, "Szeged", "Kötő utca 2.");
            mockedAdopterRepo.Verify(repo => repo.ChangeAddress(1, "Szeged", "Kötő utca 2."), Times.Once);
        }
        #endregion

        #region LinQ Test

        ShelterLogic shelterLogic;
        AdopterLogic adopterLogic;
        AnimalLogic animalLogic;

        [SetUp]
        public void Setup()
        {
            Mock<IAdopterRepository> mockedAdopterRepo = new Mock<IAdopterRepository>();
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>();
            Mock<IShelterRepository> mockedShelterRepo = new Mock<IShelterRepository>();

            mockedAdopterRepo.Setup(x => x.GimmeAll()).Returns(FakeAdopters);
            mockedAnimalRepo.Setup(x => x.GimmeAll()).Returns(FakeAnimals);
            mockedShelterRepo.Setup(x => x.GimmeAll()).Returns(FakeShelters);

            mockedAnimalRepo.Setup(repo => repo.GimmeOne(It.IsAny<int>())).Returns<int>((id) => FakeAnimals().FirstOrDefault(x => x.Id == id));
            mockedShelterRepo.Setup(repo => repo.GimmeOne(It.IsAny<int>())).Returns<int>((id) => FakeShelters().FirstOrDefault(x => x.Id == id));
            mockedAdopterRepo.Setup(repo => repo.GimmeOne(It.IsAny<int>())).Returns<int>((id) => FakeAdopters().FirstOrDefault(x => x.Id == id));

            this.adopterLogic = new AdopterLogic(mockedAdopterRepo.Object, mockedAnimalRepo.Object);
            this.shelterLogic = new ShelterLogic(mockedShelterRepo.Object, mockedAnimalRepo.Object);
        }

        #region Fakes
        private IQueryable<Adopter> FakeAdopters()
        {
            Shelter shelter1 = new Shelter() { Id = 1, ShelterName = "Seattle Animal Shelter", City = "Seattle", Address = "2061 15Th Ave" };
            Shelter shelter2 = new Shelter() { Id = 2, ShelterName = "Motley Zoo Animal Rescue", City = "Woodinville", Address = "13132 NE 177th PI" };
            Shelter shelter3 = new Shelter() { Id = 3, ShelterName = "Homward Pet Adoption Center", City = "Redmond", Address = "16725 Cleveland St" };
            Shelter shelter4 = new Shelter() { Id = 4, ShelterName = "South Pacific County Humane Society", City = "Long Beach", Address = "98631 2nd St NE" };

            Adopter adopter1 = new Adopter() { Id = 1, Name = "Sioned Wilkins", City = "Hobbs", Address = "1393 Reel Avenue", HasKid = true };
            Adopter adopter2 = new Adopter() { Id = 2, Name = "Clive Owens", City = "Portage", Address = " 3113 Blane Street", HasKid = false };
            Adopter adopter3 = new Adopter() { Id = 3, Name = "Keanu Reeves", City = "Baltimore", Address = "4998 Calvin Street", HasKid = true };
            Adopter adopter4 = new Adopter() { Id = 4, Name = "Anna Petersen", City = "San Jose", Address = "681 Ford Street", HasKid = true };
            Adopter adopter5 = new Adopter() { Id = 5, Name = "Austen Fry", City = "Fort Washington", Address = "1640 Spring Avenue", HasKid = false };

            Animal animal1 = new Animal() { Id = 1, Name = "Rock", Gender = "Male", Specie = "Dog", Bodysize = "small", Age = 1, AdopterId = adopter1.Id, ShelterId = shelter2.Id };
            Animal animal2 = new Animal() { Id = 2, Name = "Chevy", Gender = "Male", Specie = "Cat", Bodysize = "small", Age = 3, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal3 = new Animal() { Id = 3, Name = "Sponge", Gender = "Female", Specie = "Dog", Bodysize = "Medium", Age = 5, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal4 = new Animal() { Id = 4, Name = "Darth", Gender = "Male", Specie = "Birb", Bodysize = "Small", Age = 1, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
            Animal animal5 = new Animal() { Id = 5, Name = "Dunkin", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 9, AdopterId = adopter4.Id, ShelterId = shelter1.Id };
            Animal animal6 = new Animal() { Id = 6, Name = "Glory", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 2, AdopterId = adopter1.Id, ShelterId = shelter2.Id };
            Animal animal7 = new Animal() { Id = 7, Name = "Buttercup", Gender = "Female", Specie = "Catto", Bodysize = "smol", Age = 2, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
            Animal animal8 = new Animal() { Id = 8, Name = "Cream", Gender = "Female", Specie = "Cat", Bodysize = "Medium", Age = 8, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal9 = new Animal() { Id = 9, Name = "Pistachio", Gender = "Male", Specie = "Cat", Bodysize = "Medium", Age = 11, AdopterId = adopter5.Id, ShelterId = shelter4.Id };
            Animal animal10 = new Animal() { Id = 10, Name = "Courage", Gender = "Male", Specie = "Dog", Bodysize = "Large", Age = 12, AdopterId = adopter5.Id, ShelterId = shelter3.Id };

            List<Adopter> adopters = new List<Adopter>();

            adopters.Add(adopter1);
            adopters.Add(adopter2);
            adopters.Add(adopter3);
            adopters.Add(adopter4);
            adopters.Add(adopter5);

            return adopters.AsQueryable();
        }

        private IQueryable<Animal> FakeAnimals()
        {
            Shelter shelter1 = new Shelter() { Id = 1, ShelterName = "Seattle Animal Shelter", City = "Seattle", Address = "2061 15Th Ave" };
            Shelter shelter2 = new Shelter() { Id = 2, ShelterName = "Motley Zoo Animal Rescue", City = "Woodinville", Address = "13132 NE 177th PI" };
            Shelter shelter3 = new Shelter() { Id = 3, ShelterName = "Homward Pet Adoption Center", City = "Redmond", Address = "16725 Cleveland St" };
            Shelter shelter4 = new Shelter() { Id = 4, ShelterName = "South Pacific County Humane Society", City = "Long Beach", Address = "98631 2nd St NE" };

            Adopter adopter1 = new Adopter() { Id = 1, Name = "Sioned Wilkins", City = "Hobbs", Address = "1393 Reel Avenue", HasKid = true };
            Adopter adopter2 = new Adopter() { Id = 2, Name = "Clive Owens", City = "Portage", Address = " 3113 Blane Street", HasKid = false };
            Adopter adopter3 = new Adopter() { Id = 3, Name = "Keanu Reeves", City = "Baltimore", Address = "4998 Calvin Street", HasKid = true };
            Adopter adopter4 = new Adopter() { Id = 4, Name = "Anna Petersen", City = "San Jose", Address = "681 Ford Street", HasKid = true };
            Adopter adopter5 = new Adopter() { Id = 5, Name = "Austen Fry", City = "Fort Washington", Address = "1640 Spring Avenue", HasKid = false };

            Animal animal1 = new Animal() { Id = 1, Name = "Rock", Gender = "Male", Specie = "Dog", Bodysize = "small", Age = 1, AdopterId = adopter1.Id, ShelterId = shelter2.Id };
            Animal animal2 = new Animal() { Id = 2, Name = "Chevy", Gender = "Male", Specie = "Cat", Bodysize = "small", Age = 3, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal3 = new Animal() { Id = 3, Name = "Sponge", Gender = "Female", Specie = "Dog", Bodysize = "Medium", Age = 5, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal4 = new Animal() { Id = 4, Name = "Darth", Gender = "Male", Specie = "Birb", Bodysize = "Small", Age = 1, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
            Animal animal5 = new Animal() { Id = 5, Name = "Dunkin", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 9, AdopterId = adopter4.Id, ShelterId = shelter1.Id };
            Animal animal6 = new Animal() { Id = 6, Name = "Glory", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 2, AdopterId = adopter1.Id, ShelterId = shelter2.Id };
            Animal animal7 = new Animal() { Id = 7, Name = "Buttercup", Gender = "Female", Specie = "Catto", Bodysize = "smol", Age = 2, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
            Animal animal8 = new Animal() { Id = 8, Name = "Cream", Gender = "Female", Specie = "Cat", Bodysize = "Medium", Age = 8, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal9 = new Animal() { Id = 9, Name = "Pistachio", Gender = "Male", Specie = "Cat", Bodysize = "Medium", Age = 11, AdopterId = adopter5.Id, ShelterId = shelter4.Id };
            Animal animal10 = new Animal() { Id = 10, Name = "Courage", Gender = "Male", Specie = "Dog", Bodysize = "Large", Age = 12, AdopterId = adopter5.Id, ShelterId = shelter3.Id };

            List<Animal> animals = new List<Animal>();

            animals.Add(animal1);
            animals.Add(animal2);
            animals.Add(animal3);
            animals.Add(animal4);
            animals.Add(animal5);
            animals.Add(animal6);
            animals.Add(animal7);
            animals.Add(animal8);
            animals.Add(animal9);
            animals.Add(animal10);

            return animals.AsQueryable();

        }

        private IQueryable<Shelter> FakeShelters()
        {
            Shelter shelter1 = new Shelter() { Id = 1, ShelterName = "Seattle Animal Shelter", City = "Seattle", Address = "2061 15Th Ave" };
            Shelter shelter2 = new Shelter() { Id = 2, ShelterName = "Motley Zoo Animal Rescue", City = "Woodinville", Address = "13132 NE 177th PI" };
            Shelter shelter3 = new Shelter() { Id = 3, ShelterName = "Homward Pet Adoption Center", City = "Redmond", Address = "16725 Cleveland St" };
            Shelter shelter4 = new Shelter() { Id = 4, ShelterName = "South Pacific County Humane Society", City = "Long Beach", Address = "98631 2nd St NE" };

            Adopter adopter1 = new Adopter() { Id = 1, Name = "Sioned Wilkins", City = "Hobbs", Address = "1393 Reel Avenue", HasKid = true };
            Adopter adopter2 = new Adopter() { Id = 2, Name = "Clive Owens", City = "Portage", Address = " 3113 Blane Street", HasKid = false };
            Adopter adopter3 = new Adopter() { Id = 3, Name = "Keanu Reeves", City = "Baltimore", Address = "4998 Calvin Street", HasKid = true };
            Adopter adopter4 = new Adopter() { Id = 4, Name = "Anna Petersen", City = "San Jose", Address = "681 Ford Street", HasKid = true };
            Adopter adopter5 = new Adopter() { Id = 5, Name = "Austen Fry", City = "Fort Washington", Address = "1640 Spring Avenue", HasKid = false };

            Animal animal1 = new Animal() { Id = 1, Name = "Rock", Gender = "Male", Specie = "Dog", Bodysize = "small", Age = 1, AdopterId = adopter1.Id, ShelterId = shelter2.Id };
            Animal animal2 = new Animal() { Id = 2, Name = "Chevy", Gender = "Male", Specie = "Cat", Bodysize = "small", Age = 3, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal3 = new Animal() { Id = 3, Name = "Sponge", Gender = "Female", Specie = "Dog", Bodysize = "Medium", Age = 5, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal4 = new Animal() { Id = 4, Name = "Darth", Gender = "Male", Specie = "Birb", Bodysize = "Small", Age = 1, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
            Animal animal5 = new Animal() { Id = 5, Name = "Dunkin", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 9, AdopterId = adopter4.Id, ShelterId = shelter1.Id };
            Animal animal6 = new Animal() { Id = 6, Name = "Glory", Gender = "Female", Specie = "Dog", Bodysize = "Large", Age = 2, AdopterId = adopter1.Id, ShelterId = shelter2.Id };
            Animal animal7 = new Animal() { Id = 7, Name = "Buttercup", Gender = "Female", Specie = "Catto", Bodysize = "smol", Age = 2, AdopterId = adopter3.Id, ShelterId = shelter4.Id };
            Animal animal8 = new Animal() { Id = 8, Name = "Cream", Gender = "Female", Specie = "Cat", Bodysize = "Medium", Age = 8, AdopterId = adopter2.Id, ShelterId = shelter1.Id };
            Animal animal9 = new Animal() { Id = 9, Name = "Pistachio", Gender = "Male", Specie = "Cat", Bodysize = "Medium", Age = 11, AdopterId = adopter5.Id, ShelterId = shelter4.Id };
            Animal animal10 = new Animal() { Id = 10, Name = "Courage", Gender = "Male", Specie = "Dog", Bodysize = "Large", Age = 12, AdopterId = adopter5.Id, ShelterId = shelter3.Id };

            List<Shelter> shelters = new List<Shelter>();

            shelters.Add(shelter1);
            shelters.Add(shelter2);
            shelters.Add(shelter3);
            shelters.Add(shelter4);

            return shelters.AsQueryable();

        }
        #endregion

        [Test]
        public void animalFromShelters()
        {
            var sheltertest1 = shelterLogic.animalFromShelters();
            var capacity = sheltertest1.Where(x => x.Counter >= 3);

            Assert.True(capacity.First().Counter.Equals(4) && capacity.First().Id.Equals(1) && capacity.First().Name.Contains("Seattle"));
        }

        [Test]
        public void DogShelters()
        {
            var sheltertest2 = shelterLogic.DogShelters();
            var sheltersname = sheltertest2.Where(x => x.Name == "Motley Zoo Animal Rescue");
            var dog = sheltertest2.Where(x => x.AnimalName == "Sponge");

            Assert.True(sheltersname.First().Name.Equals("Motley Zoo Animal Rescue") && dog.First().AnimalName.Equals("Sponge"));



        }

        [Test]
        public void animalFromAdopter()
        {
            var adoptertest1 = adopterLogic.animalFromAdopter();
            var adoptername = adoptertest1.Where(x => x.Name == "Sioned Wilkins");
            var numberofpets = adoptertest1.Where(x => x.Counter >= 1);

            Assert.True(adoptertest1.First().Name.Contains("Sioned") && numberofpets.First().Counter.Equals(2));

        }

        [Test]
        public void adoptersTherePetsWithNames()
        {
            var adoptertest2 = adopterLogic.adoptersTherePetsWithNames();
            var petname = adoptertest2.Where(x => x.AnimalName == "Buttercup");

            Assert.True(petname.First().AnimalName.Equals("Buttercup") && petname.First().Id.Equals(7) && petname.First().Name.Equals("Keanu Reeves"));

        }

        [Test]
        public void adopterInfos()
        {
            var adoptertest3 = adopterLogic.adopterInfos();
            var adopterinfo = adoptertest3.Where(x => x.AnimalBodysize == "Large");

            Assert.True(adopterinfo.First().AnimalAge.Equals(9) && adopterinfo.First().AnimalName.Equals("Dunkin") && adopterinfo.First().AnimalBodysize.Equals("Large"));
        }

        #endregion
    }
}
