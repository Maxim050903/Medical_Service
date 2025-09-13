using API.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace API.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _DiseaseRepository;

        public DiseaseService(IDiseaseRepository DiseaseRepository)
        {
            _DiseaseRepository = DiseaseRepository;
        }

        public async Task<Guid> CreateDisease(Disease Disease)
        {
            return await _DiseaseRepository.CreateDisease(Disease);
        }

        public async Task<Disease> UpdateDisease(Disease Disease)
        {
            return await _DiseaseRepository.UpdateDisease(Disease);
        }

        public async Task<List<Disease>> GetAllDisease(int page)
        {
            return await _DiseaseRepository.GetAllDiseases(page);
        }

        public async Task<Guid> GeleteDisease(Guid id)
        {
            return await _DiseaseRepository.DeleteDisease(id);
        }

        public async Task<List<Guid>> GetAllDiseasesIds()
        {
            return await _DiseaseRepository.GetAllDiseaseIds();
        }
    }
}
