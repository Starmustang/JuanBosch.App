using JuanBosch.App.Dtos.MedicEvaluation;

namespace JuanBosch.App.Services.Interface.IMedicEvaluationService
{
    public interface IMedicEvaluationService
    {
        Task<List<MedicEvaluationReadDto>> GetAllMedicEvaluationsAsync();
        Task<MedicEvaluationReadDto> GetMedicEvaluationByIdAsync(int id);
        Task<MedicEvaluationCreateDto> CreateMedicEvaluationAsync(MedicEvaluationCreateDto medicEvaluation);
        Task<MedicEvaluationReadDto> UpdateMedicEvaluationAsync(int id, MedicEvaluationReadDto medicEvaluation);
        Task<bool> DeleteMedicEvaluationAsync(int id);
    }
}