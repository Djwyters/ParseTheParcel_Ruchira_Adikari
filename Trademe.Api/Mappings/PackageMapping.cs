using AutoMapper;
using Trademe.Api.Models;
using Trademe.Core.Entities;
using Trademe.Services.Models;

namespace Trademe.Api.Mappings
{
    public class PackageMapping : Profile
    {
        public PackageMapping() 
        {
            CreateMap<PackageRequest, Package>();
            CreateMap<PackageResult, PackageResponse>(); ;
        }
    }
}
