using API.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Medical_Service.DTOs.Requests;

namespace Medical_Service.Controllers
{
    [ApiController]
    [Route("[contoller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        [Route("/GetDisease")]
        public async Task<ActionResult<List<Disease>>> GetDisease(int page)
        {
            var Diseases = await _diseaseService.GetAllDisease(page);
            return Diseases;
        }

        [HttpGet]
        [Route("/GetDiseaseIds")]
        public async Task<ActionResult<List<Guid>>> GetDiseaseIds()
        {
            return await _diseaseService.GetAllDiseasesIds();
        }

        [HttpPost]
        [Route("/CreateDisease")]
        public async Task<ActionResult<Guid>> CreateDisease([FromBody] DiseaseCreateRequests request)
        {
            var disease = Disease.CreateDisease(Guid.NewGuid(),request.Name, request.IcdCode, request.Description, request.IsChronic, request.Symptoms, DateTime.UtcNow, DateTime.UtcNow);
            if (disease.error == string.Empty)
            {
                return await _diseaseService.CreateDisease(disease.disease);
            }
            return BadRequest(disease.error);
        }

        [HttpDelete]
        [Route("/DeleteDisease")]
        public async Task<ActionResult<Guid>> DeleteDisease(Guid id)
        {
            return await _diseaseService.GeleteDisease(id);
        }

        [HttpPut]
        [Route("/UpdateDisease")]
        public async Task<ActionResult<Disease>> UpdateDisease(Guid id, DiseaseCreateRequests request)
        {
            var disease = Disease.CreateDisease(id,request.Name,request.IcdCode,request.Description,request.IsChronic,request.Symptoms,DateTime.UtcNow,DateTime.UtcNow);

            if (disease.error == string.Empty)
                return await _diseaseService.UpdateDisease(disease.disease);
        
            return BadRequest(disease.error);
        }
    }
}
