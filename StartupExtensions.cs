using Cloudy.Cms.Addon.JsonBox;
using Cloudy.CMS;
using Cloudy.CMS.DocumentSupport;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class StartupExtensions
    {
        public static CloudyConfigurator WithJsonBoxDocuments(this CloudyConfigurator configurator, string endpoint)
        {
            configurator.Services.AddSingleton<IEndpointProvider>(new EndpointProvider(endpoint));
            configurator.Services.AddTransient<IDocumentPropertyFinder, DocumentPropertyFinder>();
            configurator.Services.AddSingleton<IDocumentCreator, DocumentCreator>();
            configurator.Services.AddSingleton<IDocumentDeleter, DocumentDeleter>();
            configurator.Services.AddSingleton<IDocumentFinder, DocumentFinder>();
            configurator.Services.AddSingleton<IDocumentGetter, DocumentGetter>();
            configurator.Services.AddSingleton<IDocumentUpdater, DocumentUpdater>();
            configurator.Services.AddTransient<IDocumentFinderQueryBuilder, DocumentFinderQueryBuilder>();

            configurator.Options.HasDocumentProvider = true;

            return configurator;
        }
    }
}
