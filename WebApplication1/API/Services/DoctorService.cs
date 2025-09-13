using API.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Guid> CreateDoctor(Doctor doctor)
        {
            return await _doctorRepository.CreateDoctor(doctor);
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            return await _doctorRepository.UpdateDoctor(doctor);
        }

        public async Task<List<Doctor>> GetAllDoctor(int page)
        {
            return await _doctorRepository.GetDoctors(page);
        }

        public async Task<Guid> DeleteDoctor(Guid id)
        {
            return await _doctorRepository.DeleteDoctor(id);
        }

        public async Task<List<Guid>> GetAllDoctorsIds()
        {
            return await _doctorRepository.GetAllDoctorIds();
        }

        public async Task<List<string>> GetAllSpecialization()
        {
            return await _doctorRepository.GetAllSpesicalization();
        }

        public async Task<List<Doctor>> GetInfoByDoctorForSpecialization(string specializaztion)
        {
            return await _doctorRepository.GetAllDoctorBySpecialization(specializaztion);
        }
    }
}
