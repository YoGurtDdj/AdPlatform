using Microsoft.AspNetCore.Mvc;


namespace AdPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatfromsController : ControllerBase
    {
        // GET: api/<PlatfromsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PlatfromsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlatfromsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlatfromsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlatfromsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
