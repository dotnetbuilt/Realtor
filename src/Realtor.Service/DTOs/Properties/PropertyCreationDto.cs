using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Properties;

public class PropertyCreationDto
{
    public Status Status { get; set; }
    public string Description { get; set; }
    public RealEstateType RealEstateType { get; set; }
    public int CeilingHeight { get; set; }
    public Material WallMadeOf { get; set; }
    public DateOnly BuiltIn { get; set; }
    public DateOnly SubmissionDate { get; set; }
}