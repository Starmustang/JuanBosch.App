using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Services.Interface.IDoctorService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorEnsuranceController : ControllerBase
    {
        private readonly IDoctorEnsuranceService _doctorEnsuranceService;

        public DoctorEnsuranceController(IDoctorEnsuranceService doctorEnsuranceService)
        {
            _doctorEnsuranceService = doctorEnsuranceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorEnsurancesReadDto>>> GetAllDoctorEnsuranceAsync()
        {
            var items = await _doctorEnsuranceService.GetAllDoctorEnsuranceAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorEnsurancesReadDto>> GetDoctorEnsuranceByIdAsync(int id)
        {
            try
            {
                var item = await _doctorEnsuranceService.GetDoctorEnsuranceByIdAsync(id);
                return Ok(item);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<DoctorEnsurancesReadDto>> CreateDoctorEnsuranceAsync(DoctorEnsurancesCreateDto dto)
        {
            var created = await _doctorEnsuranceService.CreateDoctorEnsuranceAsync(dto);
            return Created($"api/DoctorEnsurance/{created.DoctorEnsuranceId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorEnsurancesReadDto>> UpdateDoctorEnsuranceAsync(int id, DoctorEnsurancesUpdateDto dto)
        {
            try
            {
                var updated = await _doctorEnsuranceService.UpdateDoctorEnsuranceAsync(id, dto);
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
        public async Task<ActionResult<bool>> DeleteDoctorEnsuranceAsync(int id)
        {
            try
            {
                var deleted = await _doctorEnsuranceService.DeleteDoctorEnsuranceAsync(id);
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
