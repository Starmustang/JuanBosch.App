using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SectorReadDto>>> GetAll()
        {
            var items = await _sectorService.GetAllSectorsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SectorReadDto>> GetById(int id)
        {
            var item = await _sectorService.GetSectorByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-municipality/{municipalityId}")]
        public async Task<ActionResult<List<SectorListDto>>> GetByMunicipality(int municipalityId)
        {
            var items = await _sectorService.GetSectorsByMunicipalityIdAsync(municipalityId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<SectorReadDto>> Create(SectorCreateDto dto)
        {
            var created = await _sectorService.CreateSectorAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.SectorId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SectorReadDto>> Update(int id, SectorUpdateDto dto)
        {
            var updated = await _sectorService.UpdateSectorAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _sectorService.DeleteSectorAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
