using API.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[contoller]")]
    public class PatientDiseaseController
    {
        private readonly IPatientDiseaseService _patientDiseaseService;

        public PatientDiseaseController(IPatientDiseaseService patientDiseaseService)
        {
            _patientDiseaseService = patientDiseaseService;
        }

        [HttpGet]
        [Route("/GetPatientDiseaseByPatietnId")]
        public async Task<ActionResult<PatientDisease>> GetPatientDiseaseByPatietnId(Guid id)
        {
            var patientDisease = await _patientDiseaseService.GetPatientDiseaseByPatietnId(id);
            if (patientDisease == null)
            {
                throw new Exception("not found");
            }
            return patientDisease;
        }

        [HttpPost]
        [Route("/CreateDiseasePatient")]
        public async Task<ActionResult<Guid>> CreatePatientDisease([FromBody] PatientDiseaseCreateRequests request)
        {
            var patinetDisease = PatientDisease.CreatePatientDisease(Guid.NewGuid(), request.PatientId, request.DiseaseId, request.DoctorId, request.DiagnosisDate, null, request.Treatment,request.Comments, DateTime.UtcNow, DateTime.UtcNow);

            if (patinetDisease.error == string.Empty)
            {
                return await _patientDiseaseService.CreateDiseasePatient(patinetDisease.patientdisease);
            }
            throw new Exception(patinetDisease.error);
        }

        [HttpDelete]
        [Route("/DeletePatientDisease")]
        public async Task<ActionResult<Guid>> DeleteExemplar(Guid id)
        {
            return await _patientDiseaseService.DeletePatientDisease(id);
        }

        [HttpPut]
        [Route("/EndTermanet")]
        public async Task<ActionResult<PatientDisease>> EndTermanet(Guid id)
        {
            var result = await _patientDiseaseService.EndTermanetEndOfTreatmentForPatient(id);
            if (result == null)
                throw new Exception("not found");
            return result;
        }
    }
}
