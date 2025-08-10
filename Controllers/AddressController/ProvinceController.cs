using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProvinceReadDto>>> GetAll()
        {
            var items = await _provinceService.GetAllProvincesAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinceReadDto>> GetById(int id)
        {
            var item = await _provinceService.GetProvinceByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-country/{countryId}")]
        public async Task<ActionResult<List<ProvinceListDto>>> GetByCountry(int countryId)
        {
            var items = await _provinceService.GetProvincesByCountryIdAsync(countryId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<ProvinceReadDto>> Create(ProvinceCreateDto dto)
        {
            var created = await _provinceService.CreateProvinceAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ProvinceId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProvinceReadDto>> Update(int id, ProvinceUpdateDto dto)
        {
            var updated = await _provinceService.UpdateProvinceAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _provinceService.DeleteProvinceAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
