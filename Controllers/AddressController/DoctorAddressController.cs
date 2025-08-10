using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAddressController : ControllerBase
    {
        private readonly IDoctorAddressService _service;

        public DoctorAddressController(IDoctorAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorAddressReadDto>>> GetAll()
        {
            var items = await _service.GetAllDoctorAddressesAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorAddressReadDto>> GetById(int id)
        {
            var item = await _service.GetDoctorAddressByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-sector/{sectorId}")]
        public async Task<ActionResult<List<DoctorAddressReadDto>>> GetBySector(int sectorId)
        {
            var items = await _service.GetDoctorAddressesBySectorIdAsync(sectorId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorAddressReadDto>> Create(DoctorAddressCreateDto dto)
        {
            var created = await _service.CreateDoctorAddressAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.DoctorAddressId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorAddressReadDto>> Update(int id, DoctorAddressUpdateDto dto)
        {
            var updated = await _service.UpdateDoctorAddressAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.DeleteDoctorAddressAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
