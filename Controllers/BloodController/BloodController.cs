using JuanBosch.App.Dtos.Bloods;
using JuanBosch.App.Services.Interface.IBloodService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodController : ControllerBase
    {
        private readonly IBloodService _bloodService;

        public BloodController(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BloodReadDto>>> GetAllBloodsAsync()
        {
            var bloods = await _bloodService.GetAllBloodsAsync();
            if (bloods == null)
            {
                return NotFound();
            }
            return Ok(bloods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BloodReadDto>> GetBloodByIdAsync(int id)
        {
            var blood = await _bloodService.GetBloodByIdAsync(id);
            if (blood == null)
            {
                return NotFound();
            }
            return Ok(blood);
        }

        [HttpPost]
        public async Task<ActionResult<BloodReadDto>> CreateBloodAsync(BloodCreateDto blood)
        {
            var created = await _bloodService.CreateBloodAsync(blood);
            return Created($"api/Blood/{created.BloodId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BloodReadDto>> UpdateBloodAsync(int id, BloodUpdateDto blood)
        {
            var updated = await _bloodService.UpdateBloodAsync(id, blood);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBloodAsync(int id)
        {
            var result = await _bloodService.DeleteBloodAsync(id);
            return Ok(result);
        }
    }
}
