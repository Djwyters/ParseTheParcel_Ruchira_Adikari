using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trademe.Services.Models
{
    public class PackageResult
    {
        public string Classification { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }
}
