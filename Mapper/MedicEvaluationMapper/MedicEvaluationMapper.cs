using JuanBosch.App.Dtos.MedicEvaluation;
using JuanBosch.App.Models.MedicEvaluations;

namespace JuanBosch.App.Mapper
{
    public static class MedicEvaluationMapper
    {
        public static MedicEvaluation ToCreateMedicEvaluation(this MedicEvaluationCreateDto medicEvaluationCreateDto)
        {
            if (medicEvaluationCreateDto == null)
            {
                throw new ArgumentNullException(nameof(medicEvaluationCreateDto));
            }
            return new MedicEvaluation
            {
                WeightEva = medicEvaluationCreateDto.WeightEva,
                PresurreEva = medicEvaluationCreateDto.PresurreEva,
                BreathingEva = medicEvaluationCreateDto.BreathingEva,
                HeartRateEva = medicEvaluationCreateDto.HeartRateEva,
                OtherInfoEva = medicEvaluationCreateDto.OtherInfoEva,
                HeightEva = medicEvaluationCreateDto.HeightEva,
                PreviousSickNessEva = medicEvaluationCreateDto.PreviousSickNessEva
            };
        }

        public static MedicEvaluationReadDto ToReadMedicEvaluation(this MedicEvaluation medicEvaluation)
        {
            if (medicEvaluation == null)
            {
                throw new ArgumentNullException(nameof(medicEvaluation));
            }
            return new MedicEvaluationReadDto
            {
                MedicEvaluationId = medicEvaluation.MedicEvaluationId,
                WeightEva = medicEvaluation.WeightEva,
                PresurreEva = medicEvaluation.PresurreEva,
                BreathingEva = medicEvaluation.BreathingEva,
                HeartRateEva = medicEvaluation.HeartRateEva,
                OtherInfoEva = medicEvaluation.OtherInfoEva,
                HeightEva = medicEvaluation.HeightEva,
                PreviousSickNessEva = medicEvaluation.PreviousSickNessEva
            };
        }

        public static MedicEvaluation ToUpdateMedicEvaluation(this MedicEvaluationUpdateDto medicEvaluationUpdateDto)
        {
            if (medicEvaluationUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(medicEvaluationUpdateDto));
            }
            return new MedicEvaluation
            {
                MedicEvaluationId = medicEvaluationUpdateDto.MedicEvaluationId,
                WeightEva = medicEvaluationUpdateDto.WeightEva,
                PresurreEva = medicEvaluationUpdateDto.PresurreEva,
                BreathingEva = medicEvaluationUpdateDto.BreathingEva,
                HeartRateEva = medicEvaluationUpdateDto.HeartRateEva,
                OtherInfoEva = medicEvaluationUpdateDto.OtherInfoEva,
                HeightEva = medicEvaluationUpdateDto.HeightEva,
                PreviousSickNessEva = medicEvaluationUpdateDto.PreviousSickNessEva
            };
        }
    }
}