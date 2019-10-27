using Microsoft.AspNetCore.Mvc;

namespace PatientApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult GetAsync() => Ok("Hello, World!");
    }
}
