using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace socialfeed.Controllers
{
    [ApiController]
    [Route("")]
    public class HomePage : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(){
            return Redirect("/scalar/v1");
        }
    }
}
