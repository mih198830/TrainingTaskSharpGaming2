using ApiTests.Tests.UI;

namespace SpecFlowProject4.StepDefinitions
{
    [Binding]
    internal class IframeStepDefinitions : SetUp
    {
        BaseTest baseTest = new BaseTest();
        public IframeStepDefinitions(ScenarioContext _scenarioContext) : base(_scenarioContext)
        {
        }

        [When(@"I Click '(.*)' link on the page")]
        [Given(@"I Click '(.*)' link on the page")]
        public void WhenIClickLinkOnTheMainPage(string elementName)
        {
            baseTest.ClickOnElement(elementName);
        }


    }
}
