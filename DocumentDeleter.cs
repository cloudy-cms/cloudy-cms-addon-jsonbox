using Cloudy.CMS.DocumentSupport;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.JsonBox
{
    public class DocumentDeleter : IDocumentDeleter
    {
        IEndpointProvider EndpointProvider { get; }

        public DocumentDeleter(IEndpointProvider endpointProvider)
        {
            EndpointProvider = endpointProvider;
        }

        HttpClient Client { get; } = new HttpClient();

        public async Task DeleteAsync(string container, string id)
        {
            var response = await Client.DeleteAsync($"{EndpointProvider.Endpoint}/{id}").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            }
        }
    }
}