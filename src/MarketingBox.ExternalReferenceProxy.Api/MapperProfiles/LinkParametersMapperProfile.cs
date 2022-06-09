using AutoMapper;
using MarketingBox.ExternalReferenceProxy.Api.Models;
using MarketingBox.TrackingLink.Service.Domain.Models;

namespace MarketingBox.ExternalReferenceProxy.Api.MapperProfiles
{
    public class LinkParametersMapperProfile:Profile
    {
        public LinkParametersMapperProfile()
        {
            CreateMap<LinkParametersModel, LinkParameterValues>();
        }
    }
}