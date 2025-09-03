using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Trademe.Services.Interfaces;
using Trademe.Services.Options;

namespace Trademe.Services
{
    public class Dependencies
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<PackageDetails>();
            services.AddScoped<WeightDetails>();
        }
    }
}
