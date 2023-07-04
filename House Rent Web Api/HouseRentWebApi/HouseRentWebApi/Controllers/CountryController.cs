using HouseRentWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICollection<Country> _countries;

        public CountryController()
        {
            _countries = new List<Country>
            {
                new Country { Id = 1, Name = "Bangladesh" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "Canada" },
                new Country { Id = 4, Name = "Austrila" },
                new Country { Id = 5, Name = "England" }
            };
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Country>>> GetAllCountries()
        {
            var countries = await Task.Run(() => _countries.ToList());
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await Task.Run(() => _countries.FirstOrDefault(c => c.Id == id));
            return Ok(country);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}