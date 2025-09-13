using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public abstract class UserBase
    {
        [Key]
        public Guid id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otchestvo { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public UserBase(Guid id, string Name,
            string Surname, string Otchestvo,
            string Phone, string Email,
            string Address, DateTime CreatedAt,
            DateTime UpdatedAt)
        {
            this.id = id;
            this.Name = Name;
            this.Surname = Surname;
            this.Otchestvo = Otchestvo;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
    }
}
