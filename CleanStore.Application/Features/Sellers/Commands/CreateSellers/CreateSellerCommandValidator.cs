
using FluentValidation;

namespace CleanStore.Application.Features.Sellers.Commands.CreateSellers
{
    public class CreateSellerCommandValidator: AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
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
