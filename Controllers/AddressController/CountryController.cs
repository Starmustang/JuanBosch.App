using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Dtos.Country;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CountryReadDto>>> GetAllCountriesAsync()
        {
            var countryDto = await _countryService.GetAllCountriesAsync();
            if (countryDto == null)
            {
                return NotFound();
            }
            return Ok(countryDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryReadDto>> GetCountryByIdAsync(int id)
        {
            var countryDto = await _countryService.GetCountryByIdAsync(id);
            if (countryDto == null)
            {
                return NotFound();
            }
            return Ok(countryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CountryReadDto>> CreateCountryAsync(CountryCreateDto country)
        {
            var countryDto = await _countryService.CreateCountryAsync(country);
            return CreatedAtAction(nameof(GetCountryByIdAsync), new { id = countryDto.CountryId }, countryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CountryReadDto>> UpdateCountryAsync(int id, CountryUpdateDto country)
        {
            var countryDto = await _countryService.UpdateCountryAsync(id, country);
            if (countryDto == null) return NotFound();
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