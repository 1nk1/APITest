using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace APITest.Core
{
    public abstract class BaseAPI
    {
        protected readonly HttpClient _client;
        protected const string _apiKey = "54682";

        protected BaseAPI()
        {
            _client = CreateClient();
        }

        protected static StringContent AsStringContent(string source)
        {
            return new StringContent(source, Encoding.UTF8, "application/json");
        }

        private static HttpClient CreateClient()
        {
            var client = new HttpClient {
                BaseAddress = new Uri("https://petstore.swagger.io/v2/pet/"), 
                DefaultRequestHeaders = {{"X-Token", _apiKey}}
            };
            client.DefaultRequestHeaders.Accept.Clear();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, SslPolicyErrors) => true;
            return client;
        }
    }
}
