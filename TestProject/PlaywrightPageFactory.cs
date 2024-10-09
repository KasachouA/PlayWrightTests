using Microsoft.Playwright;

namespace CoreTestProject
{
    public static class PlaywrightPageFactory
    {
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        private static readonly object _lock = new object();

        private static IBrowser GetBrowserAsync(string browserType = "chromium", bool headless = true)
        {
            if (_browser == null)
            {
                lock (_lock)
                {
                    if (_browser == null)
                    {
                        _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();

                        _browser = browserType.ToLower() switch
                        {
                            "firefox" => _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless }).GetAwaiter().GetResult(),
                            "webkit" => _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless }).GetAwaiter().GetResult(),
                            _ => _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless }).GetAwaiter().GetResult(),
                        };
                    }
                }
            }

            return _browser;
        }

        public static async Task<IPage> CreatePageAsync(string browserType = "firefox", bool headless = false)
        {
            var browser = GetBrowserAsync(browserType, headless);
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            return page;
        }

        public static void CloseBrowserAsync()
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