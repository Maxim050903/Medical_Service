using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    public class DoctorConfiguration: IEntityTypeConfiguration<DoctorEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.HasKey(x => x.id);
           
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Surname).IsRequired();

            builder.Property(x => x.Otchestvo).IsRequired();

            builder.Property(x => x.Phone).IsRequired().HasMaxLength(12);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Address).IsRequired();

            builder.Property(x => x.Specialization).IsRequired();
        }
    }
}
