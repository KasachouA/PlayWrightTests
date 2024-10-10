using Allure.Net.Commons;
using Allure.NUnit;
using CoreTestProject.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Interfaces;

namespace Tests.TestFixtures
{
    [Parallelizable(ParallelScope.Self)]
    [AllureNUnit]
    public class BaseTest : PageTest
    {
        protected TestContext TestContext => TestContext.CurrentContext;

        [SetUp]
        public async Task SetUp()
        {
            await new MainPage(Page).NavigateToAsync(TestContext.Parameters["TestAppUrl"]);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshotPath = $"{TestContext.Test.MethodName}_{DateTime.Now:yyyyMMdd_HHmmss}_failed.png";
                await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = screenshotPath,
                    FullPage = true 
                });

                AllureApi.AddAttachment(screenshotPath, "Failed test");
            }
        }
    }
}
