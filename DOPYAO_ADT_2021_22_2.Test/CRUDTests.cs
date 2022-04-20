using DOPYAO_ADT_2021_22_2.Logic;
using DOPYAO_ADT_2021_22_2.Models;
using DOPYAO_ADT_2021_22_2.Repository;
using Moq;
using NUnit.Framework;
using System;

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

        #endregion
    }
}
