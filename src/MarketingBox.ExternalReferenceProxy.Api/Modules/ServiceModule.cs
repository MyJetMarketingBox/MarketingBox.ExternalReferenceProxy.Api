using Autofac;
using MarketingBox.ExternalReferenceProxy.Api.Domain.Models;
using MarketingBox.ExternalReferenceProxy.Service.Domain.Models;
using MarketingBox.TrackingLink.Service.Client;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.NoSql;
using MyJetWallet.Sdk.ServiceBus;

namespace MarketingBox.ExternalReferenceProxy.Api.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var noSqlClient = builder.CreateNoSqlClient(Program.ReloadedSettings(e => e.MyNoSqlReaderHostPort).Invoke(),
                new LoggerFactory());
            builder.RegisterMyNoSqlReader<RegistrationProxyEntityNoSql>(noSqlClient,
                RegistrationProxyEntityNoSql.TableName);

            var serviceBusClient = builder
                .RegisterMyServiceBusTcpClient(
                    Program.ReloadedSettings(e => e.MarketingBoxServiceBusHostPort),
                    Program.LogFactory);

            builder.RegisterMyServiceBusPublisher<RegistrationProxyEntityServiceBus>(serviceBusClient,
                RegistrationProxyEntityServiceBus.Topic, false);

            builder.ServiceClient(Program.ReloadedSettings(e => e.TrackingLinkServiceUrl).Invoke());
        }
    }
}