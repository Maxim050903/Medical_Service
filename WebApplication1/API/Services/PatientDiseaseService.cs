using API.Interfaces;
using Core.Models;
using System;
using System.Threading.Tasks;

namespace API.Services
{
    public class PatientDiseaseService : IPatientDiseaseService
    {
        private readonly IPatientDiseaseRepository _patientDiseaseService;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDiseaseRepository _diseaseRepository;


        public PatientDiseaseService(IPatientDiseaseRepository patientDiseaseService,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IDiseaseRepository diseaseRepository)
        {
            _patientDiseaseService = patientDiseaseService;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _diseaseRepository = diseaseRepository;
        }

        public async Task<Guid> CreateDiseasePatient(PatientDisease patientDisease)
        {
            var patient = await _patientRepository.FindPatientById(patientDisease.PatientId);
            var disease = await _diseaseRepository.FindDiseaseById(patientDisease.DiseaseId);
            var doctor = await _doctorRepository.FindDoctorById(patientDisease.DoctorId);

            if ((patient != null) && (doctor != null) && (disease != null))
            {
                return await _patientDiseaseService.CreatePatientDisease(patientDisease);
            }
            throw new Exception("Create PatiantDisease faild check data validation");
        }

        public async Task<PatientDisease> GetPatientDiseaseByPatietnId(Guid id)
        {
            var result = await _patientDiseaseService.FindPatientDiseaseByIdPatient(id);
            if (result == null)
                throw new Exception("not found");
            return result;
        }

        public async Task<PatientDisease> EndTermanetEndOfTreatmentForPatient(Guid id)
        {
            var result = await _patientDiseaseService.EndOfTreatment(id);
            if (result == null)
                throw new Exception("patient not found");
            return result;
        }

        public async Task<Guid> DeletePatientDisease(Guid id)
        {
            return await _patientDiseaseService.DeletePatientDisease(id);
        }
    }
}
