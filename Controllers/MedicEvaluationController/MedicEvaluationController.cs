using JuanBosch.App.Dtos.MedicEvaluation;
using JuanBosch.App.Services.Interface.IMedicEvaluationService;
using Microsoft.AspNetCore.Mvc;

namespace JuanBosch.App.Controllers.MedicEvaluationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicEvaluationController : ControllerBase
    {
        private readonly IMedicEvaluationService _medicEvaluationService;
        public MedicEvaluationController(IMedicEvaluationService medicEvaluationService)
        {
            _medicEvaluationService = medicEvaluationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicEvaluationReadDto>>> GetAllMedicEvaluationsAsync()
        {
            var medicEvaluationDto = await _medicEvaluationService.GetAllMedicEvaluationsAsync();
            if (medicEvaluationDto == null)
            {
                return NotFound();
            }
            return Ok(medicEvaluationDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicEvaluationReadDto>> GetMedicEvaluationByIdAsync(int id)
        {
            var medicEvaluationDto = await _medicEvaluationService.GetMedicEvaluationByIdAsync(id);
            if (medicEvaluationDto == null)
            {
                return NotFound();
            }
            return Ok(medicEvaluationDto);
        }

        [HttpPost]
        public async Task<ActionResult<MedicEvaluationReadDto>> CreateMedicEvaluationAsync(MedicEvaluationCreateDto medicEvaluationDto)
        {
            var medicEvaluation = await _medicEvaluationService.CreateMedicEvaluationAsync(medicEvaluationDto);
            return Ok(medicEvaluation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MedicEvaluationReadDto>> UpdateMedicEvaluationAsync(int id, MedicEvaluationReadDto medicEvaluationDto)
        {
            var medicEvaluation = await _medicEvaluationService.UpdateMedicEvaluationAsync(id, medicEvaluationDto);
            return Ok(medicEvaluation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMedicEvaluationAsync(int id)
        {
            var medicEvaluation = await _medicEvaluationService.DeleteMedicEvaluationAsync(id);
            return Ok(medicEvaluation);
        }
    }
}