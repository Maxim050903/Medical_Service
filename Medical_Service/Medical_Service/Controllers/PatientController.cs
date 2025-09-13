using API.Interfaces;
using API.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Medical_Service.DTOs.Requests;
using Medical_Service.DTOs.Responses;

namespace Medical_Service.Controllers
{
    [ApiController]
    [Route("[contoller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatiantService _patientService;

        public PatientController(IPatiantService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("/GetPatients")]
        public async Task<ActionResult<List<Patient>>> GetAllPatient(int page)
        {
            return await _patientService.GetAllPatient(page);
        }

        [HttpGet]
        [Route("/GetAllPatientIds")]
        public async Task<ActionResult<List<Guid>>> GetAllPatientIds()
        {
            return await _patientService.GetAllPatientIds();
        }

        [HttpGet]
        [Route("/GetOnePatient")]
        public async Task<ActionResult<Patient>> GetPatientById(Guid id)
        {
            var result = await _patientService.GetPatientById(id);
            if (result == null)
            {
                return BadRequest("Patient not found");
            }
            return result;
        }

        [HttpPost]
        [Route("/CreatePatient")]
        public async Task<ActionResult<Guid>> CreatePatient([FromBody] PatientCreateRequest request)
        {
            var patient = Patient.CreatePatient(Guid.NewGuid(),request.Name,request.Surname,request.Otchestvo,request.Phone,
                request.Email,request.Address,DateTime.UtcNow,DateTime.UtcNow,request.birthday,request.gender,request.allergies,request.chronicConditions);

            if (patient.error == string.Empty)
            {
                return await _patientService.CreatePatient(patient.patient);
            }
            return BadRequest(patient.error);
        }

        [HttpDelete]
        [Route("/DeletePatient")]
        public async Task<ActionResult<Guid>> DeletePatient(Guid id)
        {
            return await _patientService.DeletePatient(id);
        }

        [HttpPut]
        [Route("/UpdatePatient")]
        public async Task<ActionResult<PatientUpdateResponse>> UpdatePatient(Guid id, [FromBody] PatientCreateRequest request)
        {
            var patient = Patient.CreatePatient(id, request.Name, request.Surname, request.Otchestvo, request.Phone,
                request.Email, request.Address, DateTime.UtcNow, DateTime.UtcNow, request.birthday, request.gender, request.allergies, request.chronicConditions);
            if (patient.error == string.Empty)
            {
                var docUp = await _patientService.UpdatePatient(patient.patient);
                var result = new PatientUpdateResponse
                (
                     docUp.Name,
                     docUp.Surname,
                     docUp.Otchestvo,
                     docUp.Phone,
                     docUp.Email,
                     docUp.Address,
                     docUp.CreatedAt,
                     docUp.UpdatedAt,
                     docUp.Birthday,
                     docUp.Gender,
                     docUp.Allergies,
                     docUp.ChronicConditions
                );
                return result;
            }
            return BadRequest("Update faild");
        }
    }
}
