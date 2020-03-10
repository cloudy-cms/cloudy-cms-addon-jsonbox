using Cloudy.CMS.DocumentSupport;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.JsonBox
{
    public class DocumentCreator : IDocumentCreator
    {
        IEndpointProvider EndpointProvider { get; }

        public DocumentCreator(IEndpointProvider endpointProvider)
        {
            EndpointProvider = endpointProvider;
        }

        HttpClient Client { get; } = new HttpClient();

        public async Task Create(string container, Document document)
        {
            var response = await Client.PostAsync($"{EndpointProvider.Endpoint}/{container}", new StringContent(JsonConvert.SerializeObject(document), Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            }

            var m = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return;
        }
    }
}