using APITest.Config;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace APITest.Core
{
    public abstract class BaseApi
    {
        public HttpClient Client { get; }
        protected BaseApi() => Client = CreateClient();
        protected static StringContent AsStringContent(string source) => new StringContent(source, Encoding.UTF8, "application/json");

        private static HttpClient CreateClient()
        {

            var client = new HttpClient
            {
                BaseAddress = new Uri(Conf.GetValueForKey("BASE_URL")),
                DefaultRequestHeaders =
                {
                    { "X-Token", Conf.GetValueForKey("API_KEY")}
                }
            };
            client.DefaultRequestHeaders.Accept.Clear();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            return client;
        }
    }
}
