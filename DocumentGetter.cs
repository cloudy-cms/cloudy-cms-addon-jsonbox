using Cloudy.CMS.DocumentSupport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.JsonBox
{
    public class DocumentGetter : IDocumentGetter
    {
        IEndpointProvider EndpointProvider { get; }

        public DocumentGetter(IEndpointProvider endpointProvider)
        {
            EndpointProvider = endpointProvider;
        }

        HttpClient Client { get; } = new HttpClient();

        public async Task<Document> GetAsync(string container, string id)
        {
            var response = await Client.GetAsync($"{EndpointProvider.Endpoint}/{container}?q=Id:{id}").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            }

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IEnumerable<Document>>(result).FirstOrDefault();
        }
    }
}