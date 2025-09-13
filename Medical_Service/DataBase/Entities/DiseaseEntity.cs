using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class DiseaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [MaxLength(20)]
        public string IcdCode { get; set; }

        public string Description { get; set; }

        public bool IsChronic { get; set; } = false;

        public string Symptoms { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
