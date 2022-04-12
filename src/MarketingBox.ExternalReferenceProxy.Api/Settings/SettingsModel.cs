using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace MarketingBox.ExternalReferenceProxy.Api.Settings
{
    public class SettingsModel
    {
        [YamlProperty("ExternalReferenceProxyApi.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("ExternalReferenceProxyApi.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("ExternalReferenceProxyApi.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("ExternalReferenceProxyApi.MyNoSqlReaderHostPort")]
        public string MyNoSqlReaderHostPort { get; set; }

        [YamlProperty("ExternalReferenceProxyApi.MarketingBoxServiceBusHostPort")]
        public string MarketingBoxServiceBusHostPort { get; set; }

        [YamlProperty("ExternalReferenceProxyApi.MarketingBoxTrackingLinkServiceUrl")]
        public string MarketingBoxTrackingLinkServiceUrl { get; set; }
    }
}
