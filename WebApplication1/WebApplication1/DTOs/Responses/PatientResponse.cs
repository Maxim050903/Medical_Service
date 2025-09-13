namespace WebApplication1.DTOs.Responses
{
    public record PatientUpdateResponse
        (
            string Name,
            string Surname, 
            string Otchestvo,
            string Phone, 
            string Email,
            string Address, 
            DateTime CreatedAt,
            DateTime UpdatedAt, 
            DateTime birthday,
            char? gender, 
            string allergies,
            string chronicConditions
        );
}
