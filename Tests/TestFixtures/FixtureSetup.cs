using CoreTestProject;

namespace Tests.TestFixtures
{
    [SetUpFixture]
    public class FixtureSetup
    {
        [OneTimeSetUp]
        public void Setup() 
        { 
            //ignore
        }

        [TearDown] public void Teardown() 
        {
            PlaywrightPageFactory.CloseBrowserAsync();
        }
    }
}
