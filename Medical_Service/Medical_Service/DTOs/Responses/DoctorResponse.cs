namespace Medical_Service.DTOs.Responses
{
    
    public record DoctorResponse(
        string Name,
        string Surname,
        string Otchestvo,
        string Phone,
        string Email,
        string Address,
        string Sepecializetion,
        uint OfficeNumber,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        bool Status = false      
        );
}
