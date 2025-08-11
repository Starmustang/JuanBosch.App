using JuanBosch.App.Dtos.Ars;
using JuanBosch.App.Services.Interface.IArsService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArsEnsuranceController : ControllerBase
    {
        private readonly IArsEnsuranceService _arsEnsuranceService;

        public ArsEnsuranceController(IArsEnsuranceService arsEnsuranceService)
        {
            _arsEnsuranceService = arsEnsuranceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArsEnsurancesReadDto>>> GetAllArsEnsuranceAsync()
        {
            var items = await _arsEnsuranceService.GetAllArsEnsuranceAsync();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArsEnsurancesReadDto>> GetArsEnsuranceByIdAsync(int id)
        {
            var item = await _arsEnsuranceService.GetArsEnsuranceByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ArsEnsurancesReadDto>> CreateArsEnsuranceAsync(ArsEnsurancesCreateDto dto)
        {
            var created = await _arsEnsuranceService.CreateArsEnsuranceAsync(dto);
            return Created($"api/ArsEnsurance/{created.ArsEnsuranceId}", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArsEnsurancesReadDto>> UpdateArsEnsuranceAsync(int id, ArsEnsurancesUpdateDto dto)
        {
            try
            {
                var updated = await _arsEnsuranceService.UpdateArsEnsuranceAsync(id, dto);
                return Ok(updated);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteArsEnsuranceAsync(int id)
        {
            try
            {
                var deleted = await _arsEnsuranceService.DeleteArsEnsuranceAsync(id);
                return Ok(deleted);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
