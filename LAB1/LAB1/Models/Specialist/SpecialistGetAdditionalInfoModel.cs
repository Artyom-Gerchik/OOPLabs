using LAB1.Entities;

namespace LAB1.Models.Specialist;

public class SpecialistGetAdditionalInfoModel
{
    public List<Company>? Companies { get; set; }
    public int? IdOfSelectedCompany { get; set; }
}