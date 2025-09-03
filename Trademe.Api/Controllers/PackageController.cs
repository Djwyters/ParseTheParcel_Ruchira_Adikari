using Microsoft.AspNetCore.Mvc;
using System.Net;
using Trademe.Api.Models;
using Trademe.Core.Entities;
using Trademe.Services.Interfaces;

namespace Trademe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost("packageSolution")]
        public IActionResult GetSolution([FromBody] Package package)
        {
            try
            {
                if (package == null)
                    return BadRequest(new { message = "Invalid package" });

                var result = _packageService.GetPackageSolution(package);

                if (result == null)
                    return BadRequest(new { message = "No suitable package found" });

                var response = new PackageResponse
                {
                    Classification = result.Classification,
                    Cost = result.Cost
                };

                return Ok(response);


            }
            catch (Exception exc)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                { message = "An error occurred while getttingpackage solution", details = exc.Message });
            }
        }
    }
}
