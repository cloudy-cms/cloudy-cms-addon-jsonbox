using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.JsonBox
{
    public class EndpointProvider : IEndpointProvider
    {
        public string Endpoint { get; }

        public EndpointProvider(string endpoint)
        {
            Endpoint = endpoint;
        }
    }
}
