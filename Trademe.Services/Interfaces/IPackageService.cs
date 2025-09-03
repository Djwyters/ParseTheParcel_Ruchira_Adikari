using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trademe.Core.Entities;
using Trademe.Services.Models;

namespace Trademe.Services.Interfaces
{
    public interface IPackageService
    {
        public PackageResult? GetPackageSolution(Package package);
    }
}
