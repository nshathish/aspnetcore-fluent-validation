namespace FluentValidationLab.Models;

public class ProfileVm
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    public string? Bio { get; set; }
    public AddressInfo? PrimaryAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class AddressInfo
{
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
}