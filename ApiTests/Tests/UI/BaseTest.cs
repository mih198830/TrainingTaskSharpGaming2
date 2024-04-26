using OpenQA.Selenium.Support.UI;
using TestProject.Utils;

namespace ApiTests.Tests.UI
{
    public class BaseTest
    {
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";

        [SetUp]
        public void Setup()
        {
            try
            {
                Browser.GetDriver().Navigate().GoToUrl(ConfigReader.GetConfigValue("webUIUrl"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered during page navigation: " + e.Message);
            }
        }

        [TearDown]
        public void TearDown() => Browser.GetDriver().Quit();
    }
}