﻿using ApiTests.Tests.UI;
using TestProject.Tests.Pages;
using TestProject.Utils;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace DynamicControlsStepDefinitions
{
    [Binding]
    public class DynamicControlsStepDefinitions : BaseTest
    {
        readonly MainPage mainPage = new MainPage();
        readonly DynamicControlsPage dynamicControlsPage = new DynamicControlsPage();

        [Given(@"I Click link on the Main page")]
        public void GivenIClickLinkOnTheMainPage()
        {
            mainPage.ClickOnDynamicControl();
        }

        [When(@"I Click '([^']*)' button")]
        public void WhenIClickButton(string enable)
        {
            dynamicControlsPage.ClickOnEnableBtn();
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

