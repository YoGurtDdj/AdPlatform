using AdPlatform.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AdPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        // GET: api/<PlatfromsController>
        [HttpGet]
        public IEnumerable<Platform> Get()
        {
            return Storage.Platforms;
        }

        // GET api/<PlatfromsController>/5
        [HttpGet("{id}")]
        public Platform Get(int id)
        {
            return Storage.Platforms[id];
        }

        // POST api/<PlatfromsController>
        [HttpPost]
        public void Post()
        {
            Storage.Platforms.Clear();
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                string? line;
                while((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] words = line.Split(':');
                    Storage.Platforms.Add(new Platform() { Name = words[0], Location = words[1] });
                }

            }
        }
    }
}
