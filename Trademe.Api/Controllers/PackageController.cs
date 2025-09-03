using AutoMapper;
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
        private readonly IMapper _mapper;

        public PackageController(IPackageService packageService, IMapper mapper)
        {
            _packageService = packageService;
            _mapper = mapper;
        }

        [HttpPost("packageSolution")]
        public IActionResult GetSolution([FromBody] PackageRequest package)
        {
            try
            {
                if (package == null)
                    return BadRequest(new { message = "Invalid package" });

                var packageEntity = _mapper.Map<Package>(package);
                var result = _packageService.GetPackageSolution(packageEntity);

                if (result == null)
                    return BadRequest(new { message = "No suitable package found" });

                var response = _mapper.Map<PackageResponse>(result);

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
