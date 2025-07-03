using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICountryService _countryService;
        public CountryController(DataContext context, ICountryService countryService)
        {
            _context = context;
            _countryService = countryService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountriesAsync()
        {
            var countryDto = await _countryService.GetAllCountriesAsync();
            if (countryDto == null)
            {
                return NotFound();
            }
            return Ok(countryDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(int id)
        {
            var countryDto = await _countryService.GetCountryByIdAsync(id);
            if (countryDto == null)
            {
                return NotFound();
            }
            return Ok(countryDto);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            var countryDto = await _countryService.CreateCountryAsync(country);
            return Ok(countryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountryAsync(int id, Country country)
        {
            var countryDto = await _countryService.UpdateCountryAsync(id, country);
            return Ok(countryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCountryAsync(int id)
        {
            var countryDto = await _countryService.DeleteCountryAsync(id);
            return Ok(countryDto);
        }
    }
}