using Newtonsoft.Json;

namespace APITest.Core
{
    public static class Extension
    {
        public static T FromJSON<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }

        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
