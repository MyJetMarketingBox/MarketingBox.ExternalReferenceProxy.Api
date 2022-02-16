using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace MarketingBox.ExternalReferenceProxy.Api.Settings
{
    public class SettingsModel
    {
        [YamlProperty("ExternalReferenceProxy.Api.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("ExternalReferenceProxy.Api.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("ExternalReferenceProxy.Api.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
