using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using MarketingBox.ExternalReferenceProxy.Api.Models;
using MarketingBox.Sdk.Common.Extensions;
using MarketingBox.TrackingLink.Service.Domain.Models;
using MarketingBox.TrackingLink.Service.Grpc;
using MarketingBox.TrackingLink.Service.Grpc.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketingBox.ExternalReferenceProxy.Api.Controllers
{
    [ApiController]
    [Route("/api/v2")]
    public class ProxyControllerV2 : ControllerBase
    {
        private readonly ITrackingLinkService _trackingLinkService;
        private readonly IMapper _mapper;
        private ILogger<ProxyControllerV2> _logger;

        public ProxyControllerV2(
            ITrackingLinkService trackingLinkService, 
            IMapper mapper, 
            ILogger<ProxyControllerV2> logger)
        {
            _trackingLinkService = trackingLinkService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{uniqueId}")]
        public async Task<IActionResult> GoToBrand(
            [FromRoute, Required] string uniqueId,
            [FromQuery] LinkParametersModel linkParameters)
        {
            _logger.LogInformation("Request with uniqueId {@UniqueId} and {@LinkParameters}", uniqueId, linkParameters);
            var response = await _trackingLinkService.CreateAsync(
                new TrackingLinkCreateRequest
                {
                    UniqueId = uniqueId,
                    LinkParameterValues = _mapper.Map<LinkParameterValues>(linkParameters)
                });

            this.ProcessResult(response);
            
            _logger.LogInformation("Url {@Url}", response.Data);
            return RedirectPermanent(response.Data);
        }
    }
}