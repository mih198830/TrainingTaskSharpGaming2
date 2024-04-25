using ApiTests.Tests.UI;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests
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
            dynamicControlsPage.EnterTextInInputField(RandomUtils.GetRandomValue());
            Assert.That(RandomUtils.GetRandomValue(), Is.EqualTo(dynamicControlsPage.GetAttributeOfInputField()), 
                $"Printed text '{dynamicControlsPage.GetAttributeOfInputField()}' is not" +
                $" what was inputted '{RandomUtils.GetRandomValue()}'");
        }
    }
}
