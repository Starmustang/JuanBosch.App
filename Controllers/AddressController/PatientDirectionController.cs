using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDirectionController : ControllerBase
    {
        private readonly IPatientDirectionService _service;

        public PatientDirectionController(IPatientDirectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDirectionReadDto>>> GetAll()
        {
            var items = await _service.GetAllPatientDirectionsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDirectionReadDto>> GetById(int id)
        {
            var item = await _service.GetPatientDirectionByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-sector/{sectorId}")]
        public async Task<ActionResult<List<PatientDirectionReadDto>>> GetBySector(int sectorId)
        {
            var items = await _service.GetPatientDirectionsBySectorIdAsync(sectorId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDirectionReadDto>> Create(PatientDirectionCreateDto dto)
        {
            var created = await _service.CreatePatientDirectionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.AddressId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDirectionReadDto>> Update(int id, PatientDirectionUpdateDto dto)
        {
            var updated = await _service.UpdatePatientDirectionAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.DeletePatientDirectionAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
