using Autofac;

// ReSharper disable UnusedMember.Global

namespace MarketingBox.ExternalReferenceProxy.Api.Client
{
    public static class AutofacHelper
    {
        public static void RegisterExternalReferenceProxyApiClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new ExternalReferenceProxyApiClientFactory(grpcServiceUrl);
        }
    }
}
