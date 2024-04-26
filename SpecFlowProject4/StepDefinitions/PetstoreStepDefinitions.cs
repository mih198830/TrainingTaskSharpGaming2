using NUnit.Framework;
using RestSharp;
using System.Net;
using TestProject.Models;
using TestProject.Tests.API;
using TestProject.Utils;


namespace SpecFlowProject4.StepDefinitions
{
    [Binding]
    public sealed class PetstoreStepDefinitions
    {
        readonly Tests tests = new Tests();
        private readonly ScenarioContext scenarioContext;
        public PetstoreStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"A pet was created using get request")]
        public void GivenAPetWasCreatedUsingGetRequest() => tests.Setup();

        [When(@"I Get a pet by ID from precondition")]
        public void WhenIGetAPetByIDFromPrecondition()
        {
            var petId = ConfigReader.GetNumericalTestDataValue("petId");
            var pet = PetStoreApiUtils.GetPetById(petId);
            scenarioContext["pet"] = pet;

        }

        [Then(@"Pet is added with the specified name")]
        public void ThenPetIsAddedWithTheSpecifiedName()
        {
            var expectedPetName = ConfigReader.GetTestDataValue("petName");
            var pet = (Pet)scenarioContext["pet"];
            Assert.That(pet.Name, Is.EqualTo(expectedPetName), "Pet name is not as expected");
        }

        [When(@"I Update a pet from previous step and change the name to a new one")]
        public void WhenIUpdateAPetFromPreviousStepAndChangeTheNameToANewOne()
        {
            RestResponse updateResponse = PetStoreApiUtils.PutPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("petId"),
                    ConfigReader.GetTestDataValue("newPetName"),
                    ConfigReader.GetTestDataValue("petStatus")));
            scenarioContext["updatedResponse"] = updateResponse;
        }

        [Then(@"Request was successful & the name is updated")]
        public void ThenRequestWasSuccessfulTheNameIsUpdated()
        {
            var pet = (Pet)scenarioContext["pet"];
            var updatedPetName = ConfigReader.GetTestDataValue("newPetName");
            var updateResponse = (RestResponse)scenarioContext["updateResponse"];
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Pet update request was not successful");
                Assert.That(pet.Name,
                    Is.EqualTo(updatedPetName),
                    "Updated pet name is not as expected");
            });
        }


    }
}
