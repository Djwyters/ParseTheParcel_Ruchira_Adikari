using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trademe.Services.Options
{
    public class PackageDetails
    {
        public string Type { get; set; } = string.Empty;
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public decimal Cost { get; set; }
    }
}
