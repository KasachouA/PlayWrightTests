using NUnit.Framework;

namespace CoreTestProject
{
    public static class Configuration
    {
        public static string TestAppUrl = TestContext.Parameters["TestAppUrl"];

        public static string ScreenshotsFolder = "TestsScreenshots";
    }
}