using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class MedDBContext : DbContext
    {
        public MedDBContext(DbContextOptions<MedDBContext> options) 
            : base(options)
        {
        }
        public DbSet<DiseaseEntity> Diseases {get; set;}
        public DbSet<DoctorEntity> Doctors { get; set;}
        public DbSet<PatientEntity> Patients {get; set;}
        public DbSet<PatientDiseaseEntity> PatientDiseases {get;set;}
    }
}
