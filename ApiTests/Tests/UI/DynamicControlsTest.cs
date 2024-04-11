using ApiTests.Tests.UI;
using TestProject.Tests.Pages;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        readonly MainPage mainPage = new MainPage();
        readonly DynamicControlsPage dynamicControlsPage = new DynamicControlsPage();

        [Test]
        public void DynamicControlsTest()
        {
            mainPage.ClickOnDynamicControl();
            dynamicControlsPage.ClickOnEnableBtn();
            dynamicControlsPage.WaitForDisableBtn();
            Assert.That(dynamicControlsPage.CheckIfButtonIsEnabled, Is.True);
            mainPage.EnterTextInInputField(GetRandomValue());
            Assert.That(GetRandomValue(), Is.EqualTo(mainPage.GetAttributeOfInputField()), $"Printed text '{mainPage.GetAttributeOfInputField()}' is not" +
                $" what was inputted '{GetRandomValue()}'");
        }
    }
}
