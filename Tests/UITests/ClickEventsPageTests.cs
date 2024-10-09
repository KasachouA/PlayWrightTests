using Allure.NUnit.Attributes;
using CoreTestProject.Pages;
using CoreTestProject.StaticData;
using CoreTestProject.Utils;
using Tests.TestFixtures;

namespace Tests.UITests
{
    [AllureSuite("Click Events Page")]
    public class ClickEventsPageTests : BaseTest
    {
        private ClickEventsPage _clickEventsPage;
        private MainPage _learnAndPracticeAutomationPage;

        [SetUp]
        public void TestSetup()
        {
            _learnAndPracticeAutomationPage = new MainPage(Page);
            _clickEventsPage = new ClickEventsPage(Page);
        }

        [Test]
        [AllureOwner("Andrei Kasachou")]
        [AllureSubSuite("Main layout")]
        public async Task VerifyResponsesForButtonsClick()
        {
            await _learnAndPracticeAutomationPage.ClickButton(MainPageButton.ClickEvents);
            var animalSound = _clickEventsPage.GetResponseText();

            Assert.That(await animalSound, Is.Empty);

            foreach (var button in StringConstantUtil.GetAllConstants<Animal>()) 
            {
                await _clickEventsPage.ClickAnimalButton(button);
                Assert.That(await animalSound, Is.EqualTo(button.Sound));
            }
        }
    }
}
