using FluentValidation;
using System.Text.RegularExpressions;

namespace FluentValidationLab.Models;

public class ProfileVmValidator : AbstractValidator<ProfileVm>
{
    public ProfileVmValidator(IValidator<AddressInfo> addressInfoValidator)
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
        RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress().WithMessage("Email Address is required");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required");
        RuleFor(x => x.DateOfBirth).InclusiveBetween(new DateTime(1971, 1, 1), DateTime.Now.AddYears(-10));
        RuleFor(x => x.PrimaryAddress).SetValidator(addressInfoValidator!);
    }
}

public class AddressInfoValidator : AbstractValidator<AddressInfo>
{
    public AddressInfoValidator()
    {
        RuleFor(x => x.Line1).NotEmpty().WithMessage("Address Line 1 is required");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required");
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required");
        RuleFor(x => x.Pincode).NotEmpty().WithMessage("Pincode is required")
            .MinimumLength(6).WithMessage("Pincode must be 6 digits")
            .MaximumLength(6).WithMessage("Pincode must be 6 digits")
            .Must(x => !string.IsNullOrEmpty(x) && Regex.IsMatch(x, @"^d")).WithMessage("Invalid pin code");
    }
}