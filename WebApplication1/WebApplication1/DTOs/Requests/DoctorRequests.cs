namespace WebApplication1.DTOs.Requests
{
    public record DocterCreateRequest(
        string Name,
        string Surname, 
        string Otchestvo,
        string Phone, 
        string Email,
        string Address, 
        string Sepecializetion,
        uint OfficeNumber, 
        bool Status = false
        );
}
