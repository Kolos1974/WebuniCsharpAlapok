using Microsoft.AspNetCore.Mvc;

namespace ServStat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileStatController : ControllerBase
    {

        [HttpGet]
        public JsonResult Get()
        {
            Stat s = new Stat();
            JsonResult res = new JsonResult(s);
            return res;
        }
    }
}