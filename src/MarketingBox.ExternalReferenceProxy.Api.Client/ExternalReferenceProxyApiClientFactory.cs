using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;

namespace MarketingBox.ExternalReferenceProxy.Api.Client
{
    [UsedImplicitly]
    public class ExternalReferenceProxyApiClientFactory: MyGrpcClientFactory
    {
        public ExternalReferenceProxyApiClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }
    }
}
