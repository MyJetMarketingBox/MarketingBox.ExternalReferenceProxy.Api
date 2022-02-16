using System;
using System.Runtime.Serialization;

namespace MarketingBox.ExternalReferenceProxy.Api.Domain.Models
{
    [DataContract]
    public class RegistrationProxyEntityServiceBus
    {
        public const string Topic = "merketingbox-registrationproxyentity-redirectevent";

        [DataMember(Order = 1)] public DateTime RedirectDate { get; set; }
        [DataMember(Order = 2)] public string BrandLink { get; set; }
        [DataMember(Order = 3)] public long RegistrationId { get; set; }
        [DataMember(Order = 4)] public string RegistrationUId { get; set; }
        [DataMember(Order = 5)] public string TenantId { get; set; }
    }
}