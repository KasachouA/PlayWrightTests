using CoreTestProject.StaticData;
using Microsoft.Playwright;

namespace CoreTestProject.Pages
{
    public class MainPage : BasePage
    {
        private ILocator PageNameText => Page.GetByRole(AriaRole.Heading);
        private ILocator ButtonLocator => Page.Locator("div.wp-block-button");

        public MainPage(IPage page) : base(page)
        {
        }

        public async Task ClickButton(MainPageButton button) => await ButtonLocator.GetByText(button.Name).ClickAsync();

        public async Task<bool> IsButtonVisible(MainPageButton button) => await ButtonLocator.GetByText(button.Name).IsVisibleAsync();

        public async Task<string> GetPageName() => (await PageNameText.TextContentAsync())?.Trim();

        public async Task<List<string>> GetButtonNamesOnPage()
        {
            var buttonNamesList = new List<string>();

            foreach (var button in await ButtonLocator.AllAsync())
            {
                buttonNamesList.Add(await button.TextContentAsync());
            }
            
            return buttonNamesList;
        }
    }
}
