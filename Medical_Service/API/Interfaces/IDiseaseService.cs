using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDiseaseService
    {
        Task<Guid> CreateDisease(Disease Disease);
        Task<Guid> GeleteDisease(Guid id);
        Task<List<Disease>> GetAllDisease(int page);
        Task<List<Guid>> GetAllDiseasesIds();
        Task<Disease> UpdateDisease(Disease Disease);
    }
}