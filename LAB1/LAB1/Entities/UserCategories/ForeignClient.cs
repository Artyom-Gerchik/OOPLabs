namespace LAB1.Entities.UserCategories;

public class ForeignClient : User
{
    public string? InternationalPassportNumberAndSeries { get; set; }
    public string? IdentificationNumber { get; set; }
}