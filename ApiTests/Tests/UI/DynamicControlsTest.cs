using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        MainPage mainPage = new MainPage();
        WebDriver driver = Browser.GetDriver();


        [Test]
        public void DynamicControlsTest()
        {
            mainPage.ClickOnDynamicControl();
            Browser.GetDriver().FindElement(enableBtn).Click();
            //WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(maxWait));
            //IWebElement inputElement = wait.Until(ExpectedConditions.ElementToBeClickable(inputLocator));
            //assert input is enabled
            //assert input is disabled



            //input randomly generated text
            //assert input text
        }
    }
    
}
