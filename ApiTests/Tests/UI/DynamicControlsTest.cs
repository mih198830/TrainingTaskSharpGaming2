using ApiTests.Tests.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        readonly IWebDriver driver = Browser.GetDriver();
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By disableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Disable"));
        private static readonly By inputField = By.XPath(string.Format(XpathPatterns.typeText));
        readonly MainPage mainPage = new MainPage();
        private static readonly string randomValue = Guid.NewGuid().ToString();


        [Test]
        public void DynamicControlsTest()
        {
            mainPage.ClickOnDynamicControl();
            Thread.Sleep(10000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementToBeClickable(enableBtn));
            Browser.GetDriver().FindElement(enableBtn).Click();
            //assert input is enabled
            wait.Until(ExpectedConditions.ElementIsVisible(disableBtn));
            //input randomly generated text
            Browser.GetDriver().FindElement(inputField).SendKeys(randomValue);
            Thread.Sleep(10000);
            //assert input text



        }
    }
    
}
