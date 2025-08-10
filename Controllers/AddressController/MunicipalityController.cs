using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Services.Interface;
using JuanBosch.App.Services.Interface.IAdressService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
            _municipalityService = municipalityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MunicipalityReadDto>>> GetAll()
        {
            var items = await _municipalityService.GetAllMunicipalitiesAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MunicipalityReadDto>> GetById(int id)
        {
            var item = await _municipalityService.GetMunicipalityByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-province/{provinceId}")]
        public async Task<ActionResult<List<MunicipalityReadDto>>> GetByProvince(int provinceId)
        {
            var items = await _municipalityService.GetMunicipalitiesByProvinceIdAsync(provinceId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<MunicipalityReadDto>> Create(MunicipalityCreateDto dto)
        {
            var created = await _municipalityService.CreateMunicipalityAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.MunicipalityId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MunicipalityReadDto>> Update(int id, MunicipalityUpdateDto dto)
        {
            var updated = await _municipalityService.UpdateMunicipalityAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _municipalityService.DeleteMunicipalityAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
