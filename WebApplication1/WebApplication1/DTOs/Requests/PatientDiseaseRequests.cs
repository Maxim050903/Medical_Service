namespace WebApplication1.DTOs.Requests
{
    public record PatientDiseaseCreateRequests
        (
            Guid PatientId,
            Guid DiseaseId,
            Guid DoctorId,
            DateTime DiagnosisDate, 
            string Treatment,
            string Comments,
            DateTime? RecoveryDate = null
        );
}
