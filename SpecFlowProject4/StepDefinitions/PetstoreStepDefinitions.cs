namespace SpecFlowProject4.StepDefinitions
{
    [Binding]
    public sealed class PetstoreStepDefinitions
    {
        [Given(@"A pet was created using get request")]
        public void GivenAPetWasCreatedUsingGetRequest()
        {
            throw new PendingStepException();
        }

        [When(@"I Get a pet by ID from precondition\)")]
        public void WhenIGetAPetByIDFromPrecondition()
        {
            ConfigReader.GetTestDataValue("initText");
            ConfigReader.
            int petId = ConfigReader.GetNumericalTestDataValue("petId");
        }

    }
}
