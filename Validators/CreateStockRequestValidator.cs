using FluentValidation;
using WebApplication5.Dtos.Stock;

namespace WebApplication5.Validators;

public class CreateStockRequestValidator : AbstractValidator<CreateStockRequestsDto>
{
    public CreateStockRequestValidator()
    {
        RuleFor(x => x.Symbol)
            .NotEmpty().WithMessage("Symbol is required.")
            .MaximumLength(10).WithMessage("Symbol cannot be over 10 characters.");

        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(10).WithMessage("Company name cannot be over 10 characters.");

        RuleFor(x => x.Purchase)
            .NotEmpty().WithMessage("Purchase is required.")
            .InclusiveBetween(1, 1000000000).WithMessage("Purchase must be between 1 and 1,000,000,000.");

        RuleFor(x => x.LastDiv)
            .NotEmpty().WithMessage("LastDiv is required.")
            .InclusiveBetween(0.001m, 100m).WithMessage("LastDiv must be between 0.001 and 100.");

        RuleFor(x => x.Industry)
            .NotEmpty().WithMessage("Industry is required.")
            .MaximumLength(20).WithMessage("Industry cannot be over 20 characters.");

        RuleFor(x => x.MarketCap)
            .NotEmpty().WithMessage("MarketCap is required.")
            .InclusiveBetween(1, 5000000000000000).WithMessage("MarketCap must be between 1 and 5,000,000,000,000,000.");
    }
}