using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDoctorService
    {
        Task<Guid> CreateDoctor(Doctor doctor);
        Task<Guid> DeleteDoctor(Guid id);
        Task<List<Doctor>> GetAllDoctor(int page);
        Task<List<Guid>> GetAllDoctorsIds();
        Task<List<string>> GetAllSpecialization();
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<List<Doctor>> GetInfoByDoctorForSpecialization(string specializaztion);
    }
}