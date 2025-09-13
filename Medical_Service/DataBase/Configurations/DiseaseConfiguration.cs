using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataBase.Configurations
{
    public class DiseaseConfiguration: IEntityTypeConfiguration<DiseaseEntity>
    {
        public void Configure(EntityTypeBuilder<DiseaseEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name).IsRequired();

            builder.Property(d => d.IcdCode).IsRequired().HasMaxLength(20);

            builder.Property(d => d.Description).IsRequired();

            builder.Property(d => d.Symptoms).IsRequired();

            builder.Property(d => d.IsChronic).IsRequired().HasDefaultValue(false);
        }
    }
}
