using JuanBosch.App.Dtos.Dates;
using JuanBosch.App.Services.Interface.IDateService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateMedicController : ControllerBase
    {
        private readonly IDateMedicService _dateMedicService;

        public DateMedicController(IDateMedicService dateMedicService)
        {
            _dateMedicService = dateMedicService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DateMedicReadDto>>> GetAllDateMedicsAsync()
        {
            var items = await _dateMedicService.GetAllDateMedicsAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DateMedicReadDto>> GetDateMedicByIdAsync(int id)
        {
            var item = await _dateMedicService.GetDateMedicAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<DateMedicReadDto>> CreateDateMedicAsync(DateMedicCreateDto dto)
        {
            var created = await _dateMedicService.CreateDateMedicAsync(dto);
            return Created($"api/DateMedic/{created.DateMedicId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DateMedicReadDto>> UpdateDateMedicAsync(int id, DateMedicUpdateDto dto)
        {
            var updated = await _dateMedicService.UpdateDateMedicAsync(id, dto);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DateMedicReadDto>> DeleteDateMedicAsync(int id)
        {
            var deleted = await _dateMedicService.DeleteDateMedicAsync(id);
            return Ok(deleted);
        }
    }
}
