using APITest.Core;
using APITest.Model;
using NUnit.Framework;
using System;

namespace APITest.APIWorkflow
{
    [TestFixture]
    public class APITests : BaseAPI
    {
        [Test]
        [TestCase("Python",   12, "Animal", 1, "Everything",  10, "Sleep")]
        [TestCase("Cat",      13, "Animal", 1, "Many args[]", 10, "Wake Up")]
        [TestCase("Dog",      14, "Animal", 1, "Everything",  10, "Go to the trip")]
        [TestCase("Elephant", 15, "Animal", 1, "[0]",         10, "Rework")]
        [TestCase("Snake",    25, "Animal", 1, "Maybe 1",     10, "Eat")]
        public void PostRequest(string nameAnimal, int id, string categoryName, int categoryId, string TagsName, int tagId, string status)
        {
            var petsData = new APIPetsData
            {
                Name = nameAnimal,
                Category = new Category
                {
                    Name = categoryName,
                    Id = categoryId
                },
                Tags = new[] {
                    new Tags
                    {
                        Id = tagId, 
                        Name = TagsName
                    }, 
                }, 
                Status = status, 
                Id = id,
                PhotoUrls = new []
                {
                    "https://example.com/img1.jpeg"
                }
            };
            var request = _client.PostAsync(string.Empty, AsStringContent(petsData.ToJSON())).Result;
            var result = request.EnsureSuccessStatusCode();
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public void GetRequest(int id)
        {
            //var reqObj = "{\"id\": " + id +",\"category\": {\"id\": 0,\"name\": \"\" },\"name\": \"doggie\",\"photoUrls\": [\"\"],\"tags\": [{ \"id\": 0,\"name\": \"\" }],\"status\": \"available\"}";
            //var task = _client.GetAsync(id.ToString()).GetAwaiter().GetResult();
            //var response = task.Content.ReadAsAsync<APIPetsData>().ConfigureAwait(false).GetAwaiter().GetResult();
            var req = _client.GetAsync(id.ToString()).Result.Content.ReadAsStringAsync().Result;
            var res = req.FromJSON<APIPetsData>();
            Console.WriteLine(res.ToJSON());
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public void DeleteRequest(int id)
        {
            var petsData = new APIPetsData{Id = id};
            var result = _client.PostAsync(string.Empty, AsStringContent(petsData.ToJSON())).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
