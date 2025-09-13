using API.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public class PatiantService : IPatiantService
    {
        private readonly IPatientRepository _patientRepository;

        public PatiantService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Guid> CreatePatient(Patient patient)
        {
            return await _patientRepository.CreatePatient(patient);
        }

        public async Task<List<Patient>> GetAllPatient(int page)
        {
            return await _patientRepository.GetAllPatiant(page);
        }

        public async Task<Guid> DeletePatient(Guid id)
        {
            return await _patientRepository.DeletePatient(id);
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            return await _patientRepository.UpdatePatient(patient);
        }

        public async Task<List<Guid>> GetAllPatientIds()
        {
            return await _patientRepository.GetAllPatientIds();
        }

        public async Task<Patient> GetPatientById(Guid id)
        {
            return await _patientRepository.FindPatientById(id);
        }
    }
}
