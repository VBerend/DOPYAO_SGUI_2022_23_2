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
        public void TestCreateAdopter()
        {
            Mock<IAdopterRepository> mockedAdopterRepo = new Mock<IAdopterRepository>(MockBehavior.Loose);
            Mock<IAnimalRepository> mockedAnimalRepo = new Mock<IAnimalRepository>(MockBehavior.Loose);
            AdopterLogic adopterLogic = new AdopterLogic(mockedAdopterRepo.Object, mockedAnimalRepo.Object);
            mockedAdopterRepo.Setup(repo => repo.Insert(It.IsAny<Adopter>()));
            adopterLogic.InsertNewAdopter("Teszt Elek", "Csudapest", "Main street 42.", false);
            mockedAdopterRepo.Verify(repo => repo.Insert(It.IsAny<Adopter>()), Times.Once);
        }



    }
}
