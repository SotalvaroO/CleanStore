
using FluentValidation;

namespace CleanStore.Application.Features.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
    {
        public UpdateSellerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} cannot be empty")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} cannot exceed 50 chars");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} cannot be empty");
        }
    }
}
