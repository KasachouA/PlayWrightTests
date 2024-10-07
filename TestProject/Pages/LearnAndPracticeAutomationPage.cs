using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTestProject.Pages
{
    public class LearnAndPracticeAutomationPage : BasePage
    {
        public ILocator PageNameText => Page.GetByRole(AriaRole.Heading);
        private ILocator FormFieldsButton => Page.Locator("//a[text() = 'Form Fields']");

        public LearnAndPracticeAutomationPage(IPage page) : base(page)
        {
        }

        public async Task ClickFormFieldsButton() => await FormFieldsButton.ClickAsync();
        //public async void AssertPageName(string pageName) => await )
    }
}
