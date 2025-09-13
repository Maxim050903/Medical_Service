using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IPatientDiseaseRepository
    {
        Task<Guid> CreatePatientDisease(PatientDisease patientDisease);
        Task<Guid> DeletePatientDisease(Guid id);
        Task<PatientDisease> FindPatientDiseaseByIdPatient(Guid id);
        Task<PatientDisease> EndOfTreatment(Guid id);
    }
}