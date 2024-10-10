using Microsoft.Playwright;

namespace CoreTestProject.PlaywrightInitialization
{
    public static class PlaywrightPageFactory
    {
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        private static readonly object _lock = new object();

        private static IBrowser GetBrowser()
        {
            if (_browser == null)
            {
                lock (_lock)
                {
                    if (_browser == null)
                    {
                        _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
                        _browser = _playwright[Configuration.GetBrowserType()].LaunchAsync(Configuration.GetBrowserLaunchOptions()).GetAwaiter().GetResult();
                    }
                }
            }

            return _browser;
        }

        public static async Task<IPage> CreatePageAsync()
        {
            var browser = GetBrowser();
            var context = await browser.NewContextAsync(Configuration.GetBrowserNewContextOptions());
            var page = await context.NewPageAsync();
            return page;
        }

        public static void CloseBrowser()
        {
            if (_browser != null)
            {
                lock (_lock)
                {
                    if (_browser != null)
                    {
                        _browser.CloseAsync().GetAwaiter().GetResult();
                        _browser = null;

                        _playwright.Dispose();
                        _playwright = null;
                    }
                }
            }
        }
    }
}