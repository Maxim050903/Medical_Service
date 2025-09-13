using API.Interfaces;
using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataBase.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedDBContext _context;
        private readonly ILogger<PatientRepository> _logger;

        public PatientRepository(MedDBContext context,ILogger<PatientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreatePatient(Patient patient)
        {
            var PatientEntity = new PatientEntity
            {
                id = patient.id,
                Name = patient.Name,
                Surname = patient.Surname,
                Otchestvo = patient.Otchestvo,
                Phone = patient.Phone,
                Email = patient.Email,
                Address = patient.Address,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Birthday = patient.Birthday,
                Gender = patient.Gender,
                Allergies = patient.Allergies,
                ChronicConditions = patient.ChronicConditions
            };

            await _context.Patients.AddAsync(PatientEntity);

            await _context.SaveChangesAsync();

            return PatientEntity.id;
        }

        public async Task<List<Patient>> GetAllPatiant(int page)
        {
            var patientsEntities = _context.Patients.Skip((page - 1) * 5).Take(5);

            var patients = await patientsEntities.Select(x => Patient.CreatePatient(x.id, x.Name, x.Surname, x.Otchestvo,
                x.Phone, x.Email, x.Address, x.CreatedAt, x.UpdatedAt, x.Birthday, x.Gender, x.Allergies, x.ChronicConditions).patient).ToListAsync();

            return patients;
        }

        public async Task<List<Guid>> GetAllPatientIds()
        {
            var patientsEntities = _context.Patients.AsNoTracking();

            var patients = await patientsEntities.Select(x => x.id).ToListAsync();

            return patients;
        }

        public async Task<Guid> DeletePatient(Guid id)
        {
            await _context.Patients.Where(x => x.id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {

            await _context.Patients.Where(x => x.id == patient.id).
                ExecuteUpdateAsync(b => b
                .SetProperty(b => b.Name, b => patient.Name)
                .SetProperty(b => b.Surname, b => patient.Surname)
                .SetProperty(b => b.Otchestvo, b => patient.Otchestvo)
                .SetProperty(b => b.Birthday, b => patient.Birthday)
                .SetProperty(b => b.Phone, b => patient.Phone)
                .SetProperty(b => b.Email, b => patient.Email)
                .SetProperty(b => b.Address, b => patient.Address)
                .SetProperty(b => b.Allergies, b => patient.Allergies)
                .SetProperty(b => b.UpdatedAt, b => DateTime.UtcNow)
                .SetProperty(b => b.ChronicConditions, b => patient.ChronicConditions));

            await _context.SaveChangesAsync();

            var patientUpdate = await FindPatientById(patient.id);
            if (patientUpdate != null)
            {
                return patientUpdate;
            }
            _logger.LogInformation("Пациент не обновлен! Входные данные" + patient);
            throw new Exception("Update faild");
        }

        public async Task<Patient> FindPatientById(Guid id)
        {
            var patientEntity = await _context.Patients.Where(x => x.id == id).FirstOrDefaultAsync();

            if (patientEntity != null)
                return Patient.CreatePatient(patientEntity.id, patientEntity.Name, patientEntity.Surname,
                    patientEntity.Otchestvo, patientEntity.Phone, patientEntity.Email,
                    patientEntity.Address, patientEntity.CreatedAt, patientEntity.UpdatedAt,
                    patientEntity.Birthday, patientEntity.Gender, patientEntity.Allergies,
                    patientEntity.ChronicConditions).patient;
            _logger.LogInformation("Пациент не дайден. Вернулось null. Идентификатор " + id);
            return null;
        }
    }
}
