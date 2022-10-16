using BusinessLogic.DTOs;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class PhoneCreateValidator : AbstractValidator<PhoneDTO>
    {
        public PhoneCreateValidator()
        {
            RuleFor(task => task.Model)
                .NotNull()
                .NotEmpty();

            RuleFor(task => task.Price)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(0, 1_000_000).WithMessage("Invalid price.");

            RuleFor(task => task.Memory)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(0, 10_000).WithMessage("Invalid memory.");

            RuleFor(task => task.Description)
                .NotNull()
                .NotEmpty()
                .Length(10, 1000);

            RuleFor(task => task.ImageUrl)
                .Must(IsUrl)
                .WithMessage("'{PropertyName}' must be a valid URL. eg: https://www.softserveinc.com");
        }
        private static bool IsUrl(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri? outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
