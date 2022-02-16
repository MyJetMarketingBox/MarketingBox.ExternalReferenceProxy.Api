using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using MarketingBox.ExternalReferenceProxy.Api.Grpc;

namespace MarketingBox.ExternalReferenceProxy.Api.Client
{
    [UsedImplicitly]
    public class ExternalReferenceProxyApiClientFactory: MyGrpcClientFactory
    {
        public ExternalReferenceProxyApiClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
