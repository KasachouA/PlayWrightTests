using Microsoft.Playwright;

namespace CoreTestProject.Pages
{
    public class BasePage
    {
        protected IPage Page { get; init; }

        public BasePage(IPage page) => Page = page;

        public async Task NavigateToAsync(string url) => await Page.GotoAsync(url);

        public async Task<string> GetTitleAsync() => await Page.TitleAsync();
    }
}
