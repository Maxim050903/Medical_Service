using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    public class PatientDeseaseConfiguration: IEntityTypeConfiguration<PatientDiseaseEntity>
    {
        public void Configure(EntityTypeBuilder<PatientDiseaseEntity> builder)
        {
            builder.HasKey(mr => mr.Id);

            builder.Property(mr => mr.PatientId).IsRequired();

            builder.Property(mr => mr.DiseaseId).IsRequired();

            builder.Property(mr => mr.DoctorId).IsRequired();

            builder.Property(mr => mr.DiagnosisDate).IsRequired();

            builder.Property(mr => mr.Treatment).IsRequired();

            builder.Property(mr => mr.Comments).IsRequired();
        }
    }
}
