using Allure.Net.Commons;
using Allure.NUnit;
using CoreTestProject.Pages;
using CoreTestProject.PlaywrightInitialization;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;

namespace Tests.TestFixtures
{
    [Parallelizable(ParallelScope.All)]
    [AllureNUnit]
    public class BaseTest
    {
        protected IPage Page;

        [SetUp]
        public async Task SetUp()
        {
            Page = await PlaywrightPageFactory.CreatePageAsync();

            await new MainPage(Page).NavigateToAsync("https://practice-automation.com/");
        }

        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshotPath = $"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now:yyyyMMdd_HHmmss}_failed.png";
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
