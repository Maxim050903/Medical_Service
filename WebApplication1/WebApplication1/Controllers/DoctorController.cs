using API.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[contoller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [Route("/getDoctors")]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctor(int page)
        {
            return await _doctorService.GetAllDoctor(page);
        }

        [HttpGet]
        [Route("/getAllDoctorIds")]
        public async Task<ActionResult<List<Guid>>> GetAllDoctorIds()
        {
            return await _doctorService.GetAllDoctorsIds();
        }

        [HttpPost]
        [Route("/CreateDoctor")]
        public async Task<ActionResult<Guid>> CreateDoctor([FromBody] DocterCreateRequest request)
        {
            var doctor = Doctor.CreateDoctor(Guid.NewGuid(), request.Name,
            request.Surname, request.Otchestvo,
            request.Phone, request.Email,
            request.Address, DateTime.UtcNow,
            DateTime.UtcNow, request.Sepecializetion,
            request.OfficeNumber, request.Status);

            if (doctor.error == string.Empty)
            {
                return await _doctorService.CreateDoctor(doctor.doctor);
            }
            return BadRequest(doctor.error);
        }

        [HttpGet]
        [Route("/GetAllSpescialization")]
        public async Task<ActionResult<List<string>>> GetAllSpecialization()
        {
            return await _doctorService.GetAllSpecialization();
        }

        [HttpDelete]
        [Route("/DeleteDoctor")]
        public async Task<ActionResult<Guid>> DeleteDoctor(Guid id)
        {
            return await _doctorService.DeleteDoctor(id);
        }

        [HttpPut]
        [Route("/UpdateDoctor")]
        public async Task<ActionResult<DoctorResponse>> UpdateDoctor(Guid id, [FromBody] DocterCreateRequest request)
        {
            var doctor = Doctor.CreateDoctor(id, request.Name, request.Surname,request.Otchestvo, request.Phone,
                request.Email, request.Address, DateTime.UtcNow,DateTime.UtcNow, request.Sepecializetion,
                request.OfficeNumber, request.Status);
            if (doctor.error == string.Empty)
            {
                var docUp = await _doctorService.UpdateDoctor(doctor.doctor);
                var result = new DoctorResponse
                (
                     docUp.Name,
                     docUp.Surname,
                     docUp.Otchestvo,
                     docUp.Phone,
                     docUp.Email,
                     docUp.Address,
                     docUp.Specialization,
                     docUp.OfficeNumber,
                     docUp.CreatedAt,
                     docUp.UpdatedAt,
                     docUp.Status
                );
                return result;
            }
            return BadRequest("Update faild");   
        }

        [HttpGet]
        [Route("/GetAllInfoBySpecialization")]
        public async Task<ActionResult<List<Doctor>>> GetAllInfoBySpecialization(string specialization)
        {
            return await _doctorService.GetInfoByDoctorForSpecialization(specialization);
        }
    }
}
