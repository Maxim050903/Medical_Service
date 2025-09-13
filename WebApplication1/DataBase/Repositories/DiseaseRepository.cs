using API.Interfaces;
using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataBase.Repositories
{
    public class DiseaseRepository:IDiseaseRepository
    {
        private readonly MedDBContext _context;
        private readonly ILogger<DiseaseRepository> _logger;

        public DiseaseRepository(MedDBContext context, ILogger<DiseaseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreateDisease(Disease disease)
        {
            _logger.LogInformation("Начат процесс создания болезни");
            var DiseaseEntity = new DiseaseEntity
            {
                Id = disease.Id,
                Name = disease.Name,
                IcdCode = disease.IcdCode,
                Description = disease.Description,
                IsChronic = disease.IsChronic,
                Symptoms = disease.Symptoms,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Diseases.AddAsync(DiseaseEntity);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Болезнь создана");
            return DiseaseEntity.Id;
        }

        public async Task<List<Disease>> GetAllDiseases(int page)
        {
            var DiseasesEntities = _context.Diseases.Skip((page - 1) * 5).Take(5);

            var Diseases = await DiseasesEntities.Select(x => Disease.CreateDisease(x.Id, x.Name,
                x.IcdCode, x.Description, x.IsChronic, x.Symptoms, x.CreatedAt, x.UpdatedAt).disease).ToListAsync();

            return Diseases;
        }

        public async Task<List<Guid>> GetAllDiseaseIds()
        {
            var DiseasesEntities = _context.Diseases.AsNoTracking();

            var Diseases = await DiseasesEntities.Select(x => x.Id).ToListAsync();

            return Diseases;
        }

        public async Task<Guid> DeleteDisease(Guid id)
        {
            await _context.Diseases.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Disease> UpdateDisease(Disease disease)
        {
            await _context.Diseases.Where(x => x.Id == disease.Id).
                ExecuteUpdateAsync(b => b
                .SetProperty(b => b.Name, b => disease.Name)
                .SetProperty(b => b.IcdCode, b => disease.IcdCode)
                .SetProperty(b => b.Description, b => disease.Description)
                .SetProperty(b => b.IsChronic, b => disease.IsChronic)
                .SetProperty(b => b.Symptoms, b => disease.Symptoms)
                .SetProperty(b => b.CreatedAt, b => disease.CreatedAt)
                .SetProperty(b => b.UpdatedAt, b => DateTime.UtcNow));

            await _context.SaveChangesAsync();

            var diseaseUp = await FindDiseaseById(disease.Id);
            
            if (diseaseUp != null)
                return diseaseUp;
            _logger.LogInformation("Обновить болезнь не удалось");
            throw new Exception("update daild");
        }

        public async Task<Disease> FindDiseaseById(Guid id)
        {
            var DiseaseEntity = await _context.Diseases.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (DiseaseEntity != null)
                return Disease.CreateDisease(DiseaseEntity.Id, DiseaseEntity.Name,
                DiseaseEntity.IcdCode, DiseaseEntity.Description, DiseaseEntity.IsChronic,
                DiseaseEntity.Symptoms, DiseaseEntity.CreatedAt, DiseaseEntity.UpdatedAt).disease;
            _logger.LogInformation("Болезнь не найдена" + id);
            throw new Exception("Disease not found");
        }
    }
}
