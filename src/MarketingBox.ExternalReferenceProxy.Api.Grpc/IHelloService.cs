using System.ServiceModel;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Api.Grpc.Models;

namespace MarketingBox.ExternalReferenceProxy.Api.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}