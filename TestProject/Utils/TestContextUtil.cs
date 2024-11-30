using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace CoreTestProject.Utils
{
    public static class TestContextUtil
    {
        public static bool IsTestFailed(this TestContext currentContext) => currentContext.Result.Outcome.Status == TestStatus.Failed;
    }
}
