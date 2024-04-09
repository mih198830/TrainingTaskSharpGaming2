using ApiTests.Tests.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        readonly MainPage mainPage = new MainPage();
        
        private static readonly string randomValue = Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {
            mainPage.ClickOnDynamicControl();
            mainPage.ClickOnEnableBtn();
            mainPage.WaitForDisableBtn();
            //assert input is enabled
            Assert.That(mainPage.CheckIfButtonIsEnabled, Is.True);
            //input randomly generated text
            mainPage.EnterTextInInputField(randomValue);
            string printedText = mainPage.GetAttributeOfInputField();
            //assert input text
            Assert.That(randomValue, Is.EqualTo(printedText), $"Printed text '{printedText}' is not" +
                $" what was inputted '{randomValue}'");
        }
    }
}
