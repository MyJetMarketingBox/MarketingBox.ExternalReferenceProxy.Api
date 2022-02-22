using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MarketingBox.ExternalReferenceProxy.Api.Domain.Models;
using MarketingBox.ExternalReferenceProxy.Service.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MyJetWallet.Sdk.ServiceBus;
using MyNoSqlServer.Abstractions;

namespace MarketingBox.ExternalReferenceProxy.Api.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class ProxyControllerV1 : ControllerBase
    {
        private readonly IMyNoSqlServerDataReader<RegistrationProxyEntityNoSql> _myNoSqlServerDataReader;
        private readonly IServiceBusPublisher<RegistrationProxyEntityServiceBus> _publisher;

        public ProxyControllerV1(IMyNoSqlServerDataReader<RegistrationProxyEntityNoSql> myNoSqlServerDataReader, 
            IServiceBusPublisher<RegistrationProxyEntityServiceBus> publisher)
        {
            _myNoSqlServerDataReader = myNoSqlServerDataReader;
            _publisher = publisher;
        }

        [HttpGet("{token}")]
        public async Task<ActionResult> GoToBrand(
            [FromRoute, Required] string token)
        {
            var proxyEntity = _myNoSqlServerDataReader
                .Get(RegistrationProxyEntityNoSql.GeneratePartitionKey(token))
                .FirstOrDefault();

            if (proxyEntity == null ||
                proxyEntity.Entity.ExpirationDate < DateTime.UtcNow)
                return BadRequest();
            
            await _publisher.PublishAsync(new RegistrationProxyEntityServiceBus()
            {
                RedirectDate = DateTime.UtcNow,
                BrandLink = proxyEntity.Entity.BrandLink,
                RegistrationId = proxyEntity.Entity.RegistrationId,
                RegistrationUId = proxyEntity.Entity.RegistrationUId,
                TenantId = proxyEntity.Entity.TenantId
            });
            
            return RedirectPermanent(proxyEntity.Entity.BrandLink);
        }
    }
}