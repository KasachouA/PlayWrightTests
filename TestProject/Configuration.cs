using System.Configuration;

namespace CoreTestProject
{
    public static class Configuration
    {

        private static string GetValue(string key)
        {
            var environmentVariable = Environment.GetEnvironmentVariable(key);
            var configValue = ConfigurationManager.AppSettings.Get(key);
            return environmentVariable ?? configValue;
        }
    }
}
