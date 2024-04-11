using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;


namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
        readonly MainPage mainPage = new MainPage();
        readonly FramesPage framesPage = new FramesPage();
        readonly IframePage iframePage = new IframePage();

        [Test]
        public void IFrameTest()
        {
            mainPage.ClickOnFramesButton();
            framesPage.ClickOnIframeButton();
            //input text to the textfield
            iframePage.SwitchToIframe();
            iframePage.ClickOnEditButtonInIframe();
            iframePage.SendRandomTextToTextField();
            Assert.That(iframePage.GetPrintedTextBeforeClear, $"Printed Text '{iframePage.GetInitText()}{iframePage.GetRandomValue()}' is not displayed");
            iframePage.SwitchFromIframe();
            iframePage.ClickOnEditButtonInIframe();
            iframePage.ClickOnUndoButton();
            iframePage.SwitchToIframe();
            //assert input text
            Assert.That(iframePage.GetPrintedTextAfterClearTextField(), Is.EqualTo(iframePage.GetInitText()), $"Printed text is not initial value'{iframePage.GetInitText()}'");
        }
    }
}
