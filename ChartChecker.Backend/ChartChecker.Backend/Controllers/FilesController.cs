using System.Collections.Generic;
using ChartChecker.Backend.Models;
using ChartChecker.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ChartChecker.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private ChartCheckerDbContext _db;

        public FilesController(ChartCheckerDbContext db)
        {
            _db = db;
        }

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