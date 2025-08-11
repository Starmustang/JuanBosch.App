using JuanBosch.App.Dtos.Dates;
using JuanBosch.App.Services.Interface.IDateService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateDoctorController : ControllerBase
    {
        private readonly IDateDoctorsService _dateDoctorsService;

        public DateDoctorController(IDateDoctorsService dateDoctorsService)
        {
            _dateDoctorsService = dateDoctorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DateDoctorReadDto>>> GetAllDateDoctorsAsync()
        {
            var items = await _dateDoctorsService.GetAllDateDoctorsAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DateDoctorReadDto>> GetDateDoctorByIdAsync(int id)
        {
            var item = await _dateDoctorsService.GetDateDoctorAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<DateDoctorReadDto>> CreateDateDoctorAsync(DateDoctorCreateDto dto)
        {
            var created = await _dateDoctorsService.CreateDateDoctorAsync(dto);
            return Created($"api/DateDoctor/{created.DateDoctorId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DateDoctorReadDto>> UpdateDateDoctorAsync(int id, DateDoctorUpdateDto dto)
        {
            var updated = await _dateDoctorsService.UpdateDateDoctorAsync(id, dto);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DateDoctorReadDto>> DeleteDateDoctorAsync(int id)
        {
            var deleted = await _dateDoctorsService.DeleteDateDoctorAsync(id);
            return Ok(deleted);
        }
    }
}
