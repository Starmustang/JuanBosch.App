using JuanBosch.App.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using JuanBosch.App.Services.Interface;
using JuanBosch.App.Dtos.Patient;

namespace JuanBosch.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPatientService _patientService;   
        public PatientController(DataContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientReadDto>>> GetAllPatientsAsync()
        {
            var patientDto = await _patientService.GetAllPatientsAsync();
            if (patientDto == null)
            {
                return NotFound();
            }
            return Ok(patientDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientReadDto>> GetPatientByIdAsync(int id)
        {
            var patientDto = await _patientService.GetPatientByIdAsync(id);
            if (patientDto == null)
            {
                return NotFound();
            }
            return Ok(patientDto);
        }

        [HttpPost]
        public async Task<ActionResult<PatientReadDto>> CreatePatientAsync(PatientCreateDto patientDto)
        {
            var patient = await _patientService.CreatePatientAsync(patientDto);
            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PatientUpdateDto>> UpdatePatientAsync(int id, PatientUpdateDto patientDto)
        {
            var patient = await _patientService.UpdatePatientAsync(id, patientDto);
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePatientAsync(int id)
        {
            var patient = await _patientService.DeletePatientAsync(id);
            return Ok(patient);
        }
    }
}