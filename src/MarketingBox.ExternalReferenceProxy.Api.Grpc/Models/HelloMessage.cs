using System.Runtime.Serialization;
using MarketingBox.ExternalReferenceProxy.Api.Domain.Models;

namespace MarketingBox.ExternalReferenceProxy.Api.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}