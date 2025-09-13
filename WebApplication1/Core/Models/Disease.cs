namespace Core.Models
{
    public class Disease
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IcdCode { get; set; }

        public string Description { get; set; }

        public bool IsChronic { get; set; } = false;

        public string Symptoms { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        private Disease(Guid id,
            string Name, string IcdCode,
            string Description, bool isChromnic,
            string Symptoms, DateTime CreatedAt,
            DateTime UpdatedAt)
        {
            Id = id;
            this.Name = Name;
            this.IcdCode = IcdCode;
            this.Description = Description;
            this.IsChronic = isChromnic;
            this.Symptoms = Symptoms;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }

        public static (Disease disease, string error) CreateDisease(Guid id,
            string Name, string IcdCode,
            string Description, bool isChromnic,
            string Symptoms, DateTime CreatedAt,
            DateTime UpdatedAt)
        {
            var error = string.Empty;
            if(error == string.Empty)
            {
                var disease = new Disease(id, Name, IcdCode, Description, isChromnic, Symptoms, CreatedAt, UpdatedAt);
                return (disease, error);
            }
            throw new Exception(error);
        }
    }
}
