using System.Collections.Generic;
using ChartChecker.Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ChartChecker.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // GET api/forms
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "forms1", "forms2" };
        }
        
        // POST api/forms
        [HttpPost]
        public string Post([FromBody] Example reqModel)
        {
            return reqModel.Name;
        }
    }
}