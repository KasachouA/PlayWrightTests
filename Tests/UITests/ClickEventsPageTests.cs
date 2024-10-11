using Allure.NUnit.Attributes;
using CoreTestProject.Pages;
using CoreTestProject.StaticData;
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
            _learnAndPracticeAutomationPage = GetPage<MainPage>();
            _clickEventsPage = GetPage<ClickEventsPage>();
        }

        [Test]
        [AllureOwner("Andrei Kasachou")]
        [AllureSubSuite("Main layout")]
        public async Task VerifyResponsesForButtonsClick()
        {
            await _learnAndPracticeAutomationPage.ClickButton(MainPageButton.ClickEvents);

            await Assert.MultipleAsync(async () =>
            {
                await _clickEventsPage.ClickAnimalButton(Animal.Cow);
                Assert.That(await _clickEventsPage.GetResponseText(), Is.EqualTo(Animal.Cow.Sound));

                await _clickEventsPage.ClickAnimalButton(Animal.Cat);
                Assert.That(await _clickEventsPage.GetResponseText(), Is.EqualTo(Animal.Cat.Sound));

                await _clickEventsPage.ClickAnimalButton(Animal.Dog);
                Assert.That(await _clickEventsPage.GetResponseText(), Is.EqualTo(Animal.Dog.Sound));

                await _clickEventsPage.ClickAnimalButton(Animal.Pig);
                Assert.That(await _clickEventsPage.GetResponseText(), Is.EqualTo(Animal.Pig.Sound));
            });
        }
    }
}
