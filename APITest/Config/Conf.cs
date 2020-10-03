using System.Configuration;

namespace APITest.Config
{
    public static class Conf
    {
        public static string GetValueForKey(string key) => ConfigurationManager.AppSettings[key];
    }
}
