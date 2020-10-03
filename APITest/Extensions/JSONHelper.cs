using Newtonsoft.Json;

namespace APITest.Extensions
{
    public static class JsonHelper
    {
        public static T FromJson<T>(this string obj) => JsonConvert.DeserializeObject<T>(obj);

        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
    }
}
