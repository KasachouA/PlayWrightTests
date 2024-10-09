using CoreTestProject.StaticData;
using Microsoft.Playwright;

namespace CoreTestProject.Pages
{
    public class MainPage : BasePage
    {
        private ILocator PageNameText => Page.GetByRole(AriaRole.Heading);
        private ILocator Button(MainPageButton button) => Page.Locator($"//a[text() = '{button.Name}']");

        public MainPage(IPage page) : base(page)
        {
        }

        public async Task ClickButton(MainPageButton button) => await Button(button).ClickAsync();

        public async Task<bool> IsButtonVisible(MainPageButton button) => await Button(button).IsVisibleAsync();

        public async Task<string> GetPageName() => (await PageNameText.TextContentAsync()).Trim();

    }
}
