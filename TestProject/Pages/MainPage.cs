using CoreTestProject.StaticData;
using Microsoft.Playwright;

namespace CoreTestProject.Pages
{
    public class MainPage : BasePage
    {
        public ILocator PageNameText => Page.GetByRole(AriaRole.Heading);
        public ILocator Button(MainPageButton button) => Page.Locator($"//a[text() = '{button.Name}']");

        public MainPage(IPage page) : base(page)
        {
        }

        public async Task ClickButton(MainPageButton button) => await Button(button).ClickAsync();
    }
}
