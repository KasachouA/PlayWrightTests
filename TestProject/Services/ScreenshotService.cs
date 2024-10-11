using Allure.Net.Commons;
using CoreTestProject.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace CoreTestProject.Services
{
    public class ScreenshotService
    {
        public async Task<string> TakeScreenshotIfTestFailed(IPage page, bool addToAllure = true)
        {
            var testContext = TestContext.CurrentContext;

            if (testContext.IsTestFailed())
            {
                var screenshotPath = GetScreenshotPath($"{testContext.Test.MethodName}_{DateTime.Now:yyyyMMdd_HHmmss}_failed");
                
                await page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = screenshotPath,
                    FullPage = true
                });

                if (addToAllure)
                {
                    AddScreenshotToAllureReport(screenshotPath);
                }

                return screenshotPath;
            }

            return null;
        }
        
        public void AddScreenshotToAllureReport(string screenshotPath, string screenshotName = null) =>
            AllureApi.AddAttachment(screenshotPath, 
                screenshotName ?? Path.GetFileNameWithoutExtension(screenshotPath));
        
        public string GetScreenshotPath(string fileNameWithoutExtension) => 
            Path.Combine(Configuration.ScreenshotsFolder, $"{fileNameWithoutExtension}.png");
    }
}
