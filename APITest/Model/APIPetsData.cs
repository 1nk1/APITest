
using Newtonsoft.Json;

namespace APITest.Model
{
    public class ApiPetsData
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("category")]
        public Category Category { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("photoUrls")]
        public string[] PhotoUrls { get; set; }
        [JsonProperty("tags")]
        public Tags[] Tags { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Tags
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}
