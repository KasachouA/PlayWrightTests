using CoreTestProject.PlaywrightInitialization;

namespace Tests
{
    [SetUpFixture]
    public class FixtureSetup
    {
        [OneTimeTearDown]
        public void Teardown()
        {
            PlaywrightPageFactory.CloseBrowser();
        }
    }
}
