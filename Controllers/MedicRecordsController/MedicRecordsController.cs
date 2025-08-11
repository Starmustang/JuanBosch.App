using JuanBosch.App.Dtos.MedicRecordDtos;
using JuanBosch.App.Services.Interface.IMedicRecordService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicRecordsController : ControllerBase
    {
        private readonly IMedicRecordsService _medicRecordsService;

        public MedicRecordsController(IMedicRecordsService medicRecordsService)
        {
            _medicRecordsService = medicRecordsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicRecordReadDto>>> GetAllMedicRecordsAsync()
        {
            var items = await _medicRecordsService.GetAllMedicRecordsAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicRecordReadDto>> GetMedicRecordByIdAsync(int id)
        {
            var item = await _medicRecordsService.GetMedicRecordByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<MedicRecordCreateDto>> CreateMedicRecordAsync(MedicRecordCreateDto dto)
        {
            var created = await _medicRecordsService.CreateMedicRecordAsync(dto);
            // Service returns create DTO (no generated ID), so return 200 OK to avoid invalid Location header
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MedicRecordReadDto>> UpdateMedicRecordAsync(int id, MedicRecordUpdateDto dto)
        {
            try
            {
                var updated = await _medicRecordsService.UpdateMedicRecordAsync(id, dto);
                return Ok(updated);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMedicRecordAsync(int id)
        {
            try
            {
                var deleted = await _medicRecordsService.DeleteMedicRecordAsync(id);
                return Ok(deleted);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
