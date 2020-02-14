using Newtonsoft.Json;

namespace APITest.Extensions
{
    public static class JSONHelper
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
