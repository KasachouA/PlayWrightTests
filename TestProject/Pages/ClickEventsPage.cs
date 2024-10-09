using CoreTestProject.StaticData;
using Microsoft.Playwright;

namespace CoreTestProject.Pages
{
    public class ClickEventsPage : BasePage
    {
        private ILocator PageNameText => Page.GetByRole(AriaRole.Heading);
        private ILocator AnimalButton(string buttonName) => Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = buttonName });
        private ILocator ResponseText => Page.Locator("h2");


        public ClickEventsPage(IPage page) : base(page) { }

        public async Task<bool> IsResponseTextVisible() => await ResponseText.IsVisibleAsync();

        public async Task ClickAnimalButton(Animal button) => await AnimalButton(button.Name).ClickAsync();

        public async Task<string> GetResponseText() => await ResponseText.TextContentAsync();
    }
}
