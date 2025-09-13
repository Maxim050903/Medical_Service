namespace WebApplication1.DTOs.Requests
{
    public record DiseaseCreateRequests
    (
        string Name,
        string IcdCode,
        string Description,
        bool IsChronic,
        string Symptoms
        );
}
