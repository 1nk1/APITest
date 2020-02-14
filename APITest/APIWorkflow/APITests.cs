using APITest.Core;
using APITest.Extensions;
using APITest.Formatter;
using APITest.Model;
using NUnit.Framework;
using System.Net;

namespace APITest.APIWorkflow
{
    [TestFixture]
    public class APITests : BaseAPI
    {
        [Test]
        [TestCase("Python", 12, "Animal", 1, "Everything", 10, "Sleep")]
        [TestCase("Cat", 13, "Animal", 1, "Many args[]", 10, "Wake Up")]
        [TestCase("Dog", 14, "Animal", 1, "Everything", 10, "Go to the trip")]
        [TestCase("Elephant", 15, "Animal", 1, "[0]", 10, "Rework")]
        [TestCase("Snake", 25, "Animal", 1, "Maybe 1", 10, "Eat")]
        public void POST(string nameAnimal, int id, string categoryName, int categoryId, string tagsName, int tagId, string status)
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
                        Name = tagsName
                    },
                },
                Status = status,
                Id = id,
                PhotoUrls = new[]
                {
                    "https://example.com/Animal.jpeg",
                    "https://example.com/Animal.png",
                    "https://example.com/Animal.bmp",
                    "https://example.com/Animal.jpg",
                }
            };

            var _requestBody = _client.PostAsync(string.Empty, AsStringContent(petsData.ToJSON())).Result.Content.ReadAsStringAsync().Result;
            var DesObj = _requestBody.FromJSON<APIPetsData>();

            Assert.That(DesObj.Name, Is.EqualTo(nameAnimal));
            Assert.That(DesObj.Id, Is.EqualTo(id));
            Assert.That(DesObj.Category.Name, Is.EqualTo(categoryName));
            Assert.That(DesObj.Category.Id, Is.EqualTo(categoryId));
            Assert.That(DesObj.Status, Is.EqualTo(status));
            StringFormatter.POST(_requestBody);
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public void GET(int id)
        {
            //Another way!!!
            //var task = _client.GetAsync(id.ToString()).GetAwaiter().GetResult();
            //var response = task.Content.ReadAsAsync<APIPetsData>().ConfigureAwait(false).GetAwaiter().GetResult();

            var _requestBody = _client.GetAsync(id.ToString()).Result.Content.ReadAsStringAsync().Result;

            StringFormatter.GET(_requestBody);
            Assert.That(_requestBody.FromJSON<APIPetsData>().Id, Is.EqualTo(id));
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public void DELETE(int id)
        {
            var petsData = new APIPetsData { Id = id };
            var _requestBody = _client.DeleteAsync(petsData.Id.ToString()).Result;
            switch (_requestBody.StatusCode)
            {
                case HttpStatusCode.NotFound: Assert.That(_requestBody.StatusCode == HttpStatusCode.NotFound, "Not Found"); break;
                case HttpStatusCode.OK: Assert.That(_requestBody.StatusCode == HttpStatusCode.OK, "OK"); break;
            }
            StringFormatter.DELETE(_requestBody.ReasonPhrase);
        }
    }
}
