using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using MarketingBox.ExternalReferenceProxy.Api.Models;
using MarketingBox.Sdk.Common.Extensions;
using MarketingBox.TrackingLink.Service.Domain.Models;
using MarketingBox.TrackingLink.Service.Grpc;
using MarketingBox.TrackingLink.Service.Grpc.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MarketingBox.ExternalReferenceProxy.Api.Controllers
{
    [ApiController]
    [Route("/api/v2")]
    public class ProxyControllerV2 : ControllerBase
    {
        private readonly ITrackingLinkService _trackingLinkService;
        private IMapper _mapper;

        public ProxyControllerV2(
            ITrackingLinkService trackingLinkService, IMapper mapper)
        {
            _trackingLinkService = trackingLinkService;
            _mapper = mapper;
        }

        [HttpGet("{uniqueId}")]
        public async Task<IActionResult> GoToBrand(
            [FromRoute, Required] string uniqueId,
            [FromQuery] LinkParametersModel linkParameters)
        {
            var response = await _trackingLinkService.CreateAsync(
                new TrackingLinkCreateRequest
                {
                    UniqueId = uniqueId,
                    LinkParameterValues = _mapper.Map<LinkParameters>(linkParameters)
                });

            this.ProcessResult(response);
            return RedirectPermanent(response.Data);
        }
    }
}