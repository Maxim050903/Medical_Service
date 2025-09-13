using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public abstract class UserBase
    {
        [Key]
        public Guid id { get; set; }

        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Otchestvo { get; set; }

        [MaxLength(12)]
        public required string Phone { get; set; }
        [MaxLength(100)]
        public required string Email { get; set; }
        public required string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
