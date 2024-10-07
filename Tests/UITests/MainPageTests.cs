using Allure.NUnit.Attributes;
using CoreTestProject.Pages;
using Tests.TestFixtures;

namespace Tests.UITests
{
    [TestFixture]
    [AllureSuite("Main page")]
    public class MainPageTests : BaseTest
    {
        private LearnAndPracticeAutomationPage _learnAndPracticeAutomationPage;

        [Test]
        [AllureSubSuite("Main layout")]
        public async Task MainPageTitleVerification()
        {
            _learnAndPracticeAutomationPage = new LearnAndPracticeAutomationPage(Page);

            await Expect(_learnAndPracticeAutomationPage.PageNameText).ToHaveTextAsync("Wecome to your software automation practice website!");
        }
    }
}
