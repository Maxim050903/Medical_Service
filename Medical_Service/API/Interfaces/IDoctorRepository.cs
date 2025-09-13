using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Guid> CreateDoctor(Doctor Doctor);
        Task<Guid> DeleteDoctor(Guid id);
        Task<List<Guid>> GetAllDoctorIds();
        Task<List<Doctor>> GetDoctors(int page);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<Doctor> FindDoctorById(Guid id);
        Task<List<string>> GetAllSpesicalization();
        Task<List<Doctor>> GetAllDoctorBySpecialization(string value);
    }
}