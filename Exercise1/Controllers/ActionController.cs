using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercise1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionBusiness actionBusiness;

        public ActionController(IActionBusiness actionBusiness)
        {
            this.actionBusiness = actionBusiness;
        }

        [HttpGet()]
        public IActionResult Get(string method = "all", int count = 1)
        {
            IMethodResult result = actionBusiness.Get(method, count);

            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest();
        }
        [HttpPost]
        public IActionResult Post([FromBody] List<Dictionary<string, string>> prams)
        {
            IMethodResult result = actionBusiness.PostAsync(prams).Result;

            if (result.Success)
                return Ok();
            else
                return BadRequest();
        }

    }
}
