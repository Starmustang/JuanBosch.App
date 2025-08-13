using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Services.Interface.IDoctorService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorReadDto>>> GetAllDoctorsAsync()
        {
            var items = await _doctorService.GetAllDoctorsAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorReadDto>> GetDoctorByIdAsync(int id)
        {
            var item = await _doctorService.GetDoctorByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorReadDto>> CreateDoctorAsync(DoctorCreateDto dto)
        {
            var created = await _doctorService.CreateDoctorAsync(dto);
            return Created($"api/Doctor/{created.DoctorId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorReadDto>> UpdateDoctorAsync(int id, DoctorUpdateDto dto)
        {
            try
            {
                var updated = await _doctorService.UpdateDoctorAsync(id, dto);
                return Ok(updated);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDoctorAsync(int id)
        {
            try
            {
                var deleted = await _doctorService.DeleteDoctorAsync(id);
                return Ok(deleted);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
