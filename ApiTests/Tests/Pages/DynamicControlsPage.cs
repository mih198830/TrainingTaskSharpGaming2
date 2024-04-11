﻿using ApiTests.Tests.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class DynamicControlsPage : BaseTest
    {
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By disableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Disable"));
        readonly WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(100));

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

        public bool CheckIfButtonIsEnabled()
        {
            _ = Browser.GetDriver().FindElement(disableBtn).Enabled;
            return true;
        }
    }
}
