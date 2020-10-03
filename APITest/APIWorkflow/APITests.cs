using System;
using System.IO;
using APITest.Core;
using APITest.Extensions;
using APITest.Formatter;
using APITest.Model;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;

namespace APITest.APIWorkflow
{
    [TestFixture]
    public class ApiTests : BaseApi
    {
        [Test]
        [TestCase("Python", 12, "Animal", 1, "Everything", 10, "Sleep")]
        [TestCase("Cat", 13, "Animal", 1, "Many args[]", 10, "Wake Up")]
        [TestCase("Dog", 14, "Animal", 1, "Everything", 10, "Go to the trip")]
        [TestCase("Elephant", 15, "Animal", 1, "[0]", 10, "Rework")]
        [TestCase("Snake", 25, "Animal", 1, "Maybe 1", 10, "Eat")]
        public async Task Post(string nameAnimal, int id, string categoryName, int categoryId, string tagsName, int tagId, string status)
        {
            var petsData = new ApiPetsData
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

            var requestBody = await
                (await Client.PostAsync(string.Empty, AsStringContent(petsData.ToJson()))
                    .ConfigureAwait(false))
                    .Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

            var desObj = requestBody.FromJson<ApiPetsData>();

            desObj.Should().BeDataContractSerializable(desObj.Name, nameAnimal);
            desObj.Should().BeDataContractSerializable(desObj.Id.ToString(), id.ToString());
            desObj.Should().BeDataContractSerializable(desObj.Category.Name, categoryName);
            desObj.Should().BeDataContractSerializable(desObj.Category.Id.ToString(), categoryId.ToString());
            desObj.Should().BeDataContractSerializable(desObj.Status, status);

            StringFormatter.Post(requestBody);
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public async Task Get(int id)
        {
            var requestBody = await
                (await Client.GetAsync(id.ToString())
                    .ConfigureAwait(false))
                    .Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

            StringFormatter.Get(requestBody);
            Assert.That(requestBody.FromJson<ApiPetsData>().Id, Is.EqualTo(id));
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(25)]
        public async Task Delete(int id)
        {
            var petsData = new ApiPetsData
            {
                Id = id
            };

            var requestBody =
                await Client.DeleteAsync(petsData.Id.ToString()).ConfigureAwait(false);

            switch (requestBody.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    Assert.That(requestBody.StatusCode == HttpStatusCode.NotFound, "Not Found");
                    break;
                case HttpStatusCode.OK:
                    Assert.That(requestBody.StatusCode == HttpStatusCode.OK, "OK");
                    break;
            }
            StringFormatter.Delete(requestBody.ReasonPhrase);
        }
    }
}
