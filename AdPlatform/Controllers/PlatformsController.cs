using AdPlatform.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AdPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Platform> Get()
        {
            return Storage.Platforms;
        }

        [HttpGet("find")]
        public IEnumerable<string> FindPlatforms([FromQuery] string location)
        {
            return Storage.Platforms
                .Where(p => p.AllLocsForPlatform.Contains(location))
                .Select(p => p.Name)
                .ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] FilePath path)
        {
            if (string.IsNullOrEmpty(path.Path))
            {
                path.Path = "input.txt";
            }
            if (!System.IO.File.Exists(path.Path))
            {
                return NotFound("Файл не найден");
            }

            Storage.Platforms.Clear();

            try
            {
                using (StreamReader reader = new StreamReader(path.Path))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] words = line.Split(':');
                        string[] locs = words[1].Split(",");

                        Platform platform = new Platform() { Name = words[0] };
                        foreach (string i in locs)
                        {
                            platform.Locations.Add(i);
                        }
                        Storage.Platforms.Add(platform);
                    }
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ошибка при чтении файла" + ex);
            }


            var allLocations = Storage.Platforms.SelectMany(p => p.Locations).Distinct().ToList();

            foreach (var p in Storage.Platforms)
            {
                foreach (var loc in allLocations)
                {
                    if (p.Locations.Any(a => loc.StartsWith(a)))
                    {
                        p.AllLocsForPlatform.Add(loc);
                    }
                }
            }

            return Ok(new { message = "Данные загружены" });
        }
    }
}
