using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Patient: UserBase
    {
        public DateTime Birthday { get; set; }

        [MaxLength(1)]
        public char? Gender { get; set; }

        public string Allergies { get; set; }

        public string ChronicConditions { get; set; }

        private Patient (Guid id, string Name,
            string Surname, string Otchestvo,
            string Phone, string Email,
            string Address, DateTime CreatedAt,
            DateTime UpdatedAt,DateTime birthday, 
            char? gender, string allergies, 
            string chronicConditions) : base(id, Name,
            Surname, Otchestvo,
            Phone, Email,
            Address,CreatedAt,
            UpdatedAt)
        {
            Birthday = birthday;
            Gender = gender;
            Allergies = allergies;
            ChronicConditions = chronicConditions;
        }

        public static (Patient patient, string error) CreatePatient(Guid id, string Name,
            string Surname, string Otchestvo, string Phone, string Email,
            string Address, DateTime CreatedAt, DateTime UpdatedAt, DateTime birthday,
            char? gender, string allergies, string chronicConditions)
        {
            var error = string.Empty;
            
            if (error == string.Empty)
            {
                var patient = new Patient(id, Name, Surname, Otchestvo, Phone, Email, Address, CreatedAt, UpdatedAt, birthday, gender, allergies, chronicConditions);
                return (patient, error);
            }
            
            throw new Exception(error);
        }
    }
}
