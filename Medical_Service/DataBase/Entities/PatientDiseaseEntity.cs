using System.ComponentModel.DataAnnotations;


namespace DataBase.Entities
{
    public class PatientDiseaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PatientId { get; set; }

        public Guid DiseaseId { get; set; }

        public Guid DoctorId { get; set; }

        public DateTime DiagnosisDate { get; set; }

        public DateTime? RecoveryDate { get; set; } // null, если болезнь не вылечена

        public required string Treatment {  get; set; }

        public required string Comments { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
