using Allure.NUnit.Attributes;
using CoreTestProject.Pages;
using CoreTestProject.StaticData;
using Tests.TestFixtures;

namespace Tests.UITests
{
    [TestFixture]
    [AllureSuite("Main page")]
    public class MainPageTests : BaseTest
    {
        private MainPage _mainPage;

        [SetUp]
        public void TestSetup()
        {
            _mainPage = GetPage<MainPage>();
        }

        [Test]
        [AllureOwner("Andrei Kasachou")]
        [AllureSubSuite("Main layout")]
        public async Task VerifyMainPageTitle()
        {
            Assert.That(await _mainPage.GetPageName(), Is.EqualTo("Welcome to your software automation practice website!"));
        }

        [Test]
        [AllureOwner("Andrei Kasachou")]
        [AllureSubSuite("Main layout")]
        public async Task VerifyAllButtonsPresenceOnMainPage()
        {
            Assert.That(await _mainPage.GetButtonNamesOnPage(), Is.EquivalentTo(MainPageButton.GetNamesList()));
        }
    }
}
