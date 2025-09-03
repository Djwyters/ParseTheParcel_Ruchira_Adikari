using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trademe.Core.Entities
{
    public class Package
    {
        public decimal Length { get; set; }   
        public decimal Breadth { get; set; }  
        public decimal Height { get; set; }   
        public decimal Weight { get; set; }
    }
}
