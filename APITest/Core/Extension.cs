using Newtonsoft.Json;

namespace APITest.Core
{
    public static class Extension
    {
        public static T FromJSON<T>(this string obj)
        {
            var ret = JsonConvert.DeserializeObject<T>(obj);
            return ret;
        }

        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
