using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trademe.Core.Entities;
using Trademe.Services;
using Trademe.Services.Interfaces;
using Trademe.Services.Options;

namespace Trademe.Tests
{
    [TestFixture]
    public class PackageServiceTest
    {
        private IPackageService packageService;

        [SetUp]
        public void Setup()
        {
            var packageDetails = new List<PackageDetails>
            {
                new PackageDetails { Type = "Small", Length = 200, Breadth = 300, Height = 150, Cost = 5 },
                new PackageDetails { Type = "Medium", Length = 300, Breadth = 400, Height = 200, Cost = 7.50m },
                new PackageDetails { Type = "Large", Length = 400, Breadth = 600, Height = 250, Cost = 8.50m }
            };

            var weightDetails = new WeightDetails
            {
                WeightLimit = 25
            };

            packageService = new PackageService(
                Options.Create(packageDetails),
                Options.Create(weightDetails)
            );
        }

        [Test]
        public void GetPackageSolution_Valid()
        {
            var package = new Package
            {
                Length = 150,
                Breadth = 200,
                Height = 150,
                Weight = 10
            };

            var result = packageService.GetPackageSolution(package);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Classification, Is.EqualTo("Small"));
            Assert.That(result.Cost, Is.EqualTo(5));
        }

        [Test]
        public void GetPackageSolution_PackageEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => packageService.GetPackageSolution(null));
        }
    }
}
