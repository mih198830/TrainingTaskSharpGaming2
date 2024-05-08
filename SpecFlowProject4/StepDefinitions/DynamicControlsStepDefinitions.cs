﻿using ApiTests.Tests.UI;
using TestProject.Tests.Pages;
using TestProject.Utils;
using NUnit.Framework;
using SpecFlowProject4.StepDefinitions;

namespace DynamicControlsStepDefinitions
{
    [Binding]
    internal class DynamicControlsStepDefinitions : SetUp
    {
        public DynamicControlsStepDefinitions(ScenarioContext _scenarioContext) : base(_scenarioContext)
        {
        }
        readonly DynamicControlsPage dynamicControlsPage = new ();
        readonly BaseTest baseTest = new ();

        [Given(@"I Click '([^']*)' button")]
        public void GivenIClickButton(string Enable)
        {
            baseTest.ClickOnElement(Enable);
            dynamicControlsPage.WaitForDisableBtn();
        }


        [Then(@"Enable/disable input is enabled")]
        public void ThenEnableDisableInputIsEnabled()
        {
            Assert.That(dynamicControlsPage.CheckIfButtonIsEnabled, Is.True);
        }

        [When(@"I Send random text to Enable/disable input")]
        public void WhenISendRandomTextToEnableDisableInput()
        {
            dynamicControlsPage.EnterTextInInputField(RandomUtils.GetRandomValue());
        }

        [Then(@"Random text is displayed")]
        public void ThenRandomTextIsDisplayed()
        {
            Assert.That(RandomUtils.GetRandomValue(), Is.EqualTo(dynamicControlsPage.GetAttributeOfInputField()),
                $"Printed text '{dynamicControlsPage.GetAttributeOfInputField()}' is not" +
                $" what was inputted '{RandomUtils.GetRandomValue()}'");
        }
    }
}
