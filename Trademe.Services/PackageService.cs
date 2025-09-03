using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trademe.Services.Interfaces;
using Trademe.Services.Options;
using Microsoft.Extensions.Options;
using Trademe.Core.Entities;
using Trademe.Services.Models;
using System.Data;

namespace Trademe.Services
{
    public class PackageService : IPackageService
    {
        private readonly List<PackageDetails> _packageDetails;
        private readonly WeightDetails _weightDetails;

        public PackageService(IOptions<List<PackageDetails>> packageDetails, IOptions<WeightDetails> weightDetails)
        {
            _packageDetails = packageDetails.Value;
            _weightDetails = weightDetails.Value;
        }

        public PackageResult? GetPackageSolution(Package package)
        {
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            if (package.Weight > _weightDetails.WeightLimit)
                return null;

            var result = _packageDetails
                .FirstOrDefault(r =>
                    package.Length <= r.Length &&
                    package.Breadth <= r.Breadth &&
                    package.Height <= r.Height);

            return result == null
                ? null
                : new PackageResult
                {
                    Classification = result.Type,
                    Cost = result.Cost
                };



        }
    }
}
