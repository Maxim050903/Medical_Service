namespace Medical_Service.DTOs.Requests
{
    public record PatientCreateRequest(
        string Name,
        string Surname, 
        string Otchestvo,
        string Phone, 
        string Email,
        string Address, 
        DateTime birthday,
        char? gender, 
        string allergies,
        string chronicConditions
        );
}
