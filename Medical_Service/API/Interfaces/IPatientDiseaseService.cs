using Core.Models;
using System;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IPatientDiseaseService
    {
        Task<Guid> CreateDiseasePatient(PatientDisease patientDisease);
        Task<PatientDisease> GetPatientDiseaseByPatietnId(Guid id);
        Task<PatientDisease> EndTermanetEndOfTreatmentForPatient(Guid id);
        Task<Guid> DeletePatientDisease(Guid id);
    }
}