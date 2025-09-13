using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class PatientEntity : UserBase
    {
        public DateTime Birthday { get; set; }

        [MaxLength(1)]
        public char? Gender { get; set; }

        public required string Allergies { get; set; }

        public required string ChronicConditions { get; set; }
    }
}
