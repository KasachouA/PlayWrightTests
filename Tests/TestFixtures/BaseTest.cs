using Allure.NUnit;
using CoreTestProject;
using CoreTestProject.Pages;
using CoreTestProject.Services;
using Microsoft.Playwright.NUnit;

namespace Tests.TestFixtures
{
    [Parallelizable(ParallelScope.Self)]
    [AllureNUnit]
    public class BaseTest : PageTest
    {
        private PageFactory _pageFactory;

        public T GetPage<T>() where T : BasePage
        {
            return _pageFactory.CreatePage<T>();
        }

        [SetUp]
        public async Task SetUp()
        {
            _pageFactory = new PageFactory(Page);
            await new MainPage(Page).NavigateToAsync(Configuration.TestAppUrl);
        }

        [TearDown]
        public async Task TearDown()
        {
            await new ScreenshotService().TakeScreenshotIfTestFailed(Page);
        }
    }
}
