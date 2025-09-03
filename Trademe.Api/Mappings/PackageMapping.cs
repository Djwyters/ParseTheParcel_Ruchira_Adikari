using AutoMapper;
using Trademe.Api.Models;
using Trademe.Core.Entities;

namespace Trademe.Api.Mappings
{
    public class PackageMapping : Profile
    {
        public PackageMapping() 
        {
            CreateMap<PackageRequest, PackageResponse>();
            CreateMap<PackageResponse, PackageRequest>();
        }
    }
}
