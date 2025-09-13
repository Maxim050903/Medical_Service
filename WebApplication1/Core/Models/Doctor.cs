namespace Core.Models
{
    public class Doctor: UserBase
    {
        public string Specialization { get; set; }

        public uint OfficeNumber { get; set; }
        public bool Status { get; set; } = true;

        private Doctor(Guid id, string Name,
            string Surname, string Otchestvo,
            string Phone, string Email,
            string Address, DateTime CreatedAt,
            DateTime UpdatedAt, string Specialization,
            uint OfficeNumber, bool Status): base(id,Name, Surname, Otchestvo, Phone, Email, Address, CreatedAt, UpdatedAt) 
        {
            this.Specialization = Specialization;
            this.OfficeNumber = OfficeNumber;
            this.Status = Status;
        }

        public static (Doctor doctor, string error) CreateDoctor(Guid id, string Name,
            string Surname, string Otchestvo,
            string Phone, string Email,
            string Address, DateTime CreatedAt,
            DateTime UpdatedAt, string Sepecializetion,
            uint OfficeNumber, bool Status)
        {
            var error = string.Empty;
            if (error == string.Empty)
            {
                var doctor = new Doctor(id, Name, Surname, Otchestvo, Phone, Email, Address, CreatedAt, UpdatedAt, Sepecializetion, OfficeNumber, Status);
                return (doctor, error);
            }
            throw new Exception(error);
        }
    }
}
