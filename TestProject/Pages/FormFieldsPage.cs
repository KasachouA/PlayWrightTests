using Microsoft.Playwright;

namespace CoreTestProject.Pages
{
    public class FormFieldsPage : BasePage
    {
        public ILocator PageNameText => Page.GetByRole(AriaRole.Heading);
        public ILocator NameInput => Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { Name = "Name" });
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Submit" });

        public FormFieldsPage(IPage page) : base(page) { }

        public async Task EnterName(string name) => await NameInput.FillAsync(name);

        public async Task ClickSubmit() => await SubmitButton.ClickAsync();
    }
}
