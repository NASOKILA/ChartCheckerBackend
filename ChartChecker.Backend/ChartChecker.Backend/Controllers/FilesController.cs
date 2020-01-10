using ChartChecker.Data;
using ChartChecker.Models.Database;
using ChartChecker.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;
using ChartChecker.Models;

namespace ChartChecker.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private ChartCheckerDbContext _db;

        public FilesController(ChartCheckerDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newChartCheck = new ChartCheck
            {
                ChartType = chartCheckDTO.ChartType,
                StoreName = chartCheckDTO.StoreName,
                UserEmail = chartCheckDTO.UserEmail,
                ImagePath = chartCheckDTO.ImagePath,
                EventDateTime = chartCheckDTO.EventDateTime
            };

            await _db.ChartChecks.AddAsync(newChartCheck);

            await _db.SaveChangesAsync();

            Console.WriteLine("Database updated.");

            
            //get top 40
            var currentTopFortyRecords = System.IO.File.ReadAllText("topFortyOrderedSongs.json");

            //get visionrwsults
            var myJsonVisioneResults = System.IO.File.ReadAllText("topFortyOrderedSongs.json");

            //compare

            List<SingleRecordDTO> swapOneAndFiveVisionResults = JsonConvert.DeserializeObject<List<SingleRecordDTO>>(currentTopFortyRecords);

            List<SingleRecordDTO> singlesRecordsList = JsonConvert.DeserializeObject<List<SingleRecordDTO>>(currentTopFortyRecords);

            List<ChartError> chartErrorsList = new List<ChartError>();
            
            foreach (var resultItem in swapOneAndFiveVisionResults)
            {
                var top40ItemByPosition = singlesRecordsList.FirstOrDefault(r => r.Position == resultItem.Position);
                if (resultItem.Name != top40ItemByPosition.Name)
                {
                    //Error exists
                    ChartError chartError = new ChartError();
                    //Get element from top 40 by name and get its position to populate the errorList if it exists, add it to the error else add a resuklt message
                    var top40ItemByResultItemName = singlesRecordsList.FirstOrDefault(r => r.Name == resultItem.Name);

                    if (top40ItemByResultItemName == null)
                    {
                        //Record does not exist in the chart
                    }
                    else {
                        //Record exist in the chart
                        //chartError.Artist = result
                    }

                    chartErrorsList.Add(chartError);

                }   
            }


            //results

            return Ok(new { success = true, newChartCheck = newChartCheck });
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            Console.WriteLine("File received.");

            string filePath = string.Empty;

            try
            {
                string projectPath = _hostingEnvironment.ContentRootPath;

                int randNum = new Random().Next(0, 100000);

                filePath = Path.Combine(Path.GetFullPath("Images"), randNum + file.FileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
            }
            catch (Exception err)
            {
                throw err;
            }

            Console.WriteLine("File saved.");

            return Ok(new { imagePath = filePath });
        }
    }
}
