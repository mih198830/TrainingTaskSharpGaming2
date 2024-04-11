using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class MainPage
    {
        private static readonly By inputField = By.XPath(string.Format(XpathPatterns.typeText));
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.preciseTextXpath, 
            "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By disableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Disable"));
        private static readonly By framesBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Frames"));
        WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(100));
        

        public void ClickOnDynamicControl()
        {
            Browser.GetDriver().FindElement(dynamicControl).Click();
        }

        public void ClickOnEnableBtn()
        {
            Browser.GetDriver().FindElement(enableBtn).Click();
        }

        public void WaitForEnableBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(enableBtn));
        }

        public void WaitForDisableBtn()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(disableBtn));
        }

        public void EnterTextInInputField(string randomValue)
        {
            Browser.GetDriver().FindElement(inputField).SendKeys(randomValue);
        }

        public string GetAttributeOfInputField()
        {
            return Browser.GetDriver().FindElement(inputField).GetAttribute("value");
        }

        public void ClickOnFramesButton()
        {
            Browser.GetDriver().FindElement(framesBtn).Click();
        }

        public bool CheckIfButtonIsEnabled()
        {
            _ = Browser.GetDriver().FindElement(disableBtn).Enabled;
            return true;
        }
    }
}
