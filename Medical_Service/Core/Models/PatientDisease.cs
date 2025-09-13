using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class PatientDisease
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DiseaseId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public DateTime? RecoveryDate { get; set; } // null, если болезнь не вылечена
        public string Treatment { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        private PatientDisease(Guid id, Guid patientId, Guid diseaseId,
            Guid doctorId, DateTime diagnosisDate, DateTime? recoveryDate,
            string treatment, string comments, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            PatientId = patientId;
            DiseaseId = diseaseId;
            DoctorId = doctorId;
            DiagnosisDate = diagnosisDate;
            RecoveryDate = recoveryDate;
            Treatment = treatment;
            Comments = comments;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static (PatientDisease patientdisease, string error) CreatePatientDisease(Guid id, Guid patientId, Guid diseaseId,
            Guid doctorId, DateTime diagnosisDate, DateTime? recoveryDate,
            string treatment, string comments, DateTime createdAt, DateTime updatedAt)
        {
            var error = string.Empty;
            if(error == string.Empty)
            {
                var patientdisease = new PatientDisease(id, patientId, diseaseId, doctorId, diagnosisDate, recoveryDate, treatment, comments, createdAt, updatedAt);
                return (patientdisease, error);
            }
            throw new Exception(error);
        }
    }
}
