using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    public class PatientConfiguretion: IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasKey(p => p.id);

           
            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.Surname).IsRequired();

            builder.Property(p => p.Otchestvo).IsRequired();

            builder.Property(p => p.Phone).IsRequired().HasMaxLength(12);

            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Address).IsRequired();
            
            builder.Property(b => b.Name).IsRequired();

            builder.Property(b => b.Birthday).IsRequired();

            builder.Property(b => b.Gender).IsRequired().HasMaxLength(1);

            builder.Property(b => b.Allergies).IsRequired();

            builder.Property(b => b.ChronicConditions).IsRequired();
        }
    }
}
