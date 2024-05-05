using NUnit.Framework.Interfaces;
using RestSharp;
using System.Net;
using TestProject.Models;
using TestProject.Utils;


namespace TestProject.Tests.API
{
    public class Tests
    {
        public void Setup(string petId, string petName, string petStatus)
        {
            PetStoreApiUtils.PostPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue(petId),
                    ConfigReader.GetTestDataValue(petName),
                    ConfigReader.GetTestDataValue(petStatus)));
        }

        [Test]
        public void PetTest()
        {
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("petId")).Name,
                Is.EqualTo(ConfigReader.GetTestDataValue("petName")), "Pet name is not as expected");

            RestResponse updateResponse = PetStoreApiUtils.PutPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("petId"),
                    ConfigReader.GetTestDataValue("newPetName"),
                    ConfigReader.GetTestDataValue("petStatus")));

            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Pet update request was not successful");
                Assert.That(PetStoreApiUtils.GetPetById(
                    ConfigReader.GetNumericalTestDataValue("petId")).Name,
                    Is.EqualTo(ConfigReader.GetTestDataValue("newPetName")),
                    "Updated pet name is not as expected");
            }
           );
        }

        [TearDown]
        public void TearDown()
        {
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
        }
    }
}