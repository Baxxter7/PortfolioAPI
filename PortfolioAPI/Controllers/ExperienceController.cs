using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola :)");
        }
    }
    
}
