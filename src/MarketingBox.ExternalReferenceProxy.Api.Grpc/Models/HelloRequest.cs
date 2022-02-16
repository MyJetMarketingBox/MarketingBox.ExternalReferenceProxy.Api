using System.Runtime.Serialization;

namespace MarketingBox.ExternalReferenceProxy.Api.Grpc.Models
{
    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
}