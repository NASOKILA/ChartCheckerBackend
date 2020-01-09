using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChartChecker.Backend.Models;
using ChartChecker.Data;
using ChartChecker.Models.Database;
using ChartChecker.Models.DTO;
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
            return new string[] { "files1", "files2" };
        }
        
        // POST api/forms
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChartCheckDTO chartCheckDTO)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            this.SaveImageToServer();


            var newChartCheck = new ChartCheck
            {
                ChartType = chartCheckDTO.ChartType,
                EventDateTime = chartCheckDTO.EventDateTime,
                StoreName = chartCheckDTO.StoreName,
                UserEmail = chartCheckDTO.UserEmail
            };

            await _db.ChartChecks.AddAsync(newChartCheck);

            await _db.SaveChangesAsync();

            return Ok(newChartCheck);
        }

        private void SaveImageToServer()
        {
            Console.WriteLine("Save image to server!");
        }
    }
}