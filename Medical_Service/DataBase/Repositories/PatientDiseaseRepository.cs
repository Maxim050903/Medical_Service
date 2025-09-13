using Core.Models;
using Microsoft.EntityFrameworkCore;
using DataBase.Entities;
using API.Interfaces;
using Microsoft.Extensions.Logging;

namespace DataBase.Repositories
{
    public class PatientDiseaseRepository : IPatientDiseaseRepository
    {
        private readonly MedDBContext _context;
        private readonly ILogger<PatientDiseaseRepository> _logger;

        public PatientDiseaseRepository(MedDBContext context, ILogger<PatientDiseaseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreatePatientDisease(PatientDisease patientDisease)
        {
            var patientDiseaseEntity = new PatientDiseaseEntity
            {
                Id = patientDisease.Id,
                PatientId = patientDisease.PatientId,
                DiseaseId = patientDisease.DiseaseId,
                DoctorId = patientDisease.DoctorId,
                DiagnosisDate = patientDisease.DiagnosisDate,
                RecoveryDate = patientDisease.RecoveryDate,
                Treatment = patientDisease.Treatment,
                Comments = patientDisease.Comments,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.PatientDiseases.AddAsync(patientDiseaseEntity);

            await _context.SaveChangesAsync();

            return patientDiseaseEntity.Id;
        }

        public async Task<Guid> DeletePatientDisease(Guid id)
        {
            await _context.PatientDiseases.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<PatientDisease> FindPatientDiseaseByIdPatient(Guid id)
        {
            var patientDiseaseEntity = await _context.PatientDiseases.Where(x => x.PatientId == id).FirstOrDefaultAsync();

            if (patientDiseaseEntity != null)
                return PatientDisease.CreatePatientDisease(patientDiseaseEntity.Id, patientDiseaseEntity.PatientId,
                patientDiseaseEntity.DiseaseId, patientDiseaseEntity.DoctorId, patientDiseaseEntity.DiagnosisDate,
                patientDiseaseEntity.RecoveryDate, patientDiseaseEntity.Treatment, patientDiseaseEntity.Comments,
                patientDiseaseEntity.CreatedAt, patientDiseaseEntity.UpdatedAt).patientdisease;
            _logger.LogInformation("Сущость не найдена вернулся null");
            return null;
        }

        public async Task<PatientDisease> EndOfTreatment(Guid id)
        {
            await _context.PatientDiseases.Where(x => x.PatientId == id).
                ExecuteUpdateAsync(b => b
                .SetProperty(b => b.RecoveryDate, b => DateTime.UtcNow));
            await _context.SaveChangesAsync();

            var patientDiseaseUp = await FindPatientDiseaseByIdPatient(id);
            if (patientDiseaseUp != null)
                return patientDiseaseUp;

            _logger.LogInformation("Окончание задачи не удалось id пацианта" + id);
            throw new Exception("End faild");
        }
    }
}
