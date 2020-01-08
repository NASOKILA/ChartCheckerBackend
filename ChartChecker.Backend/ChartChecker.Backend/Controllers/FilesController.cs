using ChartChecker.Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChartChecker.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "files1", "files2" };
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Example exampleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}