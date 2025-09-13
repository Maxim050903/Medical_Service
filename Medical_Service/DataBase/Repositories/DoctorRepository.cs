using API.Interfaces;
using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Numerics;

namespace DataBase.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedDBContext _context;
        private readonly ILogger<DoctorRepository> _logger;

        public DoctorRepository(MedDBContext context, ILogger<DoctorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreateDoctor(Doctor Doctor)
        {
            _logger.LogInformation("Начали процесс создания Доктора");
            
            var doctorEntity = new DoctorEntity
            {
                id = Doctor.id,
                Name = Doctor.Name,
                Surname = Doctor.Surname,
                Otchestvo = Doctor.Otchestvo,
                Phone = Doctor.Phone,
                Email = Doctor.Email,
                Address = Doctor.Address,
                OfficeNumber = Doctor.OfficeNumber,
                Specialization = Doctor.Specialization,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Doctors.AddAsync(doctorEntity);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Доктор создан");

            return doctorEntity.id;
        }

        public async Task<List<Doctor>> GetDoctors(int page)
        {
            _logger.LogInformation("Получение Докторов из бд");
            var DoctorsEntities = _context.Doctors.Skip((page - 1) * 5).Take(5);

            var Doctors = await DoctorsEntities.Select(x => Doctor.CreateDoctor(x.id, x.Name,
            x.Surname, x.Otchestvo,
            x.Phone, x.Email,
            x.Address, x.CreatedAt,
            x.UpdatedAt, x.Specialization,
            x.OfficeNumber, x.Status).doctor).ToListAsync();

            _logger.LogInformation("Получение завершено");
            return Doctors;
        }

        public async Task<List<Guid>> GetAllDoctorIds()
        {
            _logger.LogInformation("Получение id Докторов");
            var DoctorsEntities = _context.Doctors.AsNoTracking();

            var Doctors = await DoctorsEntities.Select(x => x.id).ToListAsync();

            _logger.LogInformation("Получение завершено");
            return Doctors;
        }

        public async Task<Guid> DeleteDoctor(Guid id)
        {
            _logger.LogInformation("Уделние доктора с id"+ id);
            await _context.Doctors.Where(x => x.id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            _logger.LogInformation("Удаление завершено");
            return id;
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            _logger.LogInformation("Начато обновление Докторая. Входыне данные" + doctor);
            await _context.Doctors.Where(x => x.id == doctor.id).
                ExecuteUpdateAsync(b => b
                .SetProperty(b => b.Name, b => doctor.Name)
                .SetProperty(b => b.Surname, b => doctor.Surname)
                .SetProperty(b => b.Otchestvo, b => doctor.Otchestvo)
                .SetProperty(b => b.Phone, b => doctor.Phone)
                .SetProperty(b => b.Email, b => doctor.Email)
                .SetProperty(b => b.Address, b => doctor.Address)
                .SetProperty(b => b.Specialization, b => doctor.Specialization)
                .SetProperty(b => b.OfficeNumber, b => doctor.OfficeNumber)
                .SetProperty(b => b.UpdatedAt, b => DateTime.UtcNow)
                .SetProperty(b => b.Status, b => doctor.Status));

            _logger.LogInformation("Доктор обновлен\n");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Доктор проверка успеха обноления");
            var doctorUp =  await FindDoctorById(doctor.id);
            if (doctorUp != null)
                return doctorUp;
            throw new Exception("Update faild");
        }

        public async Task<Doctor> FindDoctorById(Guid id)
        {
            _logger.LogInformation("Начало процесса поиска по id"+ id);
            var DoctorEntity = await _context.Doctors.Where(x => x.id == id).FirstOrDefaultAsync();

            if (DoctorEntity != null)
                return Doctor.CreateDoctor(DoctorEntity.id, DoctorEntity.Name, DoctorEntity.Surname,
                    DoctorEntity.Otchestvo, DoctorEntity.Phone, DoctorEntity.Email,
                    DoctorEntity.Address, DoctorEntity.CreatedAt, DoctorEntity.UpdatedAt,
                    DoctorEntity.Specialization, DoctorEntity.OfficeNumber, DoctorEntity.Status).doctor;
            _logger.LogInformation("Пользователь не найдеy, введено неверное id");
            throw new Exception("Doctor not found");
        }

        public async Task<List<string>> GetAllSpesicalization()
        {
            _logger.LogInformation("Получение специализайций");
            var spesializations = await _context.Doctors.Select(x => x.Specialization).ToListAsync();

            var result = spesializations.Distinct().ToList();

            return result;
        }

        public async Task<List<Doctor>> GetAllDoctorBySpecialization(string value)
        {
            var doctors = await _context.Doctors.Where(x => x.Specialization == value).ToListAsync();

            var result = doctors.Select(x => Doctor.CreateDoctor(x.id, x.Name,
                x.Surname, x.Otchestvo,
                x.Phone, x.Email,
                x.Address, x.CreatedAt,
                x.UpdatedAt, x.Specialization,
                x.OfficeNumber, x.Status).doctor).ToList();
            return result;
        }
    }
}
