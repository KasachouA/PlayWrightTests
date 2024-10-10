using Microsoft.Playwright;
using Microsoft.Playwright.TestAdapter;

namespace CoreTestProject.PlaywrightInitialization
{
    public static class Configuration
    {
        public static BrowserTypeLaunchOptions GetBrowserLaunchOptions() => PlaywrightSettingsProvider.LaunchOptions;

        public static string GetBrowserType() => PlaywrightSettingsProvider.BrowserName;

        public static BrowserNewContextOptions GetBrowserNewContextOptions() => new BrowserNewContextOptions();
    }
}
