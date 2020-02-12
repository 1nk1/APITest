
using System.Runtime.Serialization;

namespace APITest.Model
{
    [DataContract]
    public class APIPetsData
    {
        [DataMember(Name = "id")] public int Id { get; set; }

        [DataMember(Name = "category")]
        public Category Category { get; set; } 

        [DataMember(Name = "name")] 
        public string Name { get; set; }

        [DataMember(Name = "photoUrls")]
        public string[] PhotoUrls { get; set; }

        [DataMember(Name = "tags")]
        public Tags[] Tags { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    [DataContract(Name = "tags")]
    public class Tags
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract(Name = "category")]
    public class Category
    {
        [DataMember(Name = "id")] public int Id { get; set; }
        [DataMember(Name = "name")] public string Name { get; set; }
    }
}
