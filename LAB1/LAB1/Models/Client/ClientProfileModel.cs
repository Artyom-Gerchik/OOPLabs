using Microsoft.AspNetCore.Mvc;

namespace LAB1.Models.Client;

public class ClientProfileModel
{
    public Entities.UserCategories.Client Client { get; set; }
}