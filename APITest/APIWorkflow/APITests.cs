using APITest.Core;
using APITest.Model;
using NUnit.Framework;
using System.Net;

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
        public void POST(string nameAnimal, int id, string categoryName, int categoryId, string TagsName, int tagId, string status)
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
                    "https://example.com/Animal.jpeg",
                    "https://example.com/Animal.png",
                    "https://example.com/Animal.bmp",
                    "https://example.com/Animal.jpg",
                }
            };
            var requestBody = _client.PostAsync(string.Empty, AsStringContent(petsData.ToJSON()))
                                .Result
                                .Content
                                .ReadAsStringAsync()
                                .Result;
            StringFormatter.ShowConsoleMessage("POST", requestBody);
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public void GET(int id)
        {
            //var reqObj = "{\"id\": " + id +",\"category\": {\"id\": 0,\"name\": \"\" },\"name\": \"doggie\",\"photoUrls\": [\"\"],\"tags\": [{ \"id\": 0,\"name\": \"\" }],\"status\": \"available\"}";
            //var task = _client.GetAsync(id.ToString()).GetAwaiter().GetResult();
            //var response = task.Content.ReadAsAsync<APIPetsData>().ConfigureAwait(false).GetAwaiter().GetResult();
            var requestBody = _client
                              .GetAsync(id.ToString())
                              .Result
                              .Content
                              .ReadAsStringAsync()
                              .Result;

            Assert.That(requestBody.FromJSON<APIPetsData>().Id = id, Is.EqualTo(id));
            StringFormatter.ShowConsoleMessage("GET", requestBody);
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public void DELETE(int id)
        {
            var petsData = new APIPetsData{ Id = id };
            var requestBody  = _client.PostAsync(string.Empty, AsStringContent(petsData.ToJSON())).Result.Content.ReadAsStringAsync().Result;
            StringFormatter.ShowConsoleMessage("DELETE", requestBody);
        }
    } 
}
