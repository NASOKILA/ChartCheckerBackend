using ChartChecker.Backend.Models;
using ChartChecker.Data;
using ChartChecker.Models.Database;
using ChartChecker.Models.DTO;
using ChartChecker.Models.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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




        //[HttpGet("RefreshChartData")]
        //public async Task<IActionResult> RefreshChartData(ChartType chartType, int fetch, string token)
        //{
        //    try
        //    {
        //        IChartStrategy startergy = null;

        //        switch (chartType)
        //        {
        //            case ChartType.MusicSingle:

        //                startergy = new ChartStratergies.Charts.MusicSinglesStrategy();

        //                break;

        //            default:
        //                throw new InvalidOperationException($"No strategy found for chartType {chartType}");
        //        }

        //        startergy.GetData();

        //    }
        //    catch (Exception ex)
        //    {


        //    }

        //    return Ok();
        //}


        [HttpGet("RefreshChartData")]
        //public async Task<IActionResult> RefreshChartData()
        public async Task<IActionResult> RefreshChartData(string chartType, int fetch, string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Invalid token provided");
            }

            if (fetch == 0)
            {
                return BadRequest("Invalid Fetch size Provided");
            }

            ChartType chartStrategy;
            if (!Enum.TryParse<ChartType>(chartType, out chartStrategy))
            {
                return BadRequest("Invalid Chart Type specified");
            }

            try
            {

                switch (chartStrategy)
                {
                    case ChartType.MusicSingle:

                        Console.WriteLine("Connecting to ChartAPI.");

                        var playlistId = "4OIVU71yO7SzyGrh0ils2i";
                        string baseAddress = "https://api.spotify.com/v1/playlists";
                        string apiUrl = $"https://api.spotify.com/v1/playlists/{playlistId}/tracks";
                        var query = $"?market=gb&limit={fetch}";
                        var credentialKey = token;// "BQAyLboeUOrjLsEQ-JbYQaBUIOGhdSwFubw4C5ncY3I1Se0oZ8VPGyWJkZ-LgbDDbPG7zV65Wi8MBSFuxnK8VBFsvTpybHVHKuxUIWLUnosIhaWhMQ1x5B6wQLDkGxWMjVbdthb7IKy2WZPrLbNewfimWC_XWzIlj9rmhUB96f9uJo7gesD9lMD6iQ";

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(baseAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credentialKey);

                            Console.WriteLine($"Api URL = {apiUrl + query}");

                            //var responseMessage = await client.GetAsync(apiUrl + query);
                            var responseMessageString = await client.GetStringAsync(apiUrl + query);

                            if (string.IsNullOrWhiteSpace(responseMessageString))
                            {
                                Console.WriteLine("Error - Nothing returned from API Call");
                                return BadRequest("Error - Nothing returned from API Call");
                            }
                            else
                            {
                                //save to Database
                                ChartData data = new ChartData
                                {
                                    ChartDate = DateTime.UtcNow,
                                    ChartType = ChartType.MusicSingle,
                                    Data = responseMessageString
                                };

                                await _db.ChartData.AddAsync(data);
                                await _db.SaveChangesAsync();
                                await GetLatestChartData(ChartType.MusicSingle);
                            }
                        }
                        break;

                    default:
                        return BadRequest($"ChartType {chartStrategy} not implemented");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get API Data {ex.ToString()}");
            }

            return Ok("Refreshed Data");
        }

        private async Task<List<ChartItem>> GetLatestChartData(ChartType strategy)
        {
            var latestChart = (from d in _db.ChartData
                              where d.ChartType == strategy
                              orderby d.ChartDate descending
                              select d).FirstOrDefault();

            var data = JsonConvert.DeserializeObject<Rootobject>(latestChart.Data);

            var chartItems = new List<ChartItem>();


            //data.items.Select(new ChartItem() { Artist = "", Id = "", Name = "", Position = ""})

            int i = 1;
            foreach (var item in data.items)
            {

                chartItems.Add(new ChartItem
                {
                    //Id = i,
                    Position = i,
                    Artist = item.track.artists.First().name,
                    Name = item.track.name
                });

                i++;
            }

            return chartItems;
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





            return Ok(newChartCheck);
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
