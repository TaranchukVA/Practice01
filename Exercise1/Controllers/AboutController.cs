using Microsoft.AspNetCore.Mvc;

namespace Exercise1
{
    [Route("")]
    [ApiController]
    public class AboutController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new WelcomeInfo());
        }
    }
}
