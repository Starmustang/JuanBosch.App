using JuanBosch.App.Dtos.Ars;
using JuanBosch.App.Services.Interface.IArsService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArsPlansController : ControllerBase
    {
        private readonly IArsPlanService _arsPlanService;

        public ArsPlansController(IArsPlanService arsPlanService)
        {
            _arsPlanService = arsPlanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArsPlanReadDto>>> GetAllArsPlansAsync()
        {
            var items = await _arsPlanService.GetAllArsPlanAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArsPlanReadDto>> GetArsPlanByIdAsync(int id)
        {
            var item = await _arsPlanService.GetArsPlanByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ArsPlanReadDto>> CreateArsPlanAsync(ArsPlanCreateDto dto)
        {
            var created = await _arsPlanService.CreateArsPlanAsync(dto);
            return Created($"api/ArsPlans/{created.ArsPlansId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArsPlanReadDto>> UpdateArsPlanAsync(int id, ArsPlanUpdateDto dto)
        {
            try
            {
                var updated = await _arsPlanService.UpdateArsPlanAsync(id, dto);
                return Ok(updated);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteArsPlanAsync(int id)
        {
            try
            {
                var deleted = await _arsPlanService.DeleteArsPlanAsync(id);
                return Ok(deleted);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
