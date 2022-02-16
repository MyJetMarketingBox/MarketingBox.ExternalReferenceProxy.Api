using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MarketingBox.ExternalReferenceProxy.Api.Grpc;
using MarketingBox.ExternalReferenceProxy.Api.Grpc.Models;
using MarketingBox.ExternalReferenceProxy.Api.Settings;

namespace MarketingBox.ExternalReferenceProxy.Api.Services
{
    public class HelloService: IHelloService
    {
        private readonly ILogger<HelloService> _logger;

        public HelloService(ILogger<HelloService> logger)
        {
            _logger = logger;
        }

        public Task<HelloMessage> SayHelloAsync(HelloRequest request)
        {
            _logger.LogInformation("Hello from {name}", request.Name);

            return Task.FromResult(new HelloMessage
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
