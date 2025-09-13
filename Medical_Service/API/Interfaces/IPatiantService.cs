using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IPatiantService
    {
        Task<Guid> CreatePatient(Patient patient);
        Task<Guid> DeletePatient(Guid id);
        Task<List<Patient>> GetAllPatient(int page);
        Task<List<Guid>> GetAllPatientIds();
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> GetPatientById(Guid id);
    }
}