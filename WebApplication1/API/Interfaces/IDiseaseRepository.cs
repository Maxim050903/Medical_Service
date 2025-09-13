using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace API.Interfaces
{
    public interface IDiseaseRepository
    {
        Task<Guid> CreateDisease(Disease disease);
        Task<Guid> DeleteDisease(Guid id);
        Task<List<Guid>> GetAllDiseaseIds();
        Task<List<Disease>> GetAllDiseases(int page);
        Task<Disease> UpdateDisease(Disease disease);
        Task<Disease> FindDiseaseById(Guid id);
    }
}