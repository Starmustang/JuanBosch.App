using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Models.Consultation
{
    public class ConsultationType
    {
        public int ConsultationTypeId { get; set; }
        public int FirstConsultation {get; set;}
        public int FollowUpConsultation {get; set;}
        public int ProcedureConsultation {get; set;}
        public int Others {get; set;}
        public ICollection<DateMedic> DateMedics { get; set; } = new List<DateMedic>();

    }
}