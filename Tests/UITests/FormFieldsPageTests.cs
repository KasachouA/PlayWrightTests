using Allure.NUnit.Attributes;
using CoreTestProject.Pages;
using Tests.TestFixtures;

namespace Tests.UITests
{
    [AllureSuite("Form Fields page")]
    public class FormFieldsPageTests : BaseTest
    {
        private FormFieldsPage _formFieldsPage;
        private LearnAndPracticeAutomationPage _learnAndPracticeAutomationPage;

        [Test]
        public async Task NameInputVerification()
        {
            _learnAndPracticeAutomationPage = new LearnAndPracticeAutomationPage(Page);
            _formFieldsPage = new FormFieldsPage(Page);

            await _learnAndPracticeAutomationPage.ClickFormFieldsButton();
            await _formFieldsPage.EnterName("Andrei");
            await Expect(_formFieldsPage.NameInput).ToHaveAccessibleNameAsync("Name");
            await Expect(_formFieldsPage.NameInput).ToHaveValueAsync("Andrei");

            await _formFieldsPage.ClickSubmit();
            await Expect(_formFieldsPage.NameInput).ToHaveValueAsync("");
        }
    }
}
