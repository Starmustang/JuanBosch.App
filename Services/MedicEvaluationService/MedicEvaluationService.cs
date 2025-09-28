using JuanBosch.App.Dtos.MedicEvaluation;
using JuanBosch.App.Mapper;
using JuanBosch.App.Models.Persistence;
using JuanBosch.App.Services.Interface.IMedicEvaluationService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.MedicEvaluationService
{
    public class MedicEvaluationService : IMedicEvaluationService
    {
        private readonly DataContext _context;
        public MedicEvaluationService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MedicEvaluationReadDto>> GetAllMedicEvaluationsAsync()
        {
            return await _context.MedicEvaluations
            .Select(p => MedicEvaluationMapper.ToReadMedicEvaluation(p))
            .ToListAsync();
        }

        public async Task<MedicEvaluationReadDto> GetMedicEvaluationByIdAsync(int id)
        {
            return await _context.MedicEvaluations
            .AsNoTracking()
            .Where(p => p.MedicEvaluationId == id)
            .Select(p => MedicEvaluationMapper.ToReadMedicEvaluation(p))
            .FirstOrDefaultAsync();
        }

        public async Task<MedicEvaluationCreateDto> CreateMedicEvaluationAsync(MedicEvaluationCreateDto medicEvaluation)
        {
            var newMedicEvaluation = medicEvaluation.ToCreateMedicEvaluation();
            _context.MedicEvaluations.Add(newMedicEvaluation);
            await _context.SaveChangesAsync();
            return medicEvaluation;
        }

        public async Task<MedicEvaluationReadDto> UpdateMedicEvaluationAsync(int id, MedicEvaluationReadDto medicEvaluation)
        {
            var existingMedicEvaluation = await _context.MedicEvaluations.FindAsync(id);
            if (existingMedicEvaluation == null)
            {
                throw new ArgumentNullException(nameof(existingMedicEvaluation));
            }
            existingMedicEvaluation.WeightEva = medicEvaluation.WeightEva;
            existingMedicEvaluation.PresurreEva = medicEvaluation.PresurreEva;
            existingMedicEvaluation.BreathingEva = medicEvaluation.BreathingEva;
            existingMedicEvaluation.HeartRateEva = medicEvaluation.HeartRateEva;
            existingMedicEvaluation.OtherInfoEva = medicEvaluation.OtherInfoEva;
            existingMedicEvaluation.HeightEva = medicEvaluation.HeightEva;
            existingMedicEvaluation.PreviousSickNessEva = medicEvaluation.PreviousSickNessEva;
            await _context.SaveChangesAsync();
            return medicEvaluation;
        }

        public async Task<bool> DeleteMedicEvaluationAsync(int id)
        {
            var existingMedicEvaluation = await _context.MedicEvaluations.FindAsync(id);
            if (existingMedicEvaluation == null)
            {
                throw new ArgumentNullException(nameof(existingMedicEvaluation));
            }
            _context.MedicEvaluations.Remove(existingMedicEvaluation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}